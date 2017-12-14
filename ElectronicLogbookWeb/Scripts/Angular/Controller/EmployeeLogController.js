(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeLogController', EmployeeLogController);

    EmployeeLogController.$inject = ['$filter','$window', 'EmployeeLogService'];

    function EmployeeLogController($filter,$window, EmployeeLogService) {
        var vm = this;

        //vm.Employees = [];
        vm.EmployeeLogs = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.UpdateEmployee = UpdateEmployee;

        vm.Delete = Delete;

        function GoToUpdatePage(employeelogid) {
            $window.location.href = '../EmployeeLog/Update/' + employeelogid;
        }

        function Initialise() {
            Read();
            //ReadEmployees();
        }


        function Read() {
            EmployeeLogService.Read()
                .then(function (response) {
                    vm.EmployeeLogs = response.data;
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

        function Delete(employeelogid) {
            EmployeeLogService.Delete(employeelogid)
                .then(function (response) {
                    Read();
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

    }
})();