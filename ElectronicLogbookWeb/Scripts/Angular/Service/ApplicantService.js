(function () {
    'use strict';

    angular
    .module('App')
    .factory('ApplicantService', ApplicantService);

    ApplicantService.$inject = ['$http'];

    function ApplicantService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(applicant) {
            return $http({
                method: 'POST',
                url: '../Applicant/Create',
                data: {
                    applicant: applicant
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Applicant/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(applicant) {
            return $http({
                method: 'POST',
                url: '../Applicant/Update',
                data: {
                    applicant: applicant
                }
            });
        }

        function Delete(applicant) {
            return $http({
                method: 'POST',
                url: '../Applicant/Delete',
                data: {
                    applicant: applicant
                },
            })
        }

    }
})();