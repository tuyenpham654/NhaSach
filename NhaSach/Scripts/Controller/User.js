///Các sự kiện
$(function () {

   
    $("#txtsearch").keyup(function () {
        loadData();
    });


    $("#fileUpload").change(function () {

        var data = new FormData();
        var files = $("#fileUpload").get(0).files;
        if (files.length > 0) {
            data.append("HelpSectionImages", files[0]);
        }
        var id=$("#UserName").val()
        $.ajax({
            url: "/User/UploadImage/"+id,
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                //code xử lý dữ liệu trả về của bạn
                var imgsrc = '/Upload/Images/Users/' + response.FileName;
                $("#Photo").attr({ value: response.FileName });
                $("#imgpreview").attr({ src: imgsrc });
            },
            error: function (er) {
                alert(er);
            }

        });
    });
   
   

});
//end các sự kiện


///Các hàm
function loadData() {
    var search = $("#txtsearch").val();
    var SetData = $("#result");
    SetData.html("");

    $.ajax({
        url: "/User/Search",
        data: { Name: search },
        contentType: "html",
        success: function (response) {


            $(response).each(function (i, e) {
                var Data = "<tr>" +
                             "<td><img style='width:50px;height:50px;'" + "src=/Upload/Images/Users/" + e.Photo + " /></td>" +
                              "<td>" + e.Name + "</td>" +
                              "<td>" + e.UserName + "</td>" +
                               "<td>" + e.Password + "</td>" +
                               '<td><a href="#" onclick="getbyID(' + e.ID + ')">Sửa</a> | <a href="#" onclick="Delele(' + e.ID + ')">Xóa</a></td>' +

                            "</tr>";
                SetData.append(Data);
            });


        }



    });


}

function Add() {

    if (!document.forms["frmuser"].checkValidity()) return false;

        var objUser = {
            ID: $("#ID").val(),
            Name: $("#Name").val(),
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
            Photo: $("#Photo").val(),
            GroupID: $("#GroupID").val()

        };


        $.ajax({
            url: "/User/Add",
            type: "POST",
            data: JSON.stringify(objUser),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert("Lưu thành công");
                $('#myModal').modal('hide');
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }



        });
    

}
//function for updating employee's record
function Update() {

    if (!document.forms["frmuser"].checkValidity()) return false;

    var objUser = {
        ID: $("#ID").val(),
        Name: $("#Name").val(),
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),
        Photo: $("#Photo").val(),
        GroupID: $("#GroupID").val()
        
    };

    $.ajax({
        url: "/User/Update",
        data: JSON.stringify(objUser),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
       
            alert("Lưu thành công");
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#Name').val("");
            $('#UserName').val("");
            $('#Password').val("");          
            var imgsrc = '/Upload/Images/Users/noimg.jpg';
            $("#imgpreview").attr({ src: imgsrc });           
            loadData();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(ID) {
    var ans = confirm("Bạn có muốn xóa dòng này không?");
    if (ans) {
        $.ajax({
            url: "/User/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function getbyID(ID) {


    $("#ID").css('border-color', 'lightgrey');
    $("#Name").css('border-color', 'lightgrey');
    $("#UserName").css('border-color', 'lightgrey');
    $("#Password").css('border-color', 'lightgrey');
    $("#Photo").css('border-color', 'lightgrey');
    $("#GroupID").css('border-color', 'lightgrey');

    $.ajax({
        url: "/User/getbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("#ID").val(result.ID);
            $("#Name").val(result.Name);
            $("#UserName").val(result.UserName);
            $("#Password").val(result.Password);
            $("#Photo").val(result.Photo);
            $("#GroupID").val(result.GroupID);        
            console.log(result.GroupID);
            var imgsrc = '/Upload/Images/Users/' + result.Photo;
            $("#imgpreview").attr({ src: imgsrc });

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}



///Xóa các text boox
function clearTextBox() {
   
    $('#ID').val("");
    $('#Name').val("");
    $('#UserName').val("");
    $('#Password').val("");
    var imgsrc = '/Upload/Images/Users/noimg.jpg';
    $("#imgpreview").attr({ src: imgsrc });
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

//End các hàm


    





