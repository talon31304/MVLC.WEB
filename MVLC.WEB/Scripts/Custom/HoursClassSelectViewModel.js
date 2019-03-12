var ActiveColumn = -1;
var MaxColumn = -1;
var ActiveRow = -1;
var MaxVisible = 1;
var MaxRow = -1;






function getActiveColumn()
{
 
    ActiveColumn = -1;
      var i=1;
      while (i < 51 && ActiveColumn < 0) {
        var MatchingElems = document.getElementsByClassName('EntryDataColumn ActiveColumn EntryDataColumn' + i)
        if (MatchingElems.length > 0) {
            ActiveColumn = i;
        }
        i++;
    }
     
}
function CellActive (actionType,row,column)
{
    SetActiveandMaxColumns();
   // alert("You activated Column: " + column + " and row: "+ row);
    if (actionType == "Click") {
        SetActiveColumn(column)
    }
   
    SetActiveRow(row);
}
function SetActive(row, column) {
  
    SetActiveRow(row);
  }
function SetActiveColumn(column) {
    SetActiveandMaxColumns();
    while (column < ActiveColumn && ActiveColumn > 1) { MoveLeft(); }
    while (column > ActiveColumn && ActiveColumn < MaxColumn) { MoveRight(); }
    $(".MissingHoursDetails").hide();
}

function SetActiveRow(row)
{
   // alert("Pxsd");
    var elem = document.getElementById("DataRow" + row);
 
    if (elem != null) {
        ActiveRow = row;

        var elemsToSwapClass = document.getElementsByClassName("ActiveRow");
        for (var i = 0; i < elemsToSwapClass.length; i++) {
            elemsToSwapClass[i].classList.remove("ActiveRow");
        }
        var elem = document.getElementById("DataRow" + row);
        elem.classList.add("ActiveRow");
    }
}

function SetActiveandMaxColumns() {
    getActiveColumn();
    MaxColumn = ActiveColumn
    //if (MaxColumn < 0 || ActiveColumn < 0) {
       // var elemsToSwapClass = document.getElementsByClassName('ActiveColumn');

        

        var MatchingElems = document.getElementsByClassName('EntryDataColumn'+ActiveColumn);
        var i = ActiveColumn;
        while (i < 50 && MatchingElems.length > 0) {
            i++;
            MatchingElems = document.getElementsByClassName('EntryDataColumn'+i);

        }

        i--;       
        MaxColumn = i;
   // }
   // alert(ActiveColumn);
}


function SwapClassNameOnElements(IDName,RemoveName, AddName) {
    var elemsToSwapClass = document.getElementsByClassName(IDName);
    for (var i = 0; i < elemsToSwapClass.length; i++) {
        elemsToSwapClass[i].classList.add(AddName);
        elemsToSwapClass[i].classList.remove(RemoveName);
    }
}
function SetColumnVisibilityClass(IDName, AddName) {
    var elemsToSwapClass = document.getElementsByClassName(IDName);
    for (var i = 0; i < elemsToSwapClass.length; i++) {
        
        elemsToSwapClass[i].classList.remove('InactiveColumn');
        elemsToSwapClass[i].classList.remove('HiddenColumn');
        elemsToSwapClass[i].classList.remove('ActiveColumn');
        elemsToSwapClass[i].classList.add(AddName);
    }
}
function SetNavVisibility(FirstVisibleColumn)
{
   // alert(FirstVisibleColumn);
    if (FirstVisibleColumn <= 1) {
        $('#TopLeftDateNav').removeClass('Show');
        $('#TopLeftDateNav').addClass('Hide');
       // TopRightNavCircle
        $('#TopLeftNavCircle').removeClass('Show');
        $('#TopLeftNavCircle').addClass('Hide');
    }
    else {
        var leftSideDate = $('#SmallDateDiv' + (FirstVisibleColumn - 1)).html();
        $('#TopLeftDateNav').html('...'+leftSideDate)
        $('#TopLeftDateNav').removeClass('Hide');
        $('#TopLeftDateNav').addClass('Show');
        $('#TopLeftNavCircle').removeClass('Hide');
        $('#TopLeftNavCircle').addClass('Show');

    }

    if ((FirstVisibleColumn + MaxVisible) > MaxColumn) {
        $('#TopRightDateNav').removeClass('Show');
        $('#TopRightDateNav').addClass('Hide');
        $('#TopRightNavCircle').removeClass('Show');
        $('#TopRightNavCircle').addClass('Hide')
    }
    else {
        var rightSideDate = $('#SmallDateDiv' + (FirstVisibleColumn + MaxVisible)).html();
        $('#TopRightDateNav').html(rightSideDate+'...')
        $('#TopRightDateNav').removeClass('Hide');
        $('#TopRightDateNav').addClass('Show');
        $('#TopRightNavCircle').removeClass('Hide');
        $('#TopRightNavCircle').addClass('Show');

    }
}

function SetOneColumnVisibility(currentColumn, ColumnsVisiblePerSide) {
    var colsAbove = MaxColumn - ActiveColumn;
    var colsBelow = ActiveColumn - 1;

    var FirstVisibleColumn = ActiveColumn - ColumnsVisiblePerSide

    while (FirstVisibleColumn < 1) { FirstVisibleColumn++ }
   // alert(FirstVisibleColumn);//2>4-3
    while (((FirstVisibleColumn + MaxVisible - 1) > MaxColumn) && (FirstVisibleColumn > 0)) { FirstVisibleColumn-- }

   
    SetNavVisibility(FirstVisibleColumn);





    if ((currentColumn < FirstVisibleColumn)
        || currentColumn > (FirstVisibleColumn + MaxVisible - 1)
       )
        {
        //Hide Column and add to left/right nav if needed
        SetColumnVisibilityClass('EntryDataColumn' + (currentColumn).toString(), 'HiddenColumn');

        //var currentDate = $('#SmallDateDiv' + currentColumn).html();
        //if (currentColumn == (FirstVisibleColumn-1))
        //{
        //    $('#TopLeftDateNav').html(currentDate)
        //    $('#TopLeftDateNav').removeClass('Hide');
        //    $('#TopLeftDateNav').addClass('Show');
        //}
        //else if (currentColumn == (FirstVisibleColumn + MaxVisible))
        //{
        //    $('#TopRightDateNav').html(currentDate)
        //    $('#TopRightDateNav').removeClass('Hide');
        //    $('#TopRightDateNav').addClass('Show');

        //}


        }
    else {
        if (currentColumn != ActiveColumn) {
            //ShowIt as inactive
            SetColumnVisibilityClass('EntryDataColumn' + (currentColumn).toString(), 'InactiveColumn');

        }
        else {
            //ShowitActive

           // ActiveColumn
            SetColumnVisibilityClass('EntryDataColumn' + (currentColumn).toString(), 'ActiveColumn');

        }

    }

}
function SetAllColumnVisibility()
{
    for (var i = 1; i <= MaxColumn; i++)
    {
        var ColumnsVisiblePerSide = Math.floor(MaxVisible / 2);
        SetOneColumnVisibility(i, ColumnsVisiblePerSide)
    }

}
function MoveLeft()
{
    if (ActiveColumn > 1) {
        ActiveColumn--;
       // alert('p1');
        SetAllColumnVisibility();
       // alert('p2');
    }
}
    function MoveRight()
    {
        if (ActiveColumn <MaxColumn) {   
            ActiveColumn++;
         //   alert('p1');
            SetAllColumnVisibility();
          //  alert('p2');
        }
    }
//function MoveLeft()
//{

//    SetActiveandMaxColumns();
//    if (ActiveColumn > 1) {
//        SwapClassNameOnElements('EntryDataColumn' + ActiveColumn.toString(), 'ActiveColumn', 'InactiveColumn')

//        //if it is already not the last column, or in the first two columns, keep centered by hiding rightmost, and adding leftmost
//        if ((ActiveColumn < MaxColumn) && (ActiveColumn > 2)) {
//            SwapClassNameOnElements('EntryDataColumn' + (ActiveColumn + 1).toString(), 'InactiveColumn', 'HiddenColumn')
//            SwapClassNameOnElements('EntryDataColumn' + (ActiveColumn - 2).toString(), 'HiddenColumn', 'InactiveColumn')
//        }
//        ActiveColumn--;
//        SwapClassNameOnElements('EntryDataColumn' + ActiveColumn.toString(), 'InactiveColumn', 'ActiveColumn')
//    }
//}

//function MoveRight() {
//    SetActiveandMaxColumns();
//    if (ActiveColumn < MaxColumn) {
//        SwapClassNameOnElements('EntryDataColumn' + ActiveColumn.toString(), 'ActiveColumn', 'InactiveColumn')

//        //if it is already not the first column, or in the last two columns, keep centered by hiding leftmost, and adding rightmost
//        if ((ActiveColumn > 1) && (ActiveColumn < (MaxColumn-1))) {
//            SwapClassNameOnElements('EntryDataColumn' + (ActiveColumn -1).toString(), 'InactiveColumn', 'HiddenColumn')
//            SwapClassNameOnElements('EntryDataColumn' + (ActiveColumn +2).toString(), 'HiddenColumn', 'InactiveColumn')
//        }
//        ActiveColumn++;
//        SwapClassNameOnElements('EntryDataColumn' + ActiveColumn.toString(), 'InactiveColumn', 'ActiveColumn')
//    }
//}

