//ENCAPSULATION
class Student{
    constructor(id, name, section, age){
        this.id = id;
        this.name = name;
        this.section = section;
        this.age = age;
    }

    examData(){
        console.log("Student passed all exams");
    }

    personalInfo()
    {
        console.log(`The student "${this.name}" with id: ${this.id} belongs to ${this.section}`);
    }
}

//INHERITANCE
class SubjectOfStudents extends Student{
    constructor(id, name, section, age,subject,passedSub)
    {
        super(id, name, section, age)
        this.subject=subject
        this.passedSub=passedSub
    }
//POLYMORPHISM
    examData(){
        console.log(`Student has passed ${this.passedSub} out of 5 subjects`)
    }

    subjectInfo(){
        //ABSTRACTION
        super.personalInfo()
        console.log(`The student has chosen "${this.subject}" subject`);
        if(this.passedSub<5){
            this.examData()
        }

    }
}

let student1 = new SubjectOfStudents(1,"mv","A", 21, "Biology", 4);
student1.subjectInfo();