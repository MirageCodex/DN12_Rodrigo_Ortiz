function onButtonClic(event) {
    ///////////////////////////
    var b = event.currentTarget;
    //var buttonName = b.getAttribute("name");
    //debugger;
    //alert("Click on: " + buttonName);

    var classes = b.classList;
    var isGreen = false;

    for (var i = 0; i < classes.length; i++) {
        var c = classes[i];
        if (c == "greenButton") {
            isGreen = true;
            break;
            //debugger;
        }
        
    }
    if (isGreen) {
        b.className = "btn redButton"
    } else {
        b.className = "btn greenButton"
    }
    var t = document.getElementById("sampleTable");
    var currentHtml = t.innerHTML;
    t.innerHTML += "<tr><td>" + b.getAttribute("name") + "</td><td>" + moment(new Date()).format("DD-MM-YYYY HH:mm:ss") + "</td></tr>";
    /////////////////////////////////
}
var buttons = document.getElementsByTagName("button");
//var button = document.getElementById("button1");
//var button = document.getElementsByName("testButton")[0];
//var button = document.getElementsByClassName("btn");
//var buttons = document.getElementsByClassName("btn");


for (var i = 0; i < buttons.length; i++) {
    buttons[i].addEventListener("click", onButtonClic);
}

//buttons.addEventListener("click", onButtonClic);
//debugger;

(function () {

    document.getElementById("button1").addEventListener("click", function () {
        var options = {
            style: {
                main: {
                    background: "#364685",
                    color: "fff",
                },
            },
        };
        iqwerty.toast.toast('Hellow World!', options);
    });

    var bv = new Bideo();
    bv.init({
        // video element
        videoEl: document.querySelector('#background_video'),

        // container element
        container: document.querySelector('body'),

        // resize
        resize: true,

        // autoplay: false

        // Array of objects containing the src and type
        // of different video formats to add
        src: [
            {
                src: '/lib/bideo/night.mp4',
                type: 'video/mp4'
            }
        ],
        // What to do once the video loads (initial frame)
        onLoad: function () {
            document.querySelector('#video_cover').style.display = 'none';
        }
    });
}());
