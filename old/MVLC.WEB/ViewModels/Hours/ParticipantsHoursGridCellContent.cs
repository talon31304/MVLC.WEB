using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class ParticipantsHoursGridCellContent
    {
        public double Hours { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int ParticipantID { get; set; }
        public string DateString { get; set; }
    }
}