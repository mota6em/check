const array = [3, 5, 12, -8, 4, 1]

function countEven(a) {
    let b = 0
    // Foreach ciklus
    for (c of a) {
        if (c % 2 == 0) {
            b++
        }
    }
    return b
}
console.log(countEven(array))

// megszámolás tömbfüggvény használata
console.log(`even numbers: ${array.reduce((a, b) => a + (b % 2 == 0 ? 1 : 0), 0)}`)

//a = 0, b meg az aktuális elem, ha osztható 2 -vel akkor növeljük 1-el