var id = null;
var clic = 0;
function myMove() {
    var elem = document.getElementById("Loro");
    var elem2 = document.getElementById("Bille")
    var pos = 0;
    var pos2 = 0;
    var pos3 = 1;
    var pos4 = 1;
    var pos5 = 0;
    if (clic == 0) {
        clic = 1;
        clearInterval(id);
        id = setInterval(frame, 1);
        function frame() {
            if ((pos2 == -250)) {
                clearInterval(id);
                elem.style.display = 'none'
            }
            else {
                pos = pos + 20;
                pos2 = pos2 - 10;
                if (pos > 100) {
                    pos3 = pos3 - 0.03;
                    pos4 = pos4 + 0.005;
                    pos5 = pos5 - 3;
                    elem.style.top = pos + 'px';
                    elem.style.transform = 'scaleY(' + pos3 + ')';
                    elem2.style.top = pos2 + 'px';
                    elem2.style.transform = 'scale(' + pos4 + ')';
                    elem2.style.left= pos5 + 'px';
                }
            }
        }
    }
    else {

    }
}

function aHome() {
    document.getElementById("nextB").addEventListener("click", myFunction);
      function myFunction() {
        window.location.href="/Home.html";
      }
}