(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeLogController', EmployeeLogController);

    EmployeeLogController.$inject = ['$window', 'EmployeeLogService'];

    function EmployeeLogController($window, EmployeeLogService) {
        var vm = this;
        vm.EmployeeLogs = [];

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

        function Delete(employeelogId) {
            EmployeeLogService.Delete(employeelogId)
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