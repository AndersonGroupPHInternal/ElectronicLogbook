(function () {
    'use strict';

    angular
    .module('App')
    .controller('PositionController', PositionController);

    PositionController.$inject = ['PositionService', '$window'];

    function PositionController(PositionService, $window) {
        var vm = this;

        vm.Position;

        vm.Positions = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            PositionService.Create(vm.Position)
            .then(function (response) {
                List();
                angular.element('#PositionModal').modal('hide');

                new PNotify({
                    title: 'Success',
                    text: 'Position Created',
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

        function CreateModal(position) {
            vm.Position = {
                PositionId: 0,
                PositionName: '',
                PositionColor: 'ffffff',
            };
        }

        function List() {
            PositionService.List()
            .then(function (response) {
                vm.Positions = response.data;
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
            PositionService.Update(vm.Position)
            .then(function (response) {
                List();
                angular.element('#PositionModal').modal('hide');
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

        function UpdateModal(position) {
            vm.Position = angular.copy(position);
        }

        function Delete(position) {
            PositionService.Delete(position)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(position) {
            $window.location = '/Position/Details/' + position.PositionId
        }
    }
})();