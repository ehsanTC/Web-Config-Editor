using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WebConfigEditor
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;
        private List<WebConfigData> webConfigList;
        private List<string> excludedProjects;

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            worker.DoWork += (sender, eventHandler) =>
            {
                RegistryIo reader = new RegistryIo();
                var result = new Dictionary<string, object>
                {
                    ["ProjectName"] = reader.GetProject(),
                    ["ProjectPath"] = reader.GetProjectPath(),
                    ["WebConfigList"] = reader.GetConfigsList()
                };
                eventHandler.Result = result;
            };

            worker.RunWorkerCompleted += (sender, eventHandler) =>
            {
                // if an exception not occurred during DoWork
                if (eventHandler.Error == null)
                {
                    ReadExcludedProjects();

                    var result = (Dictionary<string, object>) eventHandler.Result;

                    if (!String.IsNullOrEmpty(result["ProjectPath"]?.ToString()))
                    {
                        txtSourceCodePath.Text = result["ProjectPath"].ToString();
                        PopulateProjComboBoxData();

                        if (!String.IsNullOrEmpty(result["ProjectName"]?.ToString())
                            && !this.excludedProjects.Contains(result["ProjectName"]?.ToString()))
                            projComboBox.Text = result["ProjectName"].ToString();

                        mainTabCtrl.SelectTab(1);
                    }

                    webConfigList = (List<WebConfigData>) result["WebConfigList"];
                    FillDataSourceTextBox();
                }
                    
            };
            worker.RunWorkerAsync();
        }

        private void ReadExcludedProjects()
        {
            using (RegistryIo registry = new RegistryIo())
            {
                this.excludedProjects = registry.GetExcludedProjects().ToList();

                StringBuilder excludedProj = new StringBuilder();
                foreach (var x in this.excludedProjects)
                    excludedProj.Append(x + Environment.NewLine);
                
                txtExcludedProj.Text = excludedProj.ToString();
            }
        }

        private void FillDataSourceTextBox()
        {
            AutoCompleteStringCollection serverIps = new AutoCompleteStringCollection();
            webConfigList.ForEach(w => serverIps.Add(w.DataSource));

            txtSource.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSource.AutoCompleteCustomSource = serverIps;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeConfig();
        }

        private void SaveExcludedProjects()
        {
            if (String.IsNullOrEmpty(txtExcludedProj.Text))
                return;

            string[] projects = txtExcludedProj.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            excludedProjects.Clear();
            excludedProjects.AddRange(projects);

            using (RegistryIo writer = new RegistryIo())
            {
                writer.WriteExcludedProjects(projects.Where(x => !string.IsNullOrEmpty(x)).ToArray());
            }
        }

        private void ChangeConfig()
        {
            try
            {
                string path = txtSourceCodePath.Text;
                if (!CheckPath(ref path))
                {
                    MessageBox.Show("The selected folder doesn't contain MasterMindAgile!");
                    txtSourceCodePath.Clear();
                    return;
                }

                if (projComboBox.SelectedIndex == 0)
                {
                    MessageBox.Show("Select your project!");
                    return;
                }

                StringBuilder successfulMsg = new StringBuilder();
                StringBuilder unSuccessfulMsg = new StringBuilder();
                ListFiles projects = new ListFiles(txtSourceCodePath.Text, projComboBox.Text);
                foreach (var item in projects.GetFiles())
                {
                    if (!File.Exists(item))
                        continue;

                    try
                    {
                        FileInfo file = new FileInfo(item);
                        file.IsReadOnly = false;

                        var doc = XDocument.Load(item);
                        var appSettings = doc.Root.Element("appSettings");
                        var adds = appSettings.Descendants("add").ToList();
                        if (adds != null)
                        {
                            var dsTag = adds.Where(x => x.Attribute("key").Value == "DataSource");
                            var initTag = adds.Where(x => x.Attribute("key").Value == "InitialCatalog");
                            var baseTag = adds.Where(x => x.Attribute("key").Value == "BaseCatalog");
                            if (dsTag != null && initTag != null && baseTag != null)
                            {
                                dsTag.First().LastAttribute.Value = txtSource.Text;
                                initTag.First().LastAttribute.Value = txtInit.Text;
                                baseTag.First().LastAttribute.Value = txtBase.Text;
                            }

                            doc.Save(item);
                        }

                        successfulMsg.Append(new DirectoryInfo(Path.GetDirectoryName(item)).Name + Environment.NewLine);
                    }
                    catch (Exception)
                    {
                        unSuccessfulMsg.Append(new DirectoryInfo(Path.GetDirectoryName(item)).Name + Environment.NewLine);
                    }
                }

                string message = "";

                if (unSuccessfulMsg.Length > 0 && successfulMsg.Length > 0)
                    message = String.Format("Successful changes:{1}{0}Unsuccessful changes:{1}{2}",
                        successfulMsg.ToString() + Environment.NewLine,
                        Environment.NewLine + new string('-', 30) + Environment.NewLine,
                        unSuccessfulMsg);
                else if (unSuccessfulMsg.Length > 0 && successfulMsg.Length == 0)
                    message = "Changing Web.Config failed.";
                else
                    message = "Web.configs changed successfully.";

                MessageBox.Show(message);
                SaveConfigs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Changing Web.Config failed : " + ex.Message);
            }
        }

        private void btnPathSelect_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedPath = fbd.SelectedPath;
                    if (CheckPath(ref selectedPath))
                    {
                        txtSourceCodePath.Text = selectedPath;
                        PopulateProjComboBoxData();
                    }
                    else
                        MessageBox.Show("The selected folder doesn't contain MasterMindAgile!");
                }
            }
        }

        private void PopulateProjComboBoxData()
        {
            if (projComboBox.Items.Count > 0)
                projComboBox.Items.Clear();

            projComboBox.Items.Add(" - Select Project - ");

            if (!String.IsNullOrEmpty(txtSourceCodePath.Text))
                Directory.GetDirectories(txtSourceCodePath.Text)
                    .All(dir =>
                    {
                        FileInfo fileInfo = new FileInfo(dir);
                        if (excludedProjects == null || excludedProjects.Count == 0)
                            projComboBox.Items.Add(fileInfo.Name);

                        if (excludedProjects != null && !excludedProjects.Contains(fileInfo.Name))
                            projComboBox.Items.Add(fileInfo.Name);
                        return true;
                    });

            projComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Checks the selected path for MasterMindAgile folder
        /// </summary>
        /// <param name="path">MasterMindAgile folder path</param>
        /// <returns>True if it is valid, false elsewhere</returns>
        private bool CheckPath(ref string path)
        {
            if (path.EndsWith("MasterMindAgile"))
                return true;
            else if (Directory.Exists(Path.Combine(path, "MasterMindAgile")))
            {
                path = Path.Combine(path, "MasterMindAgile");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtSourceCodePath_Leave(object sender, EventArgs e)
        {
            string path = txtSourceCodePath.Text;
            if (String.IsNullOrEmpty(path))
                return;

            if (CheckPath(ref path))
            {
                txtSourceCodePath.Text = path;
                PopulateProjComboBoxData();
                this.ActiveControl = projComboBox;
            }
            else
            {
                this.ActiveControl = txtSourceCodePath;
                txtSourceCodePath.Select(0, path.Length);

                MessageBox.Show($"The {path} folder doesn't contain MasterMindAgile!");
            }
        }

        private void txtInit_TextChanged(object sender, EventArgs e)
        {
            txtBase.Text = txtInit.Text;
        }

        private void btnPathSelect_Leave(object sender, EventArgs e)
        {
            PopulateProjComboBoxData();
        }

        private void projComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // Go to next tab
                mainTabCtrl.SelectedIndex = 1;
            }
        }

        private void SaveConfigs()
        {
            using (RegistryIo writer = new RegistryIo())
            {
                writer.WriteProject(projComboBox.Text);
                writer.WriteProjectPath(txtSourceCodePath.Text);
                writer.WriteConfig(new WebConfigData
                {
                    DataSource = txtSource.Text,
                    InitialCatalog = txtInit.Text,
                    BaseCatalog = txtBase.Text
                });
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSourceCodePath.Text) || String.IsNullOrEmpty(projComboBox.Text))
            {
                MessageBox.Show("The Seetings are not complete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mainTabCtrl.SelectedIndex = 0;
                return;
            }

            ListFiles configFiles = new ListFiles(txtSourceCodePath.Text, projComboBox.Text);
            FileInfo legoWebConfig = new FileInfo(configFiles.GetFiles().ElementAt(0));

            try
            {
                XmlReadWrite reader = new XmlReadWrite(legoWebConfig.FullName);
                var config = reader.ReadConfig();

                txtSource.Text = config.DataSource;
                txtInit.Text = config.InitialCatalog;
                txtBase.Text = config.BaseCatalog;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The selected project is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mainTabCtrl.SelectedIndex = 0;
                projComboBox.Focus();
            }
        }

        private void txtInit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                ChangeConfig();
        }

        private void txtBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                ChangeConfig();
        }

        private void projComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            SetStatusStripText(cmb.Text);
        }

        private void SetStatusStripText(string text)
        {
            statusStripProject.Text = text;
        }

        private void aboutTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void txtSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            try
            {
                WebConfigData selectData = webConfigList.First(w => w.DataSource == txtSource.Text);
                txtBase.Text = selectData.BaseCatalog;
                txtInit.Text = selectData.InitialCatalog;
                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception){}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveExcludedProjects();

            // Save selected project
            string selectedProj = projComboBox.Text;
            PopulateProjComboBoxData();

            if (!this.excludedProjects.Contains(selectedProj))
                projComboBox.Text = selectedProj;
            else
                projComboBox.SelectedIndex = 0;

            MessageBox.Show("The excluded project will not be shown in the settings.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }
    }
}
