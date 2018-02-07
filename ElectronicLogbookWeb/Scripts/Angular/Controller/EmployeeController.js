(function () {
    'use strict';

    angular
    .module('App')
    .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['EmployeeService', '$window'];

    function EmployeeController(EmployeeService,$window) {
        var vm = this;

        vm.Employee;

        vm.Employees = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            EmployeeService.Create(vm.Employee)
            .then(function (response) {
                List();
                angular.element('#EmployeeModal').modal('hide');

                new PNotify({
                    title: 'Success',
                    text: 'Employee Created',
                    type: 'success',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function CreateModal(employee) {
            vm.Employee = {
                EmployeeId: 0,
                CompanyId: '',
                PositionId: '',
                EmployeeColor: 'ffffff',
                EmployeeNumber: '',
                FirstName: '',
                LastName: '',
                MiddleName: '',
            };
        }

        function List() {
            EmployeeService.List()
            .then(function (response) {
                vm.Employees = response.data;
            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function Update() {
            EmployeeService.Update(vm.Employee)
            .then(function (response) {
                List();
                angular.element('#EmployeeModal').modal('hide');
            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function UpdateModal(employee) {
            vm.Employee = angular.copy(employee);
        }

        function Delete(employee) {
            EmployeeService.Delete(employee)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(employee) {
            $window.location = '/Employee/Details/' + employee.EmployeeId
        }


    }
})();