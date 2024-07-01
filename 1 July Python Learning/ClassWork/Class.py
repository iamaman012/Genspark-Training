# classes in python

class Person:

   def __init__(self,name,age):
    self.name=name
    self.age=age

p1 = Person("Aman",23)
print(p1.name)
print(p1.age)


# class with __str__  str print the object as string
class Student:
  
    def __init__(self,name,age):
        self.name=name
        self.age=age
    
    def __str__(self):
       return f"Name :{self.name}\n Age :{self.age}"
    
s1 = Student("Ram",23)
print(s1)


# method or function in class

class People:
  
    def __init__(self,name,age):
        self.name=name
        self.age=age
    
    def __str__(self):
       return f"Name :{self.name}\n Age :{self.age}"
    
    def printDetails(self):
       print(f"Name :{self.name}")
       print(f"Age :{self.age}")
    
    
p = People("David",24)
p.printDetails()