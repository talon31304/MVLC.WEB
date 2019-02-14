var EditCol = 7;
function HideAll(ClassName) {
    var divsToHide = document.getElementsByClassName(ClassName); //divsToHide is an array
    for (var i = 0; i < divsToHide.length; i++) {
        //divsToHide[i].style.visibility = "hidden"; // or
       divsToHide[i].style.display = "none"; // depending on what you're doing
    }

}
function ShowAll(ClassName) {
    var divsToHide = document.getElementsByClassName(ClassName); //divsToHide is an array
    for (var i = 0; i < divsToHide.length; i++) {
        //divsToHide[i].style.visibility = "hidden"; // or
        divsToHide[i].style.display = "inline"; // depending on what you're doing
    }

}

function SetEditColumn(ColNumber) {


    for (i = 1; i < (ColNumber - 2); i++) {
        HideAll('Session'.concat(i));
    }
    for (i = 1; i < (ColNumber); i++) {


        HideAll('SessionEntry'.concat(i));
    }
    for (i = ColNumber-2; i < (ColNumber); i++) {
        ShowAll('SessionText'.concat(i));
    }

    //test
}
function SetInitialVisibleState() {
    SetEditColumn(EditCol);
    EditCol--;
   
    alert(EditCol);
}

window.onload =   SetInitialVisibleState();


//alert("Herex123");


