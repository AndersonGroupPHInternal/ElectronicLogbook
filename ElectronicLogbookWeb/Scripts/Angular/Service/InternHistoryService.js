(function () {
    'use strict';

    angular
    .module('App')
    .factory('InternHistoryService', InternHistoryService);

    InternHistoryService.$inject = ['$http'];

    function InternHistoryService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(internHistory) {
            return $http({
                method: 'POST',
                url: '../InternHistory/Create',
                data: {
                    internHistory: internHistory
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../InternHistory/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(internHistory) {
            return $http({
                method: 'POST',
                url: '../InternHistory/Update',
                data: {
                    internHistory: internHistory
                }
            });
        }

        function Delete(internHistory) {
            return $http({
                method: 'POST',
                url: '../InternHistory/Delete',
                data: {
                    internHistory: internHistory
                },
            })
        }
    }
})();