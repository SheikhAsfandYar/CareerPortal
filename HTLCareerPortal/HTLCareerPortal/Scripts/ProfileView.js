$(document).ready(function () {
    
    Profle();
    
    //PersonalInfo();
});
function Profle() {
    $.ajax({
        url: "/Profile/SignUp",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<h3><span class="Heading-Titles">Name : </span>' + item.Name + '</h3>';
                    html += '<p><span class="Heading-Titles">Address : </span>' + item.Address + ", " + item.City + '</p>';
                    html += '<p><span class="Heading-Titles">Email ID : </span>' + item.EmailID + '</p>';
                    html += '<p><span class="Heading-Titles">Contact No : </span>' + item.CellNo + '</p>';
                });
                $('.Header-Text').html(html);
            }
            else
                $('.Header-Text').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/PersonalInfo",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    var date = item.DOB;
                    var dob = new Date(parseInt(date.substr(6)));
                    html += '<ul class="PD-List">';
                    html += '<li>Name : ' + item.FirstName + ' ' + item.MiddleName + ' ' + item.LastName + '</li>';
                    html += '<li>Company Name : <span>' + item.Company + '</span></li>';
                    html += '<li>Current Designation : <span>' + item.CurrentDesignation + '</span></li>';
                    html += '<li>CNIC # : <span>' + item.CNIC + '</span></li>';
                    html += '<li>Postal Code : <span>' + item.PostalCode + '</span></li>';
                    html += '<li>Date of Birth : ' + dob.toDateString(); +'</li>';
                    html += '<li>Place of Birth : <span>' + item.PlaceOfBirth + '</span></li>';
                    html += '<li>Marital Status : <span>' + item.MaritalStatus + '</span></li>';
                    html += '</ul>';
                });
                $('.Personal-Detail').html(html);
            }
            else
                $('.Personal-Detail-Section').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/Experience",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.JobTitle + '</td>';
                    html += '<td>' + item.Industry + '</td>';
                    html += '<td>' + item.JobSpecialization + '</td>';
                    html += '<td>' + item.CompanyName + '</td>';
                    html += '<td>' + item.PhoneNo + '</td>';
                    html += '<td>' + item.CompanyAddress + '</td>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
            }
            else
                $('.Profile-Experience-Section').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/Education",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.Degree + '</td>';
                    html += '<td>' + item.CompletionYear + '</td>';
                    html += '<td>' + item.Institute + '</td>';
                    html += '<td>' + item.Specialization + '</td>';
                    html += '<td>' + item.CGPA + '</td>';
                    html += '</tr>';
                });
                $('.Edu-tbody').html(html);
            }
            else
                $('.Profile-Education-Section').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/JobSalary",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
            $.each(result, function (key, item) {
            html += '<ul class="JS-list">';
            html += '<li>Prefered Job Type (First) : <span>' + item.FirstWorkPreference + '</span></li>';
            html += '<li>Prefered Job Type (Second) : <span>' + item.SecondWorkPreference + '</span></li>';
            html += '<li>Prefered Job Type (Third) : ' + item.ThirdWorkPreference + '</li>';
            html += '<li>Prefered Job Grade (First) : <span>' + item.FirstPreference + '</span></li>';
            html += '<li>Prefered Job Grade (Second) : <span>' + item.SecondPreference + '</span></li>';
            html += '<li>Prefered Job Grade (Third) : ' + item.ThirdPreference +'</li>';
            html += '<li>Current Salary : <span>' + item.CurrentSalary + '</span></li>';
            html += '<li>Benifits : <span>' + item.Benifits + '</span></li>';
            html += '<li>Expected Gross Salary : <span>' + item.ExpectedGrossSalary + '</span></li>';
            html += '</ul>';
        });
        $('.JobSalary-Detail').html(html);
    }
    else
                $('.JobSalary-Section').hide();
    },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/ProfessionalReference",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.Name + '</td>';
                    html += '<td>' + item.Relationship + '</td>';
                    html += '<td>' + item.Designation + '</td>';
                    html += '<td>' + item.Organization + '</td>';
                    html += '<td>' + item.ContactNo + '</td>';
                    html += '</tr>';
                });
                $('.PR-tbody').html(html);
            }
            else
                $('.Professional-Reference-Section').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/Image",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<img src="/ApplicantImages/' + item.ImageUrl + '" class="img-responsive img-circle profile-image" alt="Profile Picture" />';
                });
                $('.image-box').html(html);
            }
            else
                $('.profile-image').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $.ajax({
        url: "/Profile/CareerObjective",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            if ($.trim(result)) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<p>' + item.CareerObjective + '</p>';
                });
                $('.objective-detail').html(html);
            }
            else
                $('.Profile-Objective-Section').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//function PersonalInfo() {
//    $.ajax({
//        url: "/Profile/PersonalInfo",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        datatype: "json",
//        success: function (result) {
//            //alert("LOADED 2nd");
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}