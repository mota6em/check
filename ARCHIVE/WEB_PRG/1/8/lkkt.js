function lkkt(a, b) {
    let x = a
    let y = b
    while (x != y) {
        if (x < y) {
            x = x + a
        } else {
            y = y + b
        }
    }
    return x
}

console.log(`lkkt(4,3): ${lkkt(4, 3)}`)