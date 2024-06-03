document.addEventListener("input", onInput)

function onInput(e) {
    if (e.target.matches(".szam")) {
        if (e.target.value.match(/\s/) || isNaN(e.target.value)) {
            e.target.value = e.target.value.slice(0, -1)
        }
    }
}