const text = document.querySelector("#text")
const btn1 = document.querySelector("#btn1")
const btn2 = document.querySelector("#btn2")
const output = document.querySelector("output")
const select = document.querySelector("select")
const table = document.querySelector("tbody")
const books = [
    {
        author: "Nagy Péter",
        title: "14 Kiscica",
        year: 2021,
        publisher: "Kék Kiadó",
        isbn: "978-6418-2-3903-4"
    },
    {
        author: "Kovács Ilona",
        title: "35 Kiskutya",
        year: 2020,
        publisher: "Kék Kiadó",
        isbn: "979-237-357-900-9"
    },
    {
        author: "Nagy Péter",
        title: "Tíz Kismalac",
        year: 2022,
        publisher: "Piros Kiadó",
        isbn: "978-35942-80-24-9"
    },
    {
        author: "Nagy Péter",
        title: "Huszonnyolc Kismadár",
        year: 2019,
        publisher: "Piros Kiadó",
        isbn: "978-812-42380-1-1"
    }
]
const publishers = [
    "Kék Kiadó",
    "Piros Kiadó"
]
// a)
btn1.addEventListener("click", () => {
    output.innerHTML = ""
    let x = text.value
    books.forEach(b => {
        if (b.year == x)
            output.innerHTML += b.title
    })
})
// b)
btn2.addEventListener("click", () => {
    table.parentElement.style.display = "block"
    table.innerHTML = ""

    books.forEach(b => {
        if (b.publisher == publishers[select.selectedIndex]) {
            const row = table.insertRow()
            row.insertCell().textContent = b.author
            row.insertCell().textContent = b.title
            row.insertCell().textContent = b.year
            row.insertCell().textContent = b.publisher
            row.insertCell().textContent = b.isbn
        }
    })
})