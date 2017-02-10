function kindergartenService(api, appSettings, spinnerService) {
    var self = {};

    self.GetKindergartens = function(model) {
        var param = $.param({
            search: model.search || "",
            number: model.number || 0,
            page: model.page || 1
        });
        return spinnerService.during(api.get(appSettings.GetKindergartens, param));
    }


    self.AddOrder = function (model) {
        var params = $.param({
            address: model.address,
            number: model.number,
        });

        var config = {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        };
        return spinnerService.during(api.post(appSettings, params, config));
    }

    return self;
}