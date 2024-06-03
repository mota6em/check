const texts = document.querySelectorAll("#text")
const addBtn = document.querySelector("#addrow")
const table = document.querySelector("tbody")
addBtn.addEventListener("click", addRow)

function addRow() {
    let row = table.insertRow()
    texts.forEach(text => row.insertCell().textContent = text.value)
}