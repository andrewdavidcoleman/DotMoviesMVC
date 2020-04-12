
function StarOnClick(id, saveUrl, deleteUrl, element, event) {

    const url = $(element).hasClass('saved') ? deleteUrl : saveUrl;
    $.post(url, { id }, function () {
        $(element).toggleClass('saved');
    });

}