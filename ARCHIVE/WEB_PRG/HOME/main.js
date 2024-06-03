const enter = document.getElementById("btn");
const remove = document.getElementById("rmv");
enter.addEventListener('click', addTheText);
remove.addEventListener('click', removeTheText);
const par = document.getElementById("par");

function addTheText(e){
    // par.style.display = 'none' 
    par.classList.add('fade-out' )
}

function removeTheText(e){
    // par.style.display = 'block'
    par.classList.remove('fade-out')
}
function text(e) {
    console.log(`ello`);
}
