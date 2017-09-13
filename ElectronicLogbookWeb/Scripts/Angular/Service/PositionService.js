(function () {
    'use strict';

    angular
    .module('App')
    .factory('PositionService', PositionService);

    PositionService.$inject = ['$http'];

    function PositionService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(position) {
            return $http({
                method: 'POST',
                url: '../Position/Create',
                data: {
                    position: position
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Position/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(position) {
            return $http({
                method: 'POST',
                url: '../Position/Update',
                data: {
                    position: position
                }
            });
        }
        function Delete(position) {
            return $http({
                method: 'POST',
                url: '../Position/Delete',
                data: {
                    position: position
                },
            })
        }
    }
})();