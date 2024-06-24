
var college = {
    colName: 'NIT',
    location: 'Trichy',
}
var student = {
    name: 'John',
    age: 20,
    __proto__: college, // prototype inheritance
}
console.log(student.name)
console.log(student.colName) // prototype inheritance



