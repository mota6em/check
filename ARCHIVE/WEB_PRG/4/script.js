
function randomm(a,b){
    return Math.floor(Math.random() * (b-a+1)) + a
} 
let end = false
let numToFinde = randomm(1,100)
let tipps = []

function putTip(tippNum){
    tipps.push(tippNum)
}

const input = document.querySelector("#tipp")
const gomb = document.querySelector("#btn")
const ul = document.querySelector("#tippek")

gomb.addEventListener('click',tipples)
function tipples(e){
    const num = input.valueAsNumber
    putTip(num)
    const li = `<li>${num}</li>`
    ul.innerHTML = genLista()
    gomb.disabled = end
    input.disabled = end
    if(end){
        gomb.innerHTML -= "ُEnter! "
        gomb.innerHTML += "U WON"
    }
}
function genLista(){
    return tipps.map(num =>
         `<li>${hasonlit(num)}</li>`).join('')

    // ` 
    // <li>50(bigger)</li>
    // <li>75(smaller)</li>
    // <li>70(equal)</li>
    // `

}
function hasonlit(num){
      if (num < numToFinde) return 'bigger'
      if (num > numToFinde) return 'smaller'
      end = true
      return 'equal'
}

