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
           
            success: function (r) {
                alert(r + " record(s) updated.");
            }
        });


    });

});
var calldatatable = function () {
    $('#dataTableId').DataTable();
}