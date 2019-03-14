

function DisplayDynamicPopupDiv(ContentID)
{
    TargetDivID = "DynamicDivPopup";
    TestAlert('Fetching:' + ContentID);

    $.get('/Content/Get/' + ContentID, function (data) {
        $('#DynamicDivPopup').html(data);
        $('#DynamicDivPopup').show();
        $('.popupCloseButton').click(function () {
            $('#DynamicDivPopup').hide();
        });

        //$('.hover_bkgr_fricc').show();
        //$('.popupCloseButton').click(function () {
        //    $('.hover_bkgr_fricc').hide();
        //});

    });

}



//$(window).load(function () {
//    alert('LOADED P1');
//    $(".trigger_popup_fricc").click(function () {
//        $('.hover_bkgr_fricc').show();
//    });
//    alert('LOADED P2');
//    $('.hover_bkgr_fricc').click(function () {
//        $('.hover_bkgr_fricc').hide();
//    });
//    alert('LOADED P3');
//    $('.popupCloseButton').click(function () {
//        $('.hover_bkgr_fricc').hide();
//    });
//    alert('LOADED P4');
//});

//alert('LOADED QQQQ');

    //var ClassValue = $('#HF_Value_ClassesDD').val();
    //alert(ClassValue);
    //if (ClassValue > 0) {

    //    $('#LoadingDiv').show();
    //    /* Request the partial view with .get request. */
    //    $.get('/Hours/Update/' + newValue, function (data) {
    //        $('#GridSection').html(data);
    //        $('#GridSection').fadeIn('fast');
    //        $('#LoadingDiv').hide();
    //        // alert('ss');
    //        OnGridReady();

    //        SetActiveRow(1);
    //    });
    //}



