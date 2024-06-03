const button = document.querySelector("#btn")
const output = document.querySelector("img")
const num = document.querySelector("#inpt")

button.addEventListener("click",search)
function search(){
    output.src = num.value
}