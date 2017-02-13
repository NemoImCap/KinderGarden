function kindergartenService(api, appSettings, spinnerService) {
    var self = {};

    self.GetKindergartens = function(model) {
        var param = $.param({
            search: model.search || "",
            number: model.number || 0,
            page: model.page || 1
        });
        var promise = spinnerService.during(api.get(appSettings.GetKindergartens, param));
        return promise;
    }


    self.CreateKindergarten = function (model) {
        var promise = spinnerService.during(api.post(appSettings.CreateKindergarten, model));
        return promise;
    }

    self.DeleteKindergarten = function(model) {
        var promise = spinnerService.during(api.post(appSettings.DeleteKindergarten, model.Id));
        return promise;
    }

    self.UpdateKindergarten = function (model) {
        var promise = spinnerService.during(api.post(appSettings.UpdateKindergarten, model));
        return promise;
    }

    return self;
}