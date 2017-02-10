function Api($http, $q, appSettings, $window) {
    var api = {};

    api.get = function (url, params) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url + params;
        $http({
            method: 'GET',
            url: apiUrl,
        }).
            success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).
            error(function (data, status) {

                deferred.reject(data);
            });
        return deferred.promise;
    },


    api.post = function (url, params, userConfig) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url;
        var options = {
            method: 'POST',
            url: apiUrl,
            data: params
            //data: JSON.stringify(params),
        }
        var opt = angular.extend(options, userConfig);
        $http(opt).
            success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).
            error(function (data, status) {
                deferred.reject(data);
            });
        return deferred.promise;
    }
    return api;
};
