// function hereWEgo(a)
// {
//     let x = 34
//     return x
// }
// const wpResults = [
// { name: "Henry Edwards",      grade: 3 },
// { name: "John Young",         grade: 2 },
// { name: "Noah Williams",      grade: 4 },
// { name: "Julie Moore",        grade: 5 },
// { name: "Jeffrey Roberts",    grade: 5 },
// { name: "Brandon Turner",     grade: 3 },
// { name: "Mia Wright",         grade: 5 },
// { name: "Catherine Mitchell", grade: 4 },
// { name: "Kevin Johnson",      grade: 4 },
// { name: "Thomas James",       grade: 5 },
// ];
// const result = wpResults
//   .filter(student => student.grade === 5)
//   .map(student => student.name);

// function filterGrade5(students) {
// const result = [];
// for (const student of students) {
//     if (student.grade === 5) {
//     result.push(student.name);
//     }
// }
// return result;
// }
// const tomb = [] 
// const tomb_1  = [12, 'alma', false]

// function masolás(ő)
// {
//     for(let i = 0; i < tomb_1.length; i++){
//         tomb.push(tomb_1[i])
//     }
//     return tomb
// }

// // console.log(`hereWEGO ${masolás(tomb_1)}`)

// const numbers = [1,2,3,4,5]

// function filtter(x,fn)
// {
//     const output = []
//     for(const s of x){
//         if(fn(s))
//         {
//             output.push(s)
//         }
//         return output
//     }
// }
// // console.log(`THIS WAS FOR FILTER FUNCION: ${filtter(numbers, e =>e % 2 === 0)}`)
// function add(a, b) {
//     return a + b;
//   }
// // console.assert
// console.assert(add(3, 2)  === 5,   '3 + 2 should be equal 5');
// console.assert(add(10, 0) === 10,  '10 + 0 should be equal 10');
// for (let i = 0; i < 10; i++) {
//     if (i % 2 === 0) {
//       console.log(i);
//     }
//   }
//   const numbers = [3, 1, -1, 4, 6, -3]
//   console.log( numbers.filter(e => e < 0) ) // [-1, -3]

//   const king = {
//     name: 'Mathias Rex',
//     from: 1458,
//     to: 1490,
//   }
// console.log(king.name , king.from)

const homersekletek = [2,1,-23, -232, -3]
console.log(`Fagyott homersekeletek: ${homersekletek.filter(e => e < 0)}`)
function addC(arr){
    for(let i = 0 ; i < arr.length ; i++)
    {
        arr[i] = arr[i] + 'C'
    }
    return arr
}
console.log(`TEST: ${addC(homersekletek)}`)
console.log(`TEST: ${Math.max(...homersekletek)}`)