(function () {
    'use strict';

    angular
    .module('App')
    .factory('PeripheralService', PeripheralService);

    PeripheralService.$inject = ['$http'];

    function PeripheralService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(peripheral) {
            return $http({
                method: 'POST',
                url: '../Peripheral/Create',
                data: {
                    peripheral: peripheral
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Peripheral/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(peripheral) {
            return $http({
                method: 'POST',
                url: '../Peripheral/Update',
                data: {
                    peripheral: peripheral
                }
            });
        }
        function Delete(peripheral) {
            return $http({
                method: 'POST',
                url: '../Peripheral/Delete',
                data: {
                    peripheral: peripheral
                },
            })
        }
    }
})();