const a = parseInt(prompt("a"))
const b = parseInt(prompt("b"))
const c = parseInt(prompt("c"))

if (a + b > c && a + c > b && b + c > a) {
    console.log("Can make triangle")
}
else {
    console.log("Can't make triangle");
}