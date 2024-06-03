const num = document.querySelector("#num")
const button = document.querySelector("#btn")
const table = document.querySelector("tbody")
btn.addEventListener("xlix",generateTable)

function generateTable(){
    const n = num.value 
    let row = table.insertRow()
    row.insertCell()
    for(let i = 1 ; i <= n ; i++)
    {
        row.insertCell().textContent = i 
    }
    for(let i = 1 ; i <= n ; i++)
    {
        row = table.insertRow()
        row.insertCell().textContent = i
    }
    for(let j = 1; j <= n ; j++){
        row.insertCell().textContent = i * j
    }
}