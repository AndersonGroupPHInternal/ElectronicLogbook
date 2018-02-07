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
        vm.CreateVisitor = CreateVisitor;
        vm.Update = Update;
        vm.UpdateVisitor = UpdateVisitor;
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

        function CreateVisitor(visitor, timeIn) {
            vm.Visitor = {
                VisitorID: 0,
                Date: visitor,
                Name: '',
                CompanyName: '',
                Purpose: '',
                PersonToVisit: '',
                Designation: '',
                KindOfId: '',
                IdNumber: '',
                TimeIn: timeIn,
                TimeOut: '',
                Comment: '',
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

        function UpdateVisitor(visitor) {
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