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
        var drpMultiselect = $("<select class='form-control'>").attr("id", "drpDownHeader_" + index.toString());
        //<select class="form-control" id="drpMarkets"></select>
        //var data = column.data().unique;

        column.data().unique().sort().each(function (d, j) {
            var option = $('<option/>');
            let first = d.search("value") + 7;
            let last = d.search(">")-1;
            let len = last - first;
            let valueofoptio = d.substr(first, len).trim();
            if (len <= 0) { option.attr({ 'value': d }).text(d); }
            else { option.attr({ 'value': d.substr(first, len) }).text(d.substr(first, len)); }
            //option.attr({ 'value': d }).text(d);
            
           // option.attr({ 'value': d.substr(64, d.search(">") - 1) }).text(d.substr(64, d.search(">") - 1));
           // d.substr(64, 1)
            drpMultiselect.append(option);
            //var dr = ("#drpDownHeader_0");
            //dr.html('');
            //dr.append(option);
        });
        filterHeader.append(drpMultiselect);


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