const output = document.querySelector("output")
const numField = document.querySelector("#num")
const button = document.querySelector("#btn")
button.addEventListener("click", circleArea)
function circleArea() {
    const r = numField.value
    output.innerHTML = `Circle area: ${r * r * Math.PI}`
}