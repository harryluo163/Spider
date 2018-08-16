using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderApp.entity
{
    internal class DownloadFileInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Int64 FileSize { get; set; }
    }
}
