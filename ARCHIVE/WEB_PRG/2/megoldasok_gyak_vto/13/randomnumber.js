const rand = Math.floor(Math.random() * 100)
const guess = document.querySelector("#num")
const guessBtn = document.querySelector("#guess")
const output = document.querySelector("output")
alert(rand);
guessBtn.addEventListener("click", () => output.innerHTML = guess.value < rand ? "Guess is smaller" : guess.value > rand ? "Guess is bigger" : "Match")