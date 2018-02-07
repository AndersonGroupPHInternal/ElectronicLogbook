(function () {
    'use strict';

    angular
    .module('App')
    .controller('VisitorHistoryController', VisitorHistoryController);

    VisitorHistoryController.$inject = ['VisitorHistoryService', '$window'];

    function VisitorHistoryController(VisitorHistoryService, $window) {
        var vm = this;

        vm.VisitorHistory;

        vm.VisitorHistories = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateVisitorHistory = CreateVisitorHistory;
        vm.Update = Update;
        vm.UpdateVisitorHistory = UpdateVisitorHistory;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            VisitorHistoryService.Create(vm.VisitorHistory)
            .then(function (response) {
                List();
                angular.element('#VisitorHistoryModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function CreateVisitorHistory(visitorHistory, timeIn) {
            vm.VisitorHistory = {
                VisitorHistoryID: 0,
                Date: visitorHistory,
                Name: '',
                Purpose: '',
                TimeIn: timeIn,
                TimeOut: '',
            };
        }

        function List() {
            VisitorHistoryService.List()
            .then(function (response) {
                vm.VisitorHistories = response.data;
            })
            .catch(function (data, status) {
            });
        }

        function Update() {
            VisitorHistoryService.Update(vm.VisitorHistory)
            .then(function (response) {
                List();
                angular.element('#VisitorHistoryModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function UpdateVisitorHistory(visitorHistory) {
            vm.VisitorHistory = angular.copy(visitorHistory);
        }

        function Delete(visitorHistory) {
            VisitorHistoryService.Delete(visitorHistory)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }

        function Details(visitorHistory) {
            $window.location = '/VisitorHistory/Details/' + visitorHistory.VisitorHistoryID
        }
    }
})();