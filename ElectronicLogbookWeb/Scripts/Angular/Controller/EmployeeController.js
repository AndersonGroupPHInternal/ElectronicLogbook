(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', '$window', 'EmployeeService'];

    function EmployeeController($filter, $window, EmployeeService) {
        var vm = this;

        vm.Employee;
        vm.EmployeeId;
        vm.Employees = [];

        vm.Initialise = Initialise;

        function Initialise(employeeId) {
            vm.EmployeeId = employeeId;
            Read();            
        }

        function Read() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;                    
                    UpdateFullName();
                    vm.Employee = $filter('filter')(vm.Employees, { EmployeeId: vm.EmployeeId })[0];
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