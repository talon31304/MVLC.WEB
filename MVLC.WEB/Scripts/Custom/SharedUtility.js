var Testing = true;
function TestAlert(str)
{
    if (Testing==false)
    {
        alert('Test Message: ' + str);
    }
}

function fireChangeFor(ctrlID) {
    var element = document.getElementById(ctrlID);
    var event = new Event('change');
    // alert(ctrlID);
    element.selectedIndex = 0
    element.dispatchEvent(event);
}


function ShowandFade(elemID) {
    $('#' + elemID).show().delay(10000).fadeOut();

}
