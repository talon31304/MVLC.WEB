using MVLC.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class DropDownDiv
    {
        public List<DropDownDivElement> elements { get; set;}

        public bool IsRefreshofSelections { get; set; }
        public string OnClickFunctionName { get; set; }
        public string CurrentDisplayValue { get; set; }
        public string CurrentValue { get; set; }
        public string CascadeToID { get; set; }
        public string ItemsRefreshUrl { get; set; }

        public string HTML_ID { get; set; }
        public string Div_ID {get {return "Div_" + HTML_ID;}}
        public string HF_Value_ID { get { return "HF_Value_" + HTML_ID; } }
        public string HF_InitialValue_ID { get { return "HF_InitialValue_" + HTML_ID; } }
        public string HF_InitalText_ID { get { return "HF_InitialText_" + HTML_ID; } }

        public string HF_CascadeTo_ID { get { return "HF_CascadeTo_" + HTML_ID; } }
        public string HF_refreshUrl_ID { get { return "HF_RefreshURL_" + HTML_ID; } }

        public string MenuText_ID { get { return "Display_" + HTML_ID; } }
        public string ItemsDiv_ID { get { return "Items_" + HTML_ID; } }
        

        private DropDownDiv(string id, string SelectedValue, string CascadeToDropdownID, string CallonChangeFuntionName, bool isRefresh, string refreshURL)
        {
            ItemsRefreshUrl = refreshURL;
            IsRefreshofSelections = isRefresh;
            CascadeToID = CascadeToDropdownID;
            HTML_ID = id;           
            CurrentValue = SelectedValue;
            CurrentDisplayValue = SelectedValue; //Will be changed if ID/Name pair provided
            OnClickFunctionName = CallonChangeFuntionName;
        }
        public DropDownDiv(string id, string SelectedValue, List<NameID> NameIDList, bool isRefresh, string CascadeToDropdownID ="None", string CallonChangeFuntionName = "", string refreshUrl = "") 
            : this(id, SelectedValue, CascadeToDropdownID, CallonChangeFuntionName, isRefresh,refreshUrl)
        {
           
            elements = new List<DropDownDivElement>();
            foreach (NameID nID in NameIDList)
            {
                if (nID.ID== SelectedValue)
                {
                    CurrentDisplayValue = nID.Name;
                }
                elements.Add(new DropDownDivElement() { DropDownText = nID.Name, DropDownValue = nID.ID });
            }
        }
        public DropDownDiv(string id, string SelectedValue, List<string> SelectDisplayValuesList, bool isRefresh, string CascadeToDropdownID = "None", string CallonChangeFuntionName = "", string refreshUrl = "")
                   : this(id, SelectedValue, CascadeToDropdownID, CallonChangeFuntionName, isRefresh, refreshUrl)
        {
            CurrentValue = SelectedValue;
            elements = new List<DropDownDivElement>();
            foreach (string s in SelectDisplayValuesList)
            {
               elements.Add(new DropDownDivElement() { DropDownText = s, DropDownValue = s });
            }
        }


        public string GetMenuLinkID()
        {
            return "DDMLink_" + HttpUtility.UrlEncode(CurrentValue);
        }
        public string GetOnClick(DropDownDivElement element)
        {
            string functionParams= "('" + HTML_ID + "','" + element.DropDownText + "','" + element.DropDownValue + "'); ";

            string onClick = "SetDropDownDivValue" + functionParams;
            if (OnClickFunctionName != null && OnClickFunctionName.Length > 0)
            {
                onClick = onClick + " " + OnClickFunctionName + functionParams;
            }
            return onClick;
        }

    }
}