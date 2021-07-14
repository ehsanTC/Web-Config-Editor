using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfigEditor
{
    public class ListFiles
    {
        private string[] projectsConfigAddress;

        public ListFiles(string rootFolderPath, string projectFolder)
        {
            projectsConfigAddress = new[]
            {
                Path.Combine(rootFolderPath, projectFolder, @"LegoProject\Lego.FrameworkWeb\Lego.Web\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\BookingPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\CSPPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\CommodityPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\VehiclePresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\VisitorManagmentPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"GoodsBasket\BskPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Framework2003\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Framework\FrmPresentation\FrmPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Mission\MissionPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Script\ScrPresentation\ScrPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Protection\VehiclePresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"ProcessManager\WizardManagerPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"TA\TAPresentation\TAPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Restaurant\RstPresentation\RstPresentation\Web.config"),
                Path.Combine(rootFolderPath, projectFolder, @"Transport\TrsPresentation\Web.config")
            };
        }

        public IEnumerable<string> GetFiles()
        {
            foreach (string adrs in projectsConfigAddress)
            {
                yield return adrs;
            }
        }
    }


}
