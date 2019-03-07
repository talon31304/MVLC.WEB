using MVLC.WEB.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVLC.WEB.ViewModels
{
    public class xxxHoursEntryViewModel
    {
        public int SelectedTutorID { get; set; }
        public string TutorLbl { get; set; }
        public IEnumerable <SelectListItem> ActiveTutorList { get; set; }

        private readonly List<IceCreamFlavor> _flavors;

        [Display(Name = "Favorite Flavor")]
        public int SelectedFlavorId { get; set; }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get { return new SelectList(_flavors, "Id", "Name"); }
        }

    }
}