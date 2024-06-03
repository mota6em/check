document.getElementById("btn").addEventListener("click", check);
const button = document.getElementById("btn")
let numOFlis = 0
const span = document.querySelector("span")


function check() {
    var input = document.getElementById("num").value;
    if (!isNaN(input) && input.trim() !== "") {
        var list = document.getElementById("list");
        var lis = list.getElementsByTagName("li");
        var sum = 0;
        for (var i = 0; i < lis.length; i++) 
        {
            sum += parseFloat(lis[i].textContent);
        }
        if (parseFloat(input) > sum) {
            var li = document.createElement("li");
            li.textContent = input;
            list.appendChild(li);
            numOFlis +=1;
            sum += parseFloat(input); 
            span.innerText = `${sum / numOFlis}` 
            for (var i = 0; i < lis.length; i++) {
                lis[i].style.color = ""; 
            }
        } else {
            alert("A szám nagyobb legyen a többinél!");
        }

    } else {
        alert("Csak számokat lehet írni!");
    }
    if(lis.length >= 5){
        button.disabled = true;
    }

}

const ul = document.getElementById("list").addEventListener('click', listClick)


function listClick(e){
    if(e.target.matches("li"))
    {
        e.target.style.color = "red"
    }
}

