var htmlColumns = [];
var activeTable = [];

//need to add tags to the table before initialising it as a DataTable object
function prepHtmlTable() {
    if ($.fn.DataTable.isDataTable(activeTable)) {
        $(activeTable).DataTable().destroy();
        $(activeTable + ' tbody').empty();
    }
    $(activeTable + ' thead').empty().append('<tr></tr>');
    var table = $(activeTable + ' tr');
    for (var i in htmlColumns) {
        if (htmlColumns[i].data != null) {
            table.append('<th>' + htmlColumns[i].data + '</th>');
        }
    }
}


//initialize DataTable object to display on page
function initHtmlTable(contents) {
    $(activeTable).DataTable({
        data: contents,
        columns: htmlColumns
    });
}
