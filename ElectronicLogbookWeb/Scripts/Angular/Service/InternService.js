(function () {
    'use strict';

    angular
    .module('App')
    .factory('InternService', InternService);

    InternService.$inject = ['$http'];

    function InternService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(intern) {
            return $http({
                method: 'POST',
                url: '../Intern/Create',
                data: {
                    intern: intern
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Intern/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(intern) {
            return $http({
                method: 'POST',
                url: '../Intern/Update',
                data: {
                    intern: intern
                }
            });
        }

        function Delete(intern) {
            return $http({
                method: 'POST',
                url: '../Intern/Delete',
                data: {
                    intern: intern
                },
            })
        }
    }
})();