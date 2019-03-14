var ActiveColumn = -1;
var MaxColumn = -1;
var ActiveRow = -1;
var MaxVisible = 1;
var MaxRow = -1;

//Returns apropriate row or column number based on parameters passed-
//If InitialText is "FIRST" or "Last", returns the aproprioate value
//If no or invalid value is passed, return default.
function GetRowOrColNumber(InititalText, Max, defaultVal) {
    var val = 0;
    if (InititalText  &&  (InititalText=='FIRST' || InititalText=='LAST'))
    {
        if (InititalText == 'FIRST') {
            val = 1;
        }
        else {
            val = Max;
        }
    }
    else {
        val = defaultVal
    }
    return val;
}
function SetMaxRowandMaxColumn() {
    var tbls = document.getElementsByClassName('GridTable');
    var i = 0;
    var StartingRow = 1;
    if (tbls.length > 0)
    {
        MaxColumn=GetNumberOfColumns(tbls[0].id)
    }

    while (i < tbls.length) {
        i++;
    }

}


function GridInit(MaxColsVisible,InitialActiveRow, InitialActiveColumn,TreatMultiplesAsOneLong)
{
   // if (TreatMultiplesAsOneLong);

    if (MaxColsVisible && MaxColsVisible>0) {
        MaxVisible = MaxColsVisible;
    } else {
        MaxVisible = 11;
    }
    ActiveColumn = GetRowOrColNumber(InitialActiveColumn, MaxColumn, -1)
    ActiveColumn = GetRowOrColNumber(InitialActiveRow, MaxRow, -1)

    

   // alert('xds');
    var tbls = document.getElementsByClassName('GridTable');
    var i = 0;
    var StartingRow = 1;
    while (i < tbls.length) {
        alert(tbls[i].id);
        if (!TreatMultiplesAsOneLong) {
            StartingRow = 1;
        }
        StartingRow = SetInitialRowandColumnClasses(tbls[i].id, StartingRow);
        i++;
    }
    alert('Done xds');
}
function GetNumberOfColumns(tableID) {
    var numCols = $('#' + tableID).find('tr')[0].cells.length;
    return numCols
}


function SetInitialRowandColumnClasses(tableID, StartingRowNumber) {
    var TotalCols = GetNumberOfColumns(tableID);
    alert(TotalCols);
    $('#'+tableID+ ' tr').each(function () {
        var colNum = 1;

        $.each(this.cells, function () {
            
            $(this).addClass('Column' + colNum);

            if (colNum == 1) {
                $(this).addClass('FirstColumn');
            }
            else if (colNum < TotalCols) {
                $(this).addClass('xDataColumn');
                $(this).addClass('xDataColumn' + (colNum - 1));
            }
            else {
                $(this).addClass('LastColumn');
            }

            colNum++;


        });


        //$('td', this).each(function () {
           
        //})
    })
}


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
   // If first column is visble, can hide Left Nav
    if (FirstVisibleColumn <= 1) {
        $('#TopLeftDateNav').removeClass('Show');
        $('#TopLeftDateNav').addClass('Hide');
       // TopRightNavCircle
        $('#TopLeftNavCircle').removeClass('Show');
        $('#TopLeftNavCircle').addClass('Hide');
    }
        //Left side Nav must be visible
    else {
        var leftSideDate = $('#SmallDateDiv' + (FirstVisibleColumn - 1)).html();
        $('#TopLeftDateNav').html('...'+leftSideDate) //copyinging column header info
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

    while (((FirstVisibleColumn + MaxVisible - 1) > MaxColumn) && (FirstVisibleColumn > 0)) { FirstVisibleColumn-- }

   
    SetNavVisibility(FirstVisibleColumn);





    if ((currentColumn < FirstVisibleColumn)
        || currentColumn > (FirstVisibleColumn + MaxVisible - 1)
       )
        {
        //Hide Column and add to left/right nav if needed
        SetColumnVisibilityClass('EntryDataColumn' + (currentColumn).toString(), 'HiddenColumn');



        }
    else {
        if (currentColumn != ActiveColumn) {
            SetColumnVisibilityClass('EntryDataColumn' + (currentColumn).toString(), 'InactiveColumn');
        }
        else {
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
        SetAllColumnVisibility();
    }
}
    function MoveRight()
    {
        if (ActiveColumn <MaxColumn) {   
            ActiveColumn++;
            SetAllColumnVisibility();
        }
    }

