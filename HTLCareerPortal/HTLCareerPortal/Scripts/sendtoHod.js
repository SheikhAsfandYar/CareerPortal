
function SendList(jobid, appid, depid) {
    var dataToPost = {
        JobId: '' + jobid + '',
        App_Id: '' + appid + '',
        DepartmentId: $('#hodName'+appid+jobid).val(),
    }

    $.ajax({
        type: 'GET',
        url: '/Admin/Home/PassToHod',
        data: dataToPost,
        success: function (response) {
            alertify.logPosition('right');
            if(response.responseText=="empty"){
                alertify.error("Please Select HOD Name First..");
            }
            else if (response.responseText == "yes"){
                alertify.error("Already Sent To Selected HOD");
            }
            else
                alertify.success("Sent To Selected HOD Successfully..");
        }
    });
}