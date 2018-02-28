(function () {
    'use strict';

    angular
        .module('App')
        .factory('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['$http'];

    function EmployeeService($http) {
        return {
            Read: Read,
            ReadSelectedEmployee: ReadSelectedEmployee,
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Employee/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
        function ReadSelectedEmployee(employeeId) {
            return $http({
                method: 'POST',
                url: '/Department/ReadSelectedEmployee/' + employeeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();