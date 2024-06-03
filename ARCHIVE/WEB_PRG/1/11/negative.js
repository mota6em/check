const array = [3, 5, 12, -8, 4, 1]

// Teljes keresés megírása
function findNegative(a) {
    // Szokásos lépkedő ciklus
    for (let i = 0; i < a.length; i++) {
        if (a[i] < 0) {
            return a[i]
        }
    }
}
console.log(findNegative(array))

// Beépített keresés tömbfüggvény használata
// Függvény mint paraméter
// const negativeNumber = array.find(function (a) { return a < 0 })

// Rövidített változat, általában 1 utasításos függvények esetén
const negativeNumber = array.find(a => a < 0)
console.log(`negative number: ${negativeNumber}`)