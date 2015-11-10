RDE.factory('ErrorHandlingService', function ($http, $modal, modalServices) {
    var handleError = function (data, statusCode) {
        var settings = modalServices.errorModal;
        settings.resolve = {
            data: function () {
                return data;
            }
        };

        switch (statusCode)
        {
            case 400: {
                $modal.open(settings);
                break;
            }
            case 401: {
                data.Message = "Authentication failed. Please log in the system.";
                $modal.open(settings);
                break;
            }
            default: break;
        }
    };

    return {
        handleError: handleError
    };
});