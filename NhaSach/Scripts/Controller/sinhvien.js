
$(function () {

    
          //Khi bàn phím được nhấn và thả ra thì sẽ chạy phương thức này
     // $("#frmsv").validate({
  //            rules: {
   //               TenSV: "required"//,
                  /*email: {
                      required: true,
                      email: true
                  },
                  password: {
                      required: true,
                      minlength: 6,
                      maxlength: 15
                  },
                  checkbox: "required"*/
         //     },
          //    messages: {
          //        TenSV: "Vui lòng nhập tên!"//,
                  /*email: {
                      required: "Vui lòng nhập vào email",
                      email: "Nhập đúng định dạng email đê :D"
                  },
                  password: {
                      required: "Vui lòng nhập mật khẩu!",
                      minlength: "Độ dài tối thiểu 6 kí tự",
                      maxlength: "Độ tài tối đa 15 kí tự"
                  },
                  checkbox: "Xác nhận Admin "*/
             // }
       //   });
   

    $("#txtsearch").keyup(function () {


        var search = $("#txtsearch").val();//Lay chu trong o text box
        var SetData = $("#result"); 
        SetData.html("");//Xóa trong các hlmt trong vùng tbody co id là #result


        $.ajax({
            url: "/sinhvien/Search",

            data: { TenSV: search },

            contentType: "html",

            success: function (response) {
              

                $(response).each(function (i, e) {
                    var Data = "<tr>" +
                                  "<td>" + e.sv_id + "</td>" +
                                  "<td>" + e.TenSV + "</td>" +
                                  "<td><a href=/sinhvien/Edit/"+e.sv_id+">Sửa</a></td>"+
                                  "<td><a href=/sinhvien/Delete/" + e.sv_id + ">Xóa</a></td>" +
                                  "</tr>";
                    SetData.append(Data);
               

                   
                });

              console.log(response)

            }
            


        });

    });


});