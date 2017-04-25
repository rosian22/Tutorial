var ajaxHelper = function () {

    function getWithoutData(url, successCallback, failureCallBack) {
        $.ajax({
            url: url,
            dataType: "html",
            success: successCallback,
            error: failureCallBack
        });
    }

    function get(url, postData, successCallback, failureCallBack) {
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            cache: false,
            data: postData,
            success: successCallback,
            error: failureCallBack
        });
    }

    function getView(url, postData, successCallback, failureCallBack) {
        $.ajax({
            url: url,
            dataType: "html",
            type: "GET",
            async: true,
            cache: false,
            data: postData,
            success: successCallback,
            error: failureCallBack
        });
    }

    function post(url, postData, successCallback, failureCallBack) {
        var options = {
            type: "POST",
            url: url,
            data: JSON.stringify(postData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successCallback,
            failure: failureCallBack
        };
        debugger;
        $.ajax(options);
    }

    function postWithoutData(url, successCallback, failureCallBack) {
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successCallback,
            failure: failureCallBack
        });
    }

    function postFile(url, formData, successCallback, failureCallBack) {
        $.ajax({
            type: "POST",
            url: url,
            data: formData,
            dataType: "json",
            contentType: false,
            processData: false,
            success: successCallback,
            failure: failureCallBack
        });
    }

    return {
        getView: getView,
        get: get,
        getWithoutData: getWithoutData,
        post: post,
        postWithoutData: postWithoutData,
        postFile: postFile
    };
}();
