var htmlColumns = [];
var activeTable = [];

//ajax call to retrieve columns from file
function getColumnNames() {
    return $.ajax({
        url: "/Table/GetColumns",
        type: "POST",
        data: { filename: "MOCK_DATA" },
        success: function (data) {
        //reset html columns
        htmlColumns = [];
            for (var i in data) {
                columns.push({"data" : data[i]});
            }
        },
        error: function () {
            alert("couldn't read columns");
        }
    });
}

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

//ajax call to read the rest of the table contents
function getTableContents() {
    $.ajax({
        url: "/Table/ReadTable",
        type: "POST",
        data: { filename: "MOCK_DATA" },
        success: function (data) {
            initHtmlTable(data);
        },
        error: function () {
            alert("couldn't read table contents");
        }
    });
}

//initialize DataTable object to display on page
function initHtmlTable(contents) {
    $(activeTable).DataTable({
        retrieve: true,
        data: contents,
        columns: htmlColumns
    });
}

