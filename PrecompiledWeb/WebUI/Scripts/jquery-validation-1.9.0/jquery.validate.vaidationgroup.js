var opts = null;
var isValidationGroup = true;
//初始化分组验证
function InitValidationGroup() {
    $('.validationGroup .causesValidation').click(Validate);

    $('.validationGroup :text').keydown(function(evt) {
        if (evt.keyCode == 13) {
            var $nextInput = $(this).nextAll(':input:first');

            if ($nextInput.is(':submit')) {
                Validate(evt);
            }
            else {
                evt.preventDefault();
                $nextInput.focus();
            }
        }
    });
}

function Validate(evt) {
    var $group = $(this).parents('.validationGroup');
  
    var isValid = true;

    $group.find(':input').each(function(i, item) {
        if (!$(item).valid())
            isValid = false;
    });

    if (!isValid)
        evt.preventDefault();
}

