let x
let arr = []
let players
const startBtn = document.querySelector("#startBtn")

startBtn.addEventListener("click", setup)

const steps = document.querySelector("#steps")
const currentPlayer = document.querySelector("#currentPlayer")

const table = document.querySelector("tbody")
table.addEventListener("click", onClick)

let turnedUp = 0
let prevCell
let canPlay = true
function onClick(e) {
    //ha cellara klikkelunk, nem varunk es a cella ures
    if (e.target.matches("td") && canPlay && e.target.innerText == "") {
        //cella kiszamolasa        
        const row = e.target.closest("tr").rowIndex
        const col = e.target.closest("td").cellIndex
        const cell = table.rows[row].cells[col]
        //beirjuk a cellaba az erteket        
        cell.innerText = arr[row * x + col] 
        //felforditottuk
        turnedUp++
        //Ha parosat forditottunk fel eddig
        if (turnedUp % 2 == 0) {
            //leptunk
            steps.innerText++
            //a kovetkezo jatekos jon
            currentPlayer.innerText = steps.innerText % players + 1
            //ha nem ugyanolyan ertekeket forditottunk fel
            if (cell.innerText != prevCell.innerText) {
                //varunk
                canPlay = false
                setTimeout(() => {
                    canPlay = true
                    cell.innerText = ""
                    prevCell.innerText = ""
                }, 500)
                //bezar, ez nem szamit helyes lepesnek,-2
                turnedUp -= 2
            } else if (turnedUp == x * x) {
                //kész ha az osszes fel van forditva
                steps.innerText += " Kész"
            }
        }
        else {
            prevCell = cell
        }
    }
}

function setup() {
    startBtn.disabled = 'true';
    x = document.querySelector("#size").value
    if (x * x % 2 != 0) return
    players = parseInt(document.querySelector("#players").value)
    table.innerHTML = ""
    for (let i = 0; i < x; i++) {
        const row = table.insertRow()
        for (let j = 0; j < x; j++) {
            row.insertCell()
        }
    }

    //tömb 0-17 -ig, felhasznalva a .keys(), tömb index mint érték
    arr = [...Array(x * x / 2).keys()]  
    // megduplazzuk a tombot vagyis minden szám kétszer szerepel
    arr = arr.concat(arr)               
    console.log(arr)
    
    // hatulrol megyunk elore
    for (let i = x * x - 1; i > 0; i--) { 
        // a j egy random szám a maradek elemek kozul
        let j = Math.floor(Math.random() * i + 1); 
        //felcsereljuk randomot meg a szamot
        [arr[i], arr[j]] = [arr[j], arr[i]]; 
    }
    console.log(arr)
    currentPlayer.innerText = 1
}