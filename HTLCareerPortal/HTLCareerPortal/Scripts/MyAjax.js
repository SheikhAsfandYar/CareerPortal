
$(document).ready(function () {
    AOS.init();

});
var loadFile = function (event) {
    var output = document.getElementById('output');
    output.src = URL.createObjectURL(event.target.files[0]);
};

$(function () {
    $('.option').change(function () {
        if ($(this).val() == "false") {
            $('.js-div').hide();
        }
        else
            $('.js-div').show();
    });
    $('.option1').change(function () {
        if ($(this).val() == "false") {
            $('.js-div1').hide();
        }
        else
            $('.js-div1').show();
    });
    $('.option2').change(function () {
        if ($(this).val() == "false") {
            $('.js-div2').hide();
        }
        else
            $('.js-div2').show();
    });
   
});

$(document).ready(function () {

            $('.js-div').hide();
            $('.js-div1').hide();
            $('.js-div2').hide();
    if ($('.option').val() == "true" )
    {
        $('.js-div').show();
       
    }
     if ( $('.option1').val() == "true" )
    {
        $('.js-div1').show();
    }
     if ($('.option2').val() == "true") {
        $('.js-div2').show();
    }
    //else {
    //            $('.js-div').hide();
    //            $('.js-div1').hide();
    //            $('.js-div2').hide();
    //        }

       
});

