(function () {
    'use strict';

    angular
    .module('App')
    .factory('VisitorService', VisitorService);

    VisitorService.$inject = ['$http'];

    function VisitorService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(visitor) {
            return $http({
                method: 'POST',
                url: '../Visitor/Create',
                data: {
                    visitor: visitor
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Visitor/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(visitor) {
            return $http({
                method: 'POST',
                url: '../Visitor/Update',
                data: {
                    visitor: visitor
                }
            });
        }

        function Delete(visitor) {
            return $http({
                method: 'POST',
                url: '../Visitor/Delete',
                data: {
                    visitor: visitor
                },
            })
        }

    }
})();