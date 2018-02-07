(function () {
    'use strict';

    angular
    .module('App')
    .controller('InternController', InternController);

    InternController.$inject = ['InternService', '$window'];

    function InternController(InternService, $window) {
        var vm = this;

        vm.Intern;

        vm.Interns = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateIntern = CreateIntern;
        vm.Update = Update;
        vm.UpdateIntern = UpdateIntern;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            InternService.Create(vm.Intern)
            .then(function (response) {
                List();
                angular.element('#InternModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function CreateIntern(intern, timeIn) {
            vm.Intern = {
                InternID: 0,
                Date: intern,
                Name: '',
                School: '',
                Department: '',
                Supervisor: '',
                IdNumber: '',
                TimeIn: timeIn,
                TimeOut: '',
            };
        }

        function List() {
            InternService.List()
            .then(function (response) {
                vm.Interns = response.data;
            })
            .catch(function (data, status) {
            });
        }

        function Update() {
            InternService.Update(vm.Intern)
            .then(function (response) {
                List();
                angular.element('#InternModal').modal('hide');
            })
            .catch(function (data, status) {
            });
        }

        function UpdateIntern(intern) {
            vm.Intern = angular.copy(intern);
        }

        function Delete(intern) {
            InternService.Delete(intern)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }

        function Details(intern) {
            $window.location = '/Intern/Details/' + intern.InternID
        }



    }
})();