var create_get = function (url) {
    $("#content").empty();
    $("#content").load(url, function () {
        $("#mymodal").modal("show");
    })
}


function del(id, name, url) {
    if (confirm("هل انت متاكد من حذف " + name)) {
        $.ajax({
            type: "POST",
            url: url + "?id=" + id,
            success: function () {
                $("#row_" + id).css("background-color", "#ff6347").fadeOut(800, function () {
                    $(this).remove();
                });
            }
        })
    }
}

var edit_get = function (id, url) {
    $("#content").empty();
    var url = url + "?id=" + id;
    $("#content").load(url, function () {
        $("#mymodal").modal("show");
    })
}

var post = function (url_get) {
    //$("#error").empty();
    //if ($("#mname").val() == "") {
    //    alert("ادخل قيمه ");
    //    return
    //}
    var data = $("#create").serialize();
    $.ajax({
        url: url_get,
        type: "POST",
        data: data,
        success: function () {
            $("#mymodal").modal("hide");
            location.reload();
        }
    });
}

var idfordel = 0;
var del_get = function (id, name) {
    $("#content2").empty();
    $("#content2").append("<p> هل تريد حذف " + name + "?</p>")
    $("#mymodal2").modal("show");
    idfordel = id
}
var del_post = function (url_post_d) {
    $.ajax({
        type: "POST",
        url: url_post_d + "?id=" + idfordel,
        success: function () {
            $("#row_" + idfordel).remove();
            $("#mymodal2").modal("hide");
        }
    })
}

var check = function (id) {

    if ($("#" + id).is(":checked")) {
        if ($("#_" + id).val() == 0)
            $("#_" + id).val(1);
    }
    else
        $("#_" + id).val(0);
}

var post_cd = function (url_post, url_desti, id) {
    $("#error").empty();
    var data = $("#myform").serializeArray();
    var drink_val = [];
    var counts = [];
    for (var i = 1; i < id; i++) {
        drink_val.push($("#" + i).is(":checked"));
        counts.push($("#_" + i).val());
    }
    $.ajax({
        type: "POST",
        data: data,
        url: url_post + "?values=" + drink_val + "&&" + "counts=" + counts,
        success: function (ok) {
            if (ok) {
                $("#mymodal").modal("hide");
                window.location.href = url_desti;
            }
            else {
                $("#error").append("<p> يوجد خطا من فضلك تاكد من ادخال الحقول </p>");
            }
        }
    });
}
//--------------------------LayoutPage----------------------------------
function AddBrands() {
    $.ajax({
        url: "/Home/Brand",
        type: "POST",
        success: function (brandname) {
            if (brandname != "") {
                $(".brand").append(brandname);
                $("#brandremove").css("display", "unset");
            } else {
                create_get("/Home/Create");
                $("#tap").click(function (e) {
                    e.preventDefault();
                })
            }
        }
    });
}
function Remove() {
    var resualt = confirm("هل انت متاكد من حذف البيانات مثل اسم المحل واسم صاحب المحل وبعض البيانات الخاصه ");
    if (resualt) {
        $.ajax({
            url: "/Home/RemoveBrand",
            type: "POST",
            success: function (data) {
                if (data != "") {
                    alert("تم الحذف بنجاح");
                    location.reload();
                } else {
                    alert("لا يمكن الحذف");
                }
            }
        });
    }
}



//---------------------------------------------OperationController---------------------------------------------------
var less = function (url) {
    var doc = prompt("اكتب رقم لايجاد العناصر", "2");
    if (doc != "") {
        $("#content").empty();
        var url = url + "?number=" + doc;
        $("#content").load(url, function () {
            $("#mymodal").modal("show");
        })
    }
}
var getdata = function (url) {
    $("#content").empty();
    $("#content").load(url, function () {
        $("#mymodal").modal("show");
    })
}
function billwithnumber(url) {
    var doc = prompt("اكتب رقم لايجاد الفاتوره", "1");
    if (doc != "") {
        $("#content").empty();
        var url = url + "?id=" + doc;
        $("#content").load(url, function () {
            $("#mymodal").modal("show");
        })
    }
}
function dept(url) {
    $("#content").empty();
    $("#content").load(url, function () {
        $("#mymodal").modal("show");
    });
}
function restore(url) {
    var result = confirm("هل متاكد سيتم حذف الفواتير المدفوعه نهائيا !!!!");
    if (result) {
        $.ajax({
            url: url,
            type: "POST",
            success: function () {
                alert("تم التنفيذ بنجاح");
            }, error: function () {
                alert("حدث خطا");
            }
        });
    }
}
function gard() {
    $("#content").empty();
    var date1 = $("#date1").val(),
        date2 = $("#date2").val(),
        url = "/Operations/CalcBilsWithDate" + "?date=" + date1 + "&&date2=" + date2;
    $("#content").load(url, function () {
        $("#mymodal").modal("show");
    });
}
function backup(url) {
    var result = confirm("هل انت متاكد من عمل نسخه احتياطيه");
    if (result) {
        $.ajax({
            url: url,
            type: "POST",
            success: function () {
                alert("تم التنفيذ بنجاح");
            }, error: function () {
                alert("حدث خطا");
            }
        });
    }
}
//-------------------------------------------------------Items/Index---------------------------------------------------------------------------