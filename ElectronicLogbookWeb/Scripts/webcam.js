(function () {
    var video = document.getElementById('video'),
        vendorUrl = window.URL || window.webkitURL;

    var canvas = document.getElementById('canvas'),
        context = canvas.getContext('2d');


    navigator.getMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;

    navigator.getMedia({
        video: true,
        audio: false
    }, function (stream) {
        video.src = vendorUrl.createObjectURL(stream);
        video.play();
    }, function (error) {
        //code for error display is placed here
    });

    document.getElementById('capture').addEventListener('click', function () {

        var appImage = context.drawImage(video, 0, 0, 380, 325);

        document.getElementById("upload").innerHTML = appImage;
    });


    function download() {
        var image = canvas.toDataURL();
        this.href = image;
    }
    document.getElementById('save').addEventListener('click', download, false);
})();
