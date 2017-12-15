(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeLogController', EmployeeLogController);

    EmployeeLogController.$inject = ['$filter', '$window', 'EmployeeLogService'];

    function EmployeeLogController($filter, $window, EmployeeLogService) {
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
                .catch(function (data, status)
                {
               
                });
        }

        function Delete(employeeLogId) {
            EmployeeLogService.Delete(employeeLogId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status)
                {
                    
                });
        }


    }
})();