let x 
let arr = []
let players 
const startBtn = document.querySelector("#startBtn")

startBtn.addEventListener("click", setup)

const steps = document.querySelector("#steps")
const currentPlayer = document.querySelector("#currentPlayer")

const table = document.querySelector("tbody")
table.addEventListener("click",onClick)

let turnedUp = 0
let prevCell 
let canPlay = true

function onClick(e){
    if(e.target.matches("td") && canPlay && e.target.innerText == ""){
        const row = e.target.closest("tr").rowIndex
        const col = e.target.closest("tr").cellIndex
        const cell = table.rows[row].cells[col]
        cell.innerText  = arr[row*x+col]
        turnedUp++
        if(turnedUp % 2 == 0){
            steps.innerText++
            currentPlayer.innerText = steps.innerText % players +1
            if(cell.innerText!=prevCell.innerText){
                canPlay = false
                setTimeout(() => {
                    canPlay= true
                    cell.innerText = ""
                    prevCell.innerText = ""
                }, 500);
                turnedUp -=2
            }
            else if(turnedUp == x * x) {
                steps.innerText += " kesz"
            }
            else{prevCell = cell}
        }
    }
}

function setup(){
    startBtn.dis
}