function lnko(a, b) {
    if (a < b) {
        [a, b] = [b, a]
    }
    let maradek = a % b
    while (maradek > 0) {
        a = b
        b = maradek
        maradek = a % b
    }
    return b
}

console.log(`lnko(12,38): ${lnko(12, 38)}`)