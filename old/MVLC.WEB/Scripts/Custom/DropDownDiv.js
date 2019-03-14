
//Setting Drop Down Value and display text
//Will Try to cascade
function SetDropDownDivValue(DropDownID, newText, newValue) {

    var HFValue = $('#HF_Value_' + DropDownID);
    HFValue.val(newValue);
    var menuTextElement = $('#Display_' + DropDownID);
    menuTextElement.text(newText);

    Cascade(DropDownID);
}


function GetDropDownDivValue(DropDownID)
{
    var HFValue = $('#HF_Value_' + DropDownID).val();
    return HFValue;
}


function GetPreviousCascadeValue(FromDropDownID)
{
    var PriorVal = "";
    elems = $('input[id^="HF_CascadeTo_"]');
    elems.each(function () {
        var currentVal = $(this).val()
        if (FromDropDownID == currentVal) {
            var PriorID = $(this).attr('id').replace("HF_CascadeTo_", "");
            PriorVal = $('#HF_Value_' + PriorID).val();
       
        }
    });

    return PriorVal;
}


function Cascade(FromDropDownID)
{
   

    var CascadeToDropDownID = $('#HF_CascadeTo_' + FromDropDownID).val();
   
    if (CascadeToDropDownID != "None" && CascadeToDropDownID != "undefined" && CascadeToDropDownID != "NaN")
    {
        var refreshURL = $('#HF_RefreshURL_' + CascadeToDropDownID).val();

        var p1 = GetDropDownDivValue(FromDropDownID);
        var DropDownSelectionDivID = 'Items_' + CascadeToDropDownID
        var PreviouslyCascadedVal = GetPreviousCascadeValue(FromDropDownID);

        fetchDataFromURL(DropDownSelectionDivID, refreshURL, p1, PreviouslyCascadedVal)

        var OriginalVal = $('#HF_InitialValue_' + CascadeToDropDownID).val();
        var OriginalText = $('#HF_InitialText_' + CascadeToDropDownID).val();

        if (OriginalText != null && OriginalVal != null) {
          //  alert('xsz'+CascadeToDropDownID + OriginalVal + " : " + OriginalText);
            SetDropDownDivValue(CascadeToDropDownID, OriginalText, OriginalVal)

        }

      
    }

}

function fetchDataFromURL(ctrlID, targetURL, pValue1, pValue2) {
    var paramName = "Term";
    var link = 'xurlx?P1=' + pValue1 + '&P2=' + pValue2;


    link = link.replace("xurlx", targetURL);
    link = link.replace(" ", "%20");
    link = link.replace("&amp;", "&");

    if (pValue1 != null && pValue1 != '') {


        $.get(link, function (data) {
            
            $('#'+ctrlID).html(data);
        });

    }
}


