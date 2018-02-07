(function () {
    'use strict';

    angular
    .module('App')
    .factory('VisitorHistoryService', VisitorHistoryService);

    VisitorHistoryService.$inject = ['$http'];

    function VisitorHistoryService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(visitorHistory) {
            return $http({
                method: 'POST',
                url: '../VisitorHistory/Create',
                data: {
                    visitorHistory: visitorHistory
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../VisitorHistory/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(visitorHistory) {
            return $http({
                method: 'POST',
                url: '../VisitorHistory/Update',
                data: {
                    visitorHistory: visitorHistory
                }
            });
        }

        function Delete(visitorHistory) {
            return $http({
                method: 'POST',
                url: '../VisitorHistory/Delete',
                data: {
                    visitorHistory: visitorHistory
                },
            })
        }
    }
})();