myComplete = function (xhr) {
    alert(`Hi ${xhr.responseText}!`);
    $("#ajaxresult").append('Record Inserted Successfully!');
};
myFailure = function (xhr) {
    alert(`Status: {xhr.status}, Status Text: {xhr.statusText}`);
    $("#ajaxresult").html(data);
};
mySucess = function (result) {
    if (result.success) {
        swal({
            title: "Success",
            text: 'Row successfully added.  ',
            type: 'success',
        });
    }
    else {
        swal({
            title: "Error",
            text: result.responseText,
            type: 'error',
        });
    }
    //alert(`Status: {xhr.status}, Status Text: {xhr.statusText}`);
    var respHtml;
    $.each(result.data, function (index, it) {
        respHtml = 'Key:' + index + 'value:' + it + '</br>';
        alert(respHtml);
    })
    $("#ajaxresult").text(respHtml);

};
$(document).ready(function () {
    alert("document ready");
    $("#ajaxresult").html("Data being sent!");
});
