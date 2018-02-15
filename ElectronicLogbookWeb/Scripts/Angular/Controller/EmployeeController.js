(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', '$window', 'EmployeeService'];

    function EmployeeController($filter, $window, EmployeeService) {
        var vm = this;

        vm.Employees = [];

        vm.Initialise = Initialise;



        function Initialise() {
            Read();
        }

        function Read() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    UpdateFullName();
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

        function UpdateFullName() {
            angular.forEach(vm.Employees, function (employee) {
                employee.FullName = employee.LastName + ", " + employee.FirstName + " " + employee.MiddleName;
            });
        }
    }
})();