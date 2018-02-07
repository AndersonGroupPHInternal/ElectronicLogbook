(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeLogController', EmployeeLogController);

    EmployeeLogController.$inject = ['$filter', '$window', 'EmployeeLogService'];

    function EmployeeLogController($filter, $window, EmployeeLogService) {
        var vm = this;
        vm.EmployeeLogs = [];
        vm.Employees;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(employeelogId) {
            $window.location.href = '../EmployeeLog/Update/' + employeelogId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
            EmployeeLogService.Read()
                .then(function (response) {
                    vm.EmployeeLogs = response.data;
                    if (vm.EmployeeLogId)
                        UpdateEmployeeLog();
                        //UpdateEmployee();
                })
                .catch(function (data, status)
                {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        function UpdateEmployeeLog()
        {
            vm.EmployeeLogs = $filter('filter')(vm.EmployeeLogs, { EmployeeLogId: vm.EmployeeLogId })[0];
        }
        //function UpdateEmployee(employeelog)
        //{
        //    angular.forEach(vm.EmployeeLogs, function (employeelog) {
        //        employeelog.EmployeeId = $filter('filter')(vm.EmployeeLogs, { EmployeeLogId: employeelog.EmployeeId })[0];
        //    });
        //}

        function Delete(employeeLogId) {
            EmployeeLogService.Delete(employeeLogId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status)
                {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }


    }
})();