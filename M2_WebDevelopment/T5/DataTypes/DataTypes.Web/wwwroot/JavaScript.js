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
    t.innerHTML += "<tr><td>" + b.getAttribute("name") +"</td></td>"+ new Date()+"</td></tr>";
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