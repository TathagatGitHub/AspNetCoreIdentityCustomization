$(document).ready(function () {
    alert("first time");
    calldatatable();
    $('body').on("click", "#btnSave", function (e) {
       // alert("button clicked");
       // var btnClicked = $(this);

        //$("#dataTableId tr.item").each(function () {
        //    //debugger
        //    var row = this;
        //});

       // var sList = "";
        var postlogObjList = new Array();
        var postlogObj = {};

        $('input[type=checkbox]').each(function () {
            var sThisVal = (this.checked ? "1" : "0");
            var row = $(this).closest("tr")[0];

            if (sThisVal === '1') {
                var PostLogId = row.cells[1].innerText;
                var SchedId = row.cells[2].innerText;
                var ScheduleName = row.cells[3].children[0].value;
                var WeekNbr = row.cells[4].children[0].value;
                var WeekDate = row.cells[5].innerText;
                var CreateDt = row.cells[6].innerText;
                var UpdateDt = row.cells[7].innerText;
                postlogObj.PostLogId = PostLogId;
                postlogObj.SchedId = SchedId;
                postlogObj.ScheduleName = ScheduleName;
                postlogObj.WeekNbr = WeekNbr;
                postlogObj.WeekDate = WeekDate;
                postlogObj.CreateDt = CreateDt;
                postlogObj.UpdateDt = UpdateDt;
                postlogObjList.push(postlogObj);

            }

        });
        //var serializedData = $(postlogObjList).serializeArray();
        //var paramData = $.param(serializedData);
        $.ajax({
            //async: true,
            type: 'POST',
           dataType: 'json',
           //contentType: 'application/json; charset=utf-8',
            url: '/Postlog/modelDatatableListPost/',
           /* url: '@Url.Action("/Postlog/modelDatatableListPost", "postlogObjList")',*/
           /* data: JSON.stringify(postlogObjList),*/
            data: { postlogObjList: JSON.stringify(postlogObjList) },
            
            success: function (r) {
                alert(r + " record(s) updated.");
            }
        });


    });

});
var calldatatable = function () {
    $('#dataTableId').DataTable();
}