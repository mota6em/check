const num = document.querySelector("#num")
const btn = document.querySelector("#btn")
const table = document.querySelector("tbody")

btn.addEventListener("click", generateTable)

// Legegyszerűbb
function generateTable() {
    const n = num.value
    let row = table.insertRow()
    row.insertCell()
    for (let i = 1; i <= n; i++) {
        row.insertCell().textContent = i
    }
    for (let i = 1; i <= n; i++) {
        row = table.insertRow()
        row.insertCell().textContent = i
        for (let j = 1; j <= n; j++) {
            row.insertCell().textContent = i * j
        }
    }
}

function generateTable1() {
    const n = num.value
    let tr = document.createElement("tr")
    table.appendChild(tr)
    tr.appendChild(document.createElement("td"))
    for (let i = 1; i <= n; i++) {
        const td = document.createElement("td")
        td.innerHTML = i
        tr.appendChild(td)
    }
    for (let i = 1; i <= n; i++) {
        tr = document.createElement("tr")
        table.appendChild(tr)
        let td = document.createElement("td")
        td.innerHTML = i
        tr.appendChild(td)
        for (let j = 1; j <= n; j++) {
            td = document.createElement("td")
            td.innerHTML = i * j
            tr.appendChild(td)
        }
    }
}

// let s-re van szükség mert ha egyből hozzáadnánk az innerHTML-hez, 
// automatikusan kiegészítené záróelemmel
function generateTable2() {
    const n = num.value
    let s = "<tr><td></td>"
    for (let i = 1; i <= n; i++) {
        s += `<td>${i}</td>`
    }
    s += "</tr>"
    for (let i = 1; i <= n; i++) {
        s += "<tr>"
        s += `<td>${i}</td>`
        for (let j = 1; j <= n; j++) {
            s += `<td>${i * j}</td>`
        }
        s += "</tr>"
    }
    table.innerHTML += s
}