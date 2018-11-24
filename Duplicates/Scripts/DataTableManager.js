var htmlColumns = [];
var activeTable = [];

function getColumnNames(table) {
    activeTable = table;
    var columns = [];
    $.ajax({
        url: "/Table/GetColumns",
        type: "POST",
        data: { filename: "MOCK_DATA" },
        success: function (data) {
            for (var i in data) {
                columns.push(data[i]);
            }
            prepHtmlColumns(columns);
        },
        error: function () {
            alert("couldn't read columns");
        }
    });
}


function prepHtmlColumns(columns){
    for (var i in columns) {
        htmlColumns.push({ "data": columns[i] });
    }
}

function prepHtmlTable() {
    $(activeTable + ' thead').empty().append('<tr></tr>');
    var table = $(activeTable + ' tr');
    for (var i in htmlColumns) {
        if (htmlColumns[i].data != null) {
            table.append('<th>' + htmlColumns[i].data + '</th>');
        }
    }
}

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

function initHtmlTable(contents) {
    $(activeTable).DataTable({
        retrieve: true,
        data: contents,
        columns: htmlColumns,
        order: [[1, "asc"]]
    });
}

