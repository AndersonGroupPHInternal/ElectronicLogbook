(function () {
    'use strict';

    angular
    .module('App')
    .controller('VisitorController', VisitorController);

    VisitorController.$inject = ['VisitorService', '$window', 'EmployeeService', '$filter'];

    function VisitorController(VisitorService, $window, EmployeeService, $filter) {
        var vm = this;

        vm.Visitor;

        vm.Visitors = [];
        vm.Employees = [];
            
        vm.Read = Read;

        vm.GoToUpdatePage = GoToUpdatePage;

        vm.Delete = Delete;

        function Create() {
            vm.Visitor.PersonToVisit = vm.Visitor.PersonToVisita.EmployeeId;
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

        function Read() {
            VisitorService.List()
            .then(function (response) {
                vm.Visitors = response.data;
                ReadEmployees();
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

        function GoToUpdatePage(visitorId) {
            $window.location = '/Visitor/Update/' + visitorId
        }

        //function Read() {
        //    VisitorService.Read()
        //        .then(function (response) {
        //            vm.Visitors = response.data;
        //            ReadEmployees();
        //        })
        //        .catch(function (data, status) {
        //            new PNotify({
        //                title: status,
        //                text: data,
        //                type: 'error',
        //                hide: true,
        //                addclass: "stack-bottomright"
        //            });
        //        });
        //}

        function ReadEmployees() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    UpdatePersonToVisitNames();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function UpdatePersonToVisitNames() {
            angular.forEach(vm.Visitors, function (visitor) {
                visitor.EmployeeToVisit = $filter('filter')(vm.Employees, { EmployeeId: visitor.EmployeeIdToVisit })[0];   
            });
        }


    }
})();