(function () {
    'use strict';

    angular
    .module('App')
    .factory('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['$http'];

    function EmployeeService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(employee) {
            return $http({
                method: 'POST',
                url: '../Employee/Create',
                data: {
                    employee: employee
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Employee/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(employee) {
            return $http({
                method: 'POST',
                url: '../Employee/Update',
                data: {
                    employee: employee
                }
            });
        }
        function Delete(employee) {
            return $http({
                method: 'POST',
                url: '../Employee/Delete',
                data: {
                    employee: employee
                },
            })
        }

    }
})();