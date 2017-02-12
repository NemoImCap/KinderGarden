﻿function Api($http, $q, appSettings, $window) {
    var api = {};

    api.get = function (url, params) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url + params;
            $http({
                method: 'GET',
                url: apiUrl,
            }).then(function (response) {
                deferred.resolve(response);
                },
                function(response) {
                    deferred.reject(response);
                });
        return deferred.promise;
    },


    api.post = function (url, params, userConfig) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url;
        var options = {
            method: 'POST',
            url: apiUrl,
            //data: params
            data: JSON.stringify(params),
            headers: {
                'Content-Type': 'application/json'
            }
        }
        var opt = angular.extend(options, userConfig);
        $http(opt)
           .then(function (response) {
               deferred.resolve(response);
           },
                function(response) {
                    deferred.reject(response);
                });
        return deferred.promise;
    }
    return api;
};
