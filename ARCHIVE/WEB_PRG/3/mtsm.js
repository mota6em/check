const btn = document.querySelector("body > section:nth-of-type(4) > form > button")
btn.innerHTML = "fafs"

const ul = document.querySelector("ul")
ul.addEventListener('click' , csere)
let x = false
let prev 
function csere(e) {

    if(e.target.matches("ul > li")){
        if(!x){
            prev = e.target
            x = true
        }
        else{
            let temp = prev.innerText
            prev.innerText = e.target.innerText 
            e.target.innerText = temp
            x = false
        }
    }
}

document.addEventListener('click', tiltes)
function tiltes(e){
    if(e.target.matches('a.tiltott')){
        e.preventDefault();
    }
}

const link = document.querySelector("#getLINK")
const button = document.querySelector("#btn")

button.addEventListener('click', search)

function search(e){
    var newPGE = link.value;
    alert('THIS WILL TAKE U TO AOTHER WEBPAGE, DONT FOGET TO GET BACK HERE')
    window.open(newPGE, "_blanck")

}
const p = document.querySelector("p")
p.addEventListener('click',onclick)
function onclick(e){
    console.log(e)
    console.log(this.e)
    console.log('fuck')
    if(e.target.matches('p a'))
    {
        if(e.target.innerText == "libero"){
            e.preventDefault()
        }
    }
}

p.addEventListener('click',onclicky)

function onclicky(e){
    if(e.target.matches("p a")){
        if(e.target.innerText == "dolor")
        {
            e.preventDefault()
            console.log('fummm')
        }
    }
}

document.addEventListener("input" , onInput)
function onInput(e){
    if(e.target.matches(".no-nmbrz")){
        if(e.target.value.match(/\s/) || isNaN(e.target.value)){
            e.target.value = e.target.value.slice(0,-1)
        }
    }
}

document.addEventListener("input" , noMore)
function noMore(e){
    if(e.target.matches(".nof")){
        if(e.target.value.match(/\s/) || isNaN(e.target.value)){
            e.target.value = e.target.value.slice(0,-1)
            alert('Please note that characters are not allowed.')
        }
    }
}