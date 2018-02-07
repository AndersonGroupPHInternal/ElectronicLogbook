(function () {
    'use strict';

    angular
        .module('App')
        .factory('EmployeeLogService', EmployeeLogService);

    EmployeeLogService.$inject = ['$http'];

    function EmployeeLogService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/EmployeeLog/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(EmployeeLogId) {
            return $http({
                method: 'DELETE',
                url: '/EmployeeLog/Delete/' + EmployeeLogId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }   
    }
})();