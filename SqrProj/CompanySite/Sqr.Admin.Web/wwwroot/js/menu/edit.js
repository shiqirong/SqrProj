﻿$(function () {
    var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
    //关闭iframe
    $('#btnClose').click(function () {
        parent.layer.close(index);
    });
    $("#btnSave").on("click", function () {
        $("#ajaxForm").ajaxSubmit({
            beforeSubmit: function () {
                console.log("before submit...");
                // alert("我在提交表单之前被调用！");
            },
            success: function (data) {
                console.log("successful");
                //alert("我在提交表单成功之后被调用");
                if (typeof (data) == "string") {
                    data = eval('(' + data + ')');
                    //alert(data); object

                    console.log(data);
                } else {
                    console.log(data);
                }

            }
        });
        return false;
    });
})

