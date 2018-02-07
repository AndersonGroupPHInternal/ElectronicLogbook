(function () {
    'use strict';

    angular
    .module('App')
    .controller('PeripheralController', PeripheralController);

    PeripheralController.$inject = ['PeripheralService', '$window'];

    function PeripheralController(PeripheralService, $window) {
        var vm = this;

        vm.Peripheral;

        vm.Peripherals = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            PeripheralService.Create(vm.Peripheral)
            .then(function (response) {
                List();
                angular.element('#PeripheralModal').modal('hide');

                new PNotify({
                    title: 'Success',
                    text: 'Peripheral Created',
                    type: 'success',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function CreateModal(peripheral) {
            vm.Peripheral = {
                PeripheralId: 0,
                EmployeeId: '',
                PeripheralColor: 'ffffff',
                PeripheralName: '',
                Description: '',
                SerialNumber: '',
            };
        }
        function List() {
            PeripheralService.List()
            .then(function (response) {
                vm.Peripherals = response.data;
            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function Update() {
            PeripheralService.Update(vm.Peripheral)
            .then(function (response) {
                List();
                angular.element('#PeripheralModal').modal('hide');
            })
            .catch(function (data, status) {
                new PNotify({
                    title: 'Error',
                    text: 'There was an error on loading the list',
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });

            });
        }

        function UpdateModal(peripheral) {
            vm.Peripheral = angular.copy(peripheral);
        }

        function Delete(peripheral) {
            PeripheralService.Delete(peripheral)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(peripheral) {
            $window.location = '/Peripheral/Details/' + peripheral.PeripheralId
        }

    }
})();