using System.Collections.Generic;
using System.ComponentModel;

namespace WebConfigEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.projComboBox = new System.Windows.Forms.ComboBox();
            this.btnPathSelect = new System.Windows.Forms.Button();
            this.txtSourceCodePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.homeTabPage = new System.Windows.Forms.TabPage();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripProject = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTabCtrl.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.homeTabPage.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.settingsTabPage);
            this.mainTabCtrl.Controls.Add(this.homeTabPage);
            this.mainTabCtrl.Location = new System.Drawing.Point(7, 4);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(447, 186);
            this.mainTabCtrl.TabIndex = 10;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.label5);
            this.settingsTabPage.Controls.Add(this.projComboBox);
            this.settingsTabPage.Controls.Add(this.btnPathSelect);
            this.settingsTabPage.Controls.Add(this.txtSourceCodePath);
            this.settingsTabPage.Controls.Add(this.label4);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(439, 160);
            this.settingsTabPage.TabIndex = 0;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Select the Project";
            // 
            // projComboBox
            // 
            this.projComboBox.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projComboBox.FormattingEnabled = true;
            this.projComboBox.Location = new System.Drawing.Point(5, 72);
            this.projComboBox.Name = "projComboBox";
            this.projComboBox.Size = new System.Drawing.Size(390, 25);
            this.projComboBox.TabIndex = 24;
            this.projComboBox.SelectedIndexChanged += new System.EventHandler(this.projComboBox_SelectedIndexChanged);
            this.projComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.projComboBox_KeyDown);
            // 
            // btnPathSelect
            // 
            this.btnPathSelect.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathSelect.Location = new System.Drawing.Point(401, 21);
            this.btnPathSelect.Name = "btnPathSelect";
            this.btnPathSelect.Size = new System.Drawing.Size(35, 20);
            this.btnPathSelect.TabIndex = 23;
            this.btnPathSelect.Text = "...";
            this.btnPathSelect.UseVisualStyleBackColor = true;
            this.btnPathSelect.Click += new System.EventHandler(this.btnPathSelect_Click);
            this.btnPathSelect.Leave += new System.EventHandler(this.btnPathSelect_Leave);
            // 
            // txtSourceCodePath
            // 
            this.txtSourceCodePath.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceCodePath.Location = new System.Drawing.Point(5, 21);
            this.txtSourceCodePath.Name = "txtSourceCodePath";
            this.txtSourceCodePath.Size = new System.Drawing.Size(390, 24);
            this.txtSourceCodePath.TabIndex = 22;
            this.txtSourceCodePath.Leave += new System.EventHandler(this.txtSourceCodePath_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select your local MasterMindAgile directory";
            // 
            // homeTabPage
            // 
            this.homeTabPage.Controls.Add(this.btnLoad);
            this.homeTabPage.Controls.Add(this.txtBase);
            this.homeTabPage.Controls.Add(this.txtInit);
            this.homeTabPage.Controls.Add(this.txtSource);
            this.homeTabPage.Controls.Add(this.label3);
            this.homeTabPage.Controls.Add(this.label2);
            this.homeTabPage.Controls.Add(this.label1);
            this.homeTabPage.Controls.Add(this.btnChange);
            this.homeTabPage.Location = new System.Drawing.Point(4, 22);
            this.homeTabPage.Name = "homeTabPage";
            this.homeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homeTabPage.Size = new System.Drawing.Size(439, 160);
            this.homeTabPage.TabIndex = 1;
            this.homeTabPage.Text = "Home";
            this.homeTabPage.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(277, 131);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtBase
            // 
            this.txtBase.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase.Location = new System.Drawing.Point(75, 75);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(358, 23);
            this.txtBase.TabIndex = 18;
            this.txtBase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBase_KeyDown);
            // 
            // txtInit
            // 
            this.txtInit.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInit.Location = new System.Drawing.Point(75, 47);
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(358, 23);
            this.txtInit.TabIndex = 17;
            this.txtInit.TextChanged += new System.EventHandler(this.txtInit_TextChanged);
            this.txtInit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInit_KeyDown);
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(75, 16);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(358, 23);
            this.txtSource.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "BaseCatalog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "InitialCatalog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "DataSource";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(358, 131);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 20;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.statusStripProject});
            this.statusStrip.Location = new System.Drawing.Point(0, 193);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(460, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(50, 17);
            this.statusStripLabel.Text = "Project: ";
            // 
            // statusStripProject
            // 
            this.statusStripProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(255)))));
            this.statusStripProject.Name = "statusStripProject";
            this.statusStripProject.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 215);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainTabCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Web.config Editor";
            this.mainTabCtrl.ResumeLayout(false);
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.homeTabPage.ResumeLayout(false);
            this.homeTabPage.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox projComboBox;
        private System.Windows.Forms.Button btnPathSelect;
        private System.Windows.Forms.TextBox txtSourceCodePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage homeTabPage;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusStripProject;
    }
}

