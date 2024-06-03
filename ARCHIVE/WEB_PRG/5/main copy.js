const menuDiv = document.querySelector("#menu")
const gameDiv = document.querySelector("#game")

// Menü
const name1Text = document.querySelector("#name1")
const name2Text = document.querySelector("#name2")
const sizeText = document.querySelector("#size")
let name1
let name2
document.querySelector("#start").addEventListener("click", startGame)

// Játék
const table = document.querySelector("tbody")
table.addEventListener("click", clickTile)
const output = document.querySelector("#output")
let size
let sign = "X"
let placedSigns = 0


function startGame() {
    if (!tryReadInput())
        return

    output.innerText = name1 + " következik"

    menuDiv.hidden = true
    gameDiv.hidden = false

    for (let i = 0; i < size; i++) {
        const row = table.insertRow()
        for (let j = 0; j < size; j++) {
            row.insertCell()
        }
    }
}

function tryReadInput() {
    if (name1Text.value === ""
        || name2Text.value === ""
        || sizeText.value === ""
        || sizeText.value < 15
        || sizeText.value > 25)
        return false

    size = parseInt(document.querySelector("#size").value)
    name1 = name1Text.value
    name2 = name2Text.value
    return true
}

function clickTile(e) {
    if (e.target.matches("td")) {
        const row = e.target.closest("tr").rowIndex
        const col = e.target.closest("td").cellIndex
        let s = placeSign(row, col)
        if(!s)
            return;
        if (checkForWin(row, col)) {
            output.innerText = (sign == "X" ? name1 : name2) + " nyert!"
            table.removeEventListener("click", clickTile)
        }
        else if (checkForTie()) {
            output.innerText = "Döntetlen"
            table.removeEventListener("click", clickTile)
        }
        else {
            changePlayer()
        }
    }
}

// Megnézi, döntetlen van-e
function checkForTie() {
    return placedSigns == size * size
}

// Elhelyezi a megadott mezőn a soron következő játékos jelét
function placeSign(row, col) {
    const cell = table.rows[row].cells[col]
    if (cell.innerText != "")
        return false;

    cell.innerText = sign
    placedSigns++
    return true;
}

// Megmondja, hogy egy sor-oszlop kombináció a táblázaton belülre esik-e
function isInPlayArea(row, col) {
    return row < size
        && row >= 0
        && col < size
        && col >= 0
}

// Adott irányban számol azonos mezőket
function countInDirection(row, col, rowx, colx) {
    let i

    for (i = 0; isInPlayArea(row, col); i++) {
        if (getCellSign(row, col) == sign) {
            row += rowx
            col += colx
        } else {
            break;
        }
    }
    return i
}

// Ellenőrzi, hogy nyert-e valaki
function checkForWin(row, col) {
    return 5 < countInDirection(row, col, -1, -1) + countInDirection(row, col, 1, 1)    // Átlósan
        || 5 < countInDirection(row, col, 1, -1) + countInDirection(row, col, -1, 1)    // Átlósan
        || 5 < countInDirection(row, col, 1, 0) + countInDirection(row, col, -1, 0)     // Függőlegesen
        || 5 < countInDirection(row, col, 0, 1) + countInDirection(row, col, 0, -1)     // Vízszintesen
}

// Visszaadja egy mező értékét
function getCellSign(row, col) {
    return table.rows[row].cells[col].innerText
}

// Lecseréli a jelet és a feliratot
function changePlayer() {
    sign = sign == "X" ? "O" : "X"
    output.innerText = (sign == "X" ? name1 : name2) + " következik"
}