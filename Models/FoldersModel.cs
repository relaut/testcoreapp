using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreApp.Models
{
    public class FoldersModel
    {
        public string CurrentDirectory { get; set; }
        public List<string> Files { get; set; }
        public List<string> Folders { get; set; }
    }
}
