function loadContent(containerId, partialView) {
    $(containerId).html(partialView);
    $("#studentTable").hide();
}
function getStudentsPage(activeTab, page) {
    var containerId;
    switch (activeTab) {
        case 0:
            containerId = "#pending-students";
            break;
        case 1:
            containerId = "#active-students";
            break;
        case 2:
            containerId = "#declined-students";
            break;
    }

    var data = {
        activeTab: activeTab,
        page: page - 1
    };
    data = appendFilterParams(data);
    var url = employeeBaseUrl + "Paginate?" + $.param(data);
    $("#loading").show();
    ajaxHelper.getWithoutData(url, function (partialView) {
        loadContent(containerId, partialView);
    }, onFilterFail);
}