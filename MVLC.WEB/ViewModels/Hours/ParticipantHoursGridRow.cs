using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class ParticipantHoursGridRow
    {
        public int ParticpantID { get; set; }
        public string PartipantName { get; set; }
        public DateHours[] Hours { get; set; }
        public int RowNumber { get; set; }
        public ParticipantsHoursGridCellContent[] DataCells { get; set; }
        public bool IsLast { get; set; }

    }
}