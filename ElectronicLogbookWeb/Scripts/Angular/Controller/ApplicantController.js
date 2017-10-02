(function () {
    'use strict';

    angular
    .module('App')
    .controller('ApplicantController', ApplicantController);

    ApplicantController.$inject = ['ApplicantService', '$window'];

    function ApplicantController(ApplicantService, $window) {
        var vm = this;

        vm.Applicant;

        vm.Applicants = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateApplicant = CreateApplicant;
        vm.Update = Update;
        vm.UpdateApplicant = UpdateApplicant;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            ApplicantService.Create(vm.Applicant)
            .then(function (response) {
                List();
                angular.element('#ApplicantModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function CreateApplicant(applicant, timeIn) {
            vm.Applicant = {
                ApplicantID: 0,
                Date: applicant,
                Name: '',
                ApplyingFor: '',
                Designation: '',
                TypeOfId: '',
                IdNumber: '',
                TimeIn: timeIn,
                TimeOut: '',
                Comment: '',
            };
        }

        function List() {
            ApplicantService.List()
            .then(function (response) {
                vm.Applicants = response.data;
            })
            .catch(function (data, status) {
            });
        }

        function Update() {
            ApplicantService.Update(vm.Applicant)
            .then(function (response) {
                List();
                angular.element('#ApplicantModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function UpdateApplicant(applicant) {
            vm.Applicant = angular.copy(applicant);
        }

        function Delete(applicant) {
            ApplicantService.Delete(applicant)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }

        function Details(applicant) {
            $window.location = '/Applicant/Details/' + applicant.ApplicantID
        }

    }
})();