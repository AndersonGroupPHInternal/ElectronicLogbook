(function () {
    'use strict';

    angular
    .module('App')
    .controller('VisitorController', VisitorController);

    VisitorController.$inject = ['VisitorService', '$window'];

    function VisitorController(VisitorService, $window) {
        var vm = this;

        vm.Visitor;

        vm.Visitors = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            VisitorService.Create(vm.Visitor)
            .then(function (response) {
                List();
                angular.element('#VisitorModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function CreateModal(visitor) {
            vm.Visitor = {
                VisitorID: 0,
                Date: '',
                Name: '',
                CompanyName: '',
                Purpose: '',
                PersonToVisit: '',
                IdNumber: '',
                TimeIn: '',
                TimeOut: '',
            };
        }

        function List() {
            VisitorService.List()
            .then(function (response) {
                vm.Visitors = response.data;
            })
            .catch(function (data, status) {
            });
        }

        function Update() {
            VisitorService.Update(vm.Visitor)
            .then(function (response) {
                List();
                angular.element('#VisitorModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function UpdateModal(visitor) {
            vm.Visitor = angular.copy(visitor);
        }

        function Delete(visitor) {
            VisitorService.Delete(visitor)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }

        function Details(visitor) {
            $window.location = '/Visitor/Details/' + visitor.VisitorID
        }
    }
})();