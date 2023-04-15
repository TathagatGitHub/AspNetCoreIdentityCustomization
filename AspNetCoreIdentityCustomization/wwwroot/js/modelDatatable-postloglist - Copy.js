$(document).ready(function () {
    alert("first time");
    calldatatable();
    $('body').on("click", "#btnSave", function (e) {
   
       var postlogs = [];
       //var postlogObj = {};

        $('input[type=checkbox]').each(function () {
            var sThisVal = (this.checked ? "1" : "0");
            var row = $(this).closest("tr")[0];

            if (sThisVal === '1') {
                var postlogObj = {};
                postlogObj.PostLogId = parseInt(row.cells[1].innerText) //1;
                postlogObj.SchedId = parseInt(row.cells[2].innerText) //1;
                postlogObj.ScheduleName = row.cells[3].children[0].value; //"TEst";
                postlogObj.WeekNbr = parseInt(row.cells[4].children[0].value);//1;
                postlogObj.WeekDate = new Date(row.cells[5].innerText);//"2023-02-20";
                postlogObj.CreateDt = new Date(row.cells[6].innerText);//"2023-02-20";
                postlogObj.UpdateDt = new Date(row.cells[7].innerText);//"2023-02-20";
                postlogs.push(postlogObj);
                

            }

        });
 
        $.ajax({
         
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
             url: '/Postlog/modelDatatableListPost/',
           data: JSON.stringify(postlogs),
           
            success: function (data) {
                alert(data.rows + " record(s) updated.");

                var table = $('#dataTableId').DataTable();

                // #column3_search is a <input type="text"> element
               // $('#column3_search').on('keyup', function () {
                    table
                        .columns(1) ///ID column works for filter, not the editable. Use the id for filter.
                        .search(data.rows)
                        .draw();
              //  });
            }
        });


    });

});
var calldatatable = function () {
    $('#dataTableId').DataTable();
  //var api = new $.fn.dataTable.Api();
    var table = $('#dataTableId').DataTable();
    table.columns().eq(0).each(function (index) {
        //var tblCellIndex = $(api.column(index).header()).index();
        var filterHeader = $('#dataTableId thead tr:eq(1) th:eq(' + index + ')');
        if ($(filterHeader).hasClass("noFilter") && $(filterHeader).is(":visible"))
            return true;
        var column = table.column(index);
        filterHeader.html('');
        //multiselect change -1
        if (index === 2) {
            var drpMultiselect = $("<select class='form-control' multiple>").attr("id", "drpDownHeader_" + index.toString());
        }
            
        else {
            var drpMultiselect = $("<select class='form-control'>").attr("id", "drpDownHeader_" + index.toString());
        }
        


        column.data().unique().sort().each(function (d, j) {
            var option = $('<option/>');
            let first = d.search("value") + 7;
            let last = d.search(">")-1;
            let len = last - first;
            let valueofoptio = d.substr(first, len).trim();
            if (len <= 0) { option.attr({ 'value': d }).text(d); } // For ID columns, there is no Value field
            else { option.attr({ 'value': d.substr(first, len) }).text(d.substr(first, len)); }// For input columns, there is Value field
            
            
           // option.attr({ 'value': d.substr(64, d.search(">") - 1) }).text(d.substr(64, d.search(">") - 1));
           // d.substr(64, 1)
            drpMultiselect.append(option);
            
            
        });
        filterHeader.append(drpMultiselect);
        //multiselect change 2 
        filterHeader.find("#drpmulti_" + 2).multiselect({
            maxHeight: 300,
            //buttonWidth: '100%',
            search: true,
            includeSelectAllOption: true,
            enableFiltering: true,
            autoclose: true,
            nonSelectedText: "Select filter",
            allSelectedText: "Selected all",
            nSelectedText: "Selected",
            numberDisplayed: -1,
            enableCaseInsensitiveFiltering: true,
            dropDown: true
        }).change(function () {
                var vals = $(this).find('option:selected').map(function (index, element) {
                    return $.fn.dataTable.util.escapeRegex($(element).val());
                    //return $(element).val();
                }).toArray().join('|');

                dtTable.column(filterHeader)
                    .search(vals.length > 0 ? '^' + vals + '$' : '', true, false)
                    .draw();
                //var txt = (vals.length == 0 ? 'None selected' : val.length + ' selected');
                //$(this).parent().find('button> span.multiselect-selected-text').html(txt);
                //var vals = $(this).val()[0];
                //column.data().search(vals).draw();
                //dtTable.search(vals).draw();


            });
        //multiselect change 3
       // filterHeader.change(function () {
        filterHeader.find("#drpDownHeader_" + index.toString()).change(function () {
            //alert("change event");
            var vals = $(this).find('option:selected').map(function (index, element) {
                return $.fn.dataTable.util.escapeRegex($(element).val());
                //return $(element).val();
            }).toArray().join('|');
            var col = index;// $(this).parent().children().index($(this));
           // alert(vals);

            var table = $('#dataTableId').DataTable();

            // #column3_search is a <input type="text"> element
            // $('#column3_search').on('keyup', function () {
            table
                .columns(col) ///ID column works for filter, not the editable. Use the id for filter.
                .search(vals)
                .draw();

        });
        //filterHeader.find("#drpDownHeader_" + index.toString()).multiselect({
        //    maxHeight: 200,
        //    //buttonWidth: '100%',
        //    search: true,
        //    includeSelectAllOption: true,
        //    enableFiltering: true,
        //    autoclose: true,
        //    nonSelectedText: "Select filter",
        //    allSelectedText: "Selected all",
        //    nSelectedText: "Selected",
        //    numberDisplayed: -1,
        //    enableCaseInsensitiveFiltering: true,
        //    dropDown: true
        //}).change(function () {
        //    var vals = $(this).find('option:selected').map(function (index, element) {
        //        return $.fn.dataTable.util.escapeRegex($(element).val());
        //        //return $(element).val();
        //    }).toArray().join('|');

        //    dtTable.column(filterHeader)
        //        .search(vals.length > 0 ? '^' + vals + '$' : '', true, false)
        //        .draw();
            


        //});

    });


   
}