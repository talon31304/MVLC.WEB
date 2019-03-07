using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVLC.DAL.Entities;

namespace MVLC.DAL.Models
{
    public class DynamicSectionContent
    {
        public DynamicSectionContent(SectionContent SC, SectionLayout SL)
        {
            this.Title = SC.Title;
            this.SectionLayoutID = SC.SectionLayoutID;
            this.SubTitle = SC.SubTitle;
            this.BodyHTML = SC.BodyHTML;
            this.NextContentID = SC.NextContentID;
            this.PreviousContentID = SC.PreviousContentID;
            this.ContentID = SC.ContentID;
            this.LayoutName = SL.LayoutName;
            this.HeaderLink = SL.HeaderLink;
            this.Header = SL.Header;
            this.Footer = SL.Footer;
            this.CssClass = SL.CssClass;
        }
        public DynamicSectionContent(int ContentID,string LayoutName, string HeaderLink, string Header, string Footer, string CssClass)
        {
            this.ContentID = ContentID;
            this.LayoutName = LayoutName;
            this.HeaderLink = HeaderLink;
            this.Header = Header;
            this.Footer = Footer;
            this.CssClass = CssClass;
        }
        public DynamicSectionContent()
        {

        }

        public int ContentID { get; set; }
        public string LayoutName { get; set; }
        public string HeaderLink { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string CssClass { get; set; }

        public string Title { get; set; }
        public int SectionLayoutID { get; set; }
        public string SubTitle { get; set; }
        public string BodyHTML { get; set; }
        public Nullable<int> NextContentID { get; set; }
        public Nullable<int> PreviousContentID { get; set; }

    }
}
