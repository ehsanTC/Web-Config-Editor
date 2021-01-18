using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WebConfigEditor
{
    class RegistryIO : IDisposable
    {
        private static RegistryKey key;
        private const int TotalConfigs = 10;
        private const string AppAddress = @"SOFTWARE\WebConfigEditor";
        public  const string RootPath = "root_path";
        public  const string Project = "project";
        public  const string DataSource = "DataSource";
        public  const string InitialCatalog = "InitialCatalog";
        public  const string BaseCatalog = "BaseCatalog";

        public RegistryIO()
        {
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(AppAddress, true);
        }

        public string GetProjectPath() => this.GetValue(RootPath);
        public string GetProject() => this.GetValue(Project);
        private string GetValue(string k) => key?.GetValue(k)?.ToString();
        private void SetValue(string aKey, string value) => key.SetValue(aKey, value);

        public void Dispose()
        {
            key?.Close();
        }

        public IEnumerable<WebConfigData> GetConfigsList()
        {
            List<WebConfigData> result = new List<WebConfigData>();

            for (int i = 0; i < TotalConfigs; i++)
            {
                string dataSource = GetValue($"{DataSource}_{i}");
                if (String.IsNullOrEmpty(dataSource))
                    continue;

                result.Add(new WebConfigData
                {
                    Id = i,
                    DataSource = dataSource,
                    InitialCatalog = GetValue($"{InitialCatalog}_{i}"),
                    BaseCatalog = GetValue($"{BaseCatalog}_{i}")
                });
            }

            return result;
        }

        public void WriteProject(string projectName)
        {
            SetValue(Project, projectName);
        }

        public void WriteProjectPath(string path)
        {
            SetValue(RootPath, path);
        }

        public void WriteConfig(WebConfigData config)
        {
            var allConfigs = GetConfigsList();
            var registryConfig = allConfigs.FirstOrDefault(c => c.DataSource == config.DataSource);

            if (registryConfig != null)
            {
                SetValue($"{BaseCatalog}_{registryConfig.Id}", config.BaseCatalog);
                SetValue($"{InitialCatalog}_{registryConfig.Id}", config.InitialCatalog);
            }
            else
            {
                int index = allConfigs.Count();
                if (index < TotalConfigs)
                {
                    SetValue($"{DataSource}_{index}", config.DataSource);
                    SetValue($"{BaseCatalog}_{index}", config.BaseCatalog);
                    SetValue($"{InitialCatalog}_{index}", config.InitialCatalog);
                }
                else
                {
                    index-=1;
                    SetValue($"{DataSource}_{index}", config.DataSource);
                    SetValue($"{BaseCatalog}_{index}", config.BaseCatalog);
                    SetValue($"{InitialCatalog}_{index}", config.InitialCatalog);
                }
            }
        }
    }
}
