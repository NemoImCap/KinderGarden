function childrenService(api, appSettings, spinnerService) {
    var self = {};

    self.GetChildren = function (model) {
        var param = $.param({
            gartenId: model.gartenId || 0,
            search: model.search || "",
            age: model.number || 0,
            page: model.page || 1,
            gartenNumber: model.gartenNumber || 0
        });
        var promise = spinnerService.during(api.get(appSettings.GetChildren, param));
        return promise;
    }


    self.CreateChild = function (model) {
        var promise = spinnerService.during(api.post(appSettings.CreateChild, model));
        return promise;
    }

    self.DeleteChild = function (model) {
        var promise = spinnerService.during(api.post(appSettings.DeleteChild, model.Id));
        return promise;
    }

    self.UpdateChild = function (model) {
        var promise = spinnerService.during(api.post(appSettings.UpdateChild, model));
        return promise;
    }

    return self;
}