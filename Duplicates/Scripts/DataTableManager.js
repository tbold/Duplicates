var htmlColumns = [];
var activeTable = [];

//need to add tags to the table before initializing it as a DataTable
function prepHtmlTable() {
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

