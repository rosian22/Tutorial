var studentModule = function () {

    function filterStudents() {
        
        var selectedItemId = $("select.filterable-select").val();
        window.location.href = "/Student/GetStudentsBySubjectId?subjectId=" + selectedItemId;

    }

    return {
        filterStudents: filterStudents
    };
}();
       
