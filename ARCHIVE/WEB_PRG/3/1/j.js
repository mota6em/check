const p = document.querySelector("p")
p.addEventListener("click",onclick)

function onclick(e){
    console.log(this)
    console.log(e.type)
    console.log(e.button)
    console.log(`${e.screenX}, ${e.screenY}`)
    console.log(e.target)
    if(e.target.matches("p span")){
        console.log(e.target.innerText)
    }
    if(e.target.matches("p a")){
        if(e.target.innerText == "libero"){
            e.preventDefault()
        }
    }
}
