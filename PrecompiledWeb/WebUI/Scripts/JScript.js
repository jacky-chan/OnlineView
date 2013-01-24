/// <reference path="jquery-1.7.1.js" />
//添加按钮显示信息
function btnaddClickShow() {
    $('#MaskDiv').show();
    $('#AddEdit').show();
    $('#btnAdd').show();
    $('#btnEdit').hide();
    $("#AddEdit input[type='text']").val("");
    $("#AddEdit input[type='text']").removeAttr("disabled");
}
//限制只能输入数字
function clearNoNum(obj) {
    //先把非数字的都替换掉，除了数字和.
    obj.value = obj.value.replace(/[^\d.-]/g, "");
    //必须保证第一个为数字而不是.
    obj.value = obj.value.replace(/^\./g, "");
    //保证只有出现一个.而没有多个.
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    obj.value = obj.value.replace(/\-{2,}/g, "-");
    //保证.只出现一次，而不能出现两次以上
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
    obj.value = obj.value.replace("-", "$#$").replace(/\-/g, "").replace("$#$", "-");
}


