function beExpander(id) {
    $(id + "-area").addClass("hide");
    $(id + "-btn").click(function () {
        $(id + "-area").toggleClass("hide");
    });
}
$(document).ready(function () {
    beExpander("#aaa");
    beExpander("#bbb");
});