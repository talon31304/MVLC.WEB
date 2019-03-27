using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class EnvironmentInfo
    {
        public string CurrentStatus { get; set; }
        public string EnvironmentType { get; set; }
        public string DataSource { get; set; }
        public string DB { get; set; }
    }
}