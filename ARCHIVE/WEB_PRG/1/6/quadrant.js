function quadrant(x, y) {
    if(x == 0 || y == 0)
        return "none"

    if (x > 0)
        return y > 0 ? 1 : 4
    else
        return y > 0 ? 2 : 3
}

console.log(`(1, 0) lies in: quadrant ${quadrant(1, 0)}`)
console.log(`(0, 1) lies in: quadrant ${quadrant(0, 1)}`)

console.log(`(5, 6) lies in: quadrant ${quadrant(5, 6)}`)
console.log(`(-1, 1) lies in: quadrant ${quadrant(-1, 1)}`)
console.log(`(-6, -6) lies in: quadrant ${quadrant(-6, -6)}`)
console.log(`(6, -6) lies in: quadrant ${quadrant(6, -6)}`)