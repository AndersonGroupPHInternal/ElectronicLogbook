(function () {
    'use strict';

    angular
        .module('App')
        .controller('WebcamController', WebcamController);

    WebcamController.$inject = ['WebcamService'];

    function WebcamController(WebcamService) {
        var vm = this;

        vm.showweb = false;
        vm.webcam = WebcamService.webcam;
        //override function for be call when capture is finalized
        vm.webcam.success = function (image, type) {
            vm.photo = image;
            vm.fotoContentType = type;
            vm.showweb = false;
        };

        function turnOffWebCam() {
            if (vm.webcam && vm.webcam.isTurnOn === true)
                vm.webcam.turnOff();
        }
    }
})();