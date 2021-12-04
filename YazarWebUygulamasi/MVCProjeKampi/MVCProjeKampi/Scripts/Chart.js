$(document).ready(function () {
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/Chart/CategoryChart/",
        success: function (result) {
            google.charts.load('current', {
                'packages': ['corechart']
            });
            google.charts.setOnLoadCallback(function () {
                drawChart(result);
            });
        }
    });
});

function drawChart(result) {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'CategoryName');
    data.addColumn('number', 'CategoryCount');
    var dataArray = [];

    $.each(result, function (i, obj) {
        dataArray.push([obj.CategoryName, obj.CategoryCount]);
    });
    data.addRows(dataArray);

    var columnChartOptions = {
        title: "Kategori - Blog Grafiği",
        width: 1000,
        height: 800,
        bar: { groupWidth: "20%" },
    };

    var columnChart = new google.visualization.PieChart(document
        .getElementById('Piechart_div'));

    columnChart.draw(data, columnChartOptions);
}