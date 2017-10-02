(function () {
    'use strict';

    angular
    .module('App')
    .controller('InternHistoryController', InternHistoryController);

    InternHistoryController.$inject = ['InternHistoryService', '$window'];

    function InternHistoryController(InternHistoryService, $window) {
        var vm = this;

        vm.InternHistory;

        vm.InternHistories = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateInternHistory = CreateInternHistory;
        vm.Update = Update;
        vm.UpdateInternHistory = UpdateInternHistory;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            InternHistoryService.Create(vm.InternHistory)
            .then(function (response) {
                List();
                angular.element('#InternHistoryModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function CreateInternHistory(internHistory, timeIn) {
            vm.InternHistory = {
                InternHistoryID: 0,
                Date: internHistory,
                Name: '',
                School: '',
                Department: '',
                IdNumber: '',
                TimeIn: timeIn,
                TimeOut: '',
            };
        }

        function List() {
            InternHistoryService.List()
            .then(function (response) {
                vm.InternHistories = response.data;
            })
            .catch(function (data, status) {
            });
        }

        function Update() {
            InternHistoryService.Update(vm.InternHistory)
            .then(function (response) {
                List();
                angular.element('#InternHistoryModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function UpdateInternHistory(internHistory) {
            vm.InternHistory = angular.copy(internHistory);
        }

        function Delete(internHistory) {
            InternHistoryService.Delete(internHistory)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }

        function Details(internHistory) {
            $window.location = '/InternHistory/Details/' + internHistory.InternHistoryID
        }
    }
})();