$(function () {

  
    setInterval(function () {


        $.ajax({
            url: "/ThoiGian/DatThoiGian",
            success: function (res) {
                $("h2#clock").html(res)
            }

        })  //cua ajax

    }, 1000);



});