using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EditWebConfig_project
{
    class XmlReadWrite
    {
        private XDocument doc;

        public XmlReadWrite(string xmlPath)
        {
            if (!File.Exists(xmlPath))
                throw new FileNotFoundException("Web.config file not found.");

            doc = XDocument.Load(xmlPath);
            
        }

        public WebConfigData ReadConfig()
        {
            var result = new WebConfigData();

            var appSettings = doc.Root.Element("appSettings");
            var adds = appSettings.Descendants("add").ToList();
            if (adds != null)
            {
                result.DataSource = adds.First(x => x.Attribute("key").Value == "DataSource")
                    .Attribute("value").Value;
                result.InitialCatalog = adds.First(x => x.Attribute("key").Value == "InitialCatalog")
                    .Attribute("value").Value;
                result.BaseCatalog = adds.First(x => x.Attribute("key").Value == "BaseCatalog")
                    .Attribute("value").Value;
            }

            return result;
        }
    }
}
