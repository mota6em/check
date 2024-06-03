// a) variable declaration
let num = 0
const text = document.querySelector("#num")
const addBtn = document.querySelector("#add")
const subtractBtn = document.querySelector("#subtract")

// b) variable declarations
const min = 0
const max = 500

// c) variable declarations
const delay = 800
const rate = 100
let delayTimer
let rateTimer

// a)
addBtn.addEventListener("click", add)
subtractBtn.addEventListener("click", subtract)

function add() {
    text.value = ++num
    updateDisable()
}

function subtract() {
    text.value = --num
    updateDisable()
}

// b)
updateDisable()
function updateDisable() {
    addBtn.disabled = (num == max)
    subtractBtn.disabled = (num == min)

    if ((num == min) || (num == max))
        killTimers()
}

// c)
addBtn.addEventListener("mousedown", () => {
    delayTimer = setTimeout(() => {
        rateTimer = setInterval(add, rate)
    }, delay)
})
addBtn.addEventListener("mouseup", killTimers)

subtractBtn.addEventListener("mousedown", () => {
    delayTimer = setTimeout(() => {
        rateTimer = setInterval(subtract, rate)
    }, delay)
})
subtractBtn.addEventListener("mouseup", killTimers)

function killTimers() {
    clearTimeout(delayTimer)
    clearTimeout(rateTimer)
}