"use strict"; var ngHelperBusy = angular.module("ngHelperBusy", []); ngHelperBusy.directive("ngHelperBusy", ["$busy", function (a) { return { template: '<div id="ngHelperBusyLayer"><div class="wrapper"><div class="loader"></div><div class="message">{{busyMessage}}</div></div></div>', restrict: "CEA", scope: !0, controller: "NgHelperBusyCtrl" } }]), ngHelperBusy.controller("NgHelperBusyCtrl", ["$scope", "$rootScope", "$busy", function (a, b, c) { var d = "Please stay tuned..."; a.busyMessage = d, b.$on("$busy.setMessage", function () { a.busyMessage = c.getBusyMessage() }), b.$on("$busy.resetMessage", function () { a.busyMessage = d }) }]), ngHelperBusy.service("$busy", ["$q", "$rootScope", function (a, b) { var c = this, d = null; c.getBusyMessage = function () { return d }, c.setMessage = function (a) { d = a, b.$emit("$busy.setMessage") }, c.resetMessage = function () { d = null, b.$emit("$busy.resetMessage") }, c.during = function (b) { var d = a.defer(); return c.beBusy(), a.when(b).then(function (a) { c.beFree(), d.resolve(a) }, function (a) { c.beFree(), d.reject(a) }, function (a) { d.notify(a) }), d.promise }, c.beBusy = function () { var a = document.getElementById("ngHelperBusyLayer"); null !== a && void 0 !== a && a.classList.add("busy"); var b = document.getElementsByTagName("body")[0]; null !== b && void 0 !== b && b.classList.add("ngHelperBusyLayerNoScroll") }, c.beFree = function () { var a = document.getElementById("ngHelperBusyLayer"), b = document.getElementsByTagName("body")[0]; null !== a && void 0 !== a && a.classList.remove("busy"), null !== b && void 0 !== b && b.classList.remove("ngHelperBusyLayerNoScroll"), c.resetMessage() } }]);