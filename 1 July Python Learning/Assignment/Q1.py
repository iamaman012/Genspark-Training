
 # 1) Create a application that will take the Employee details(Name, DOB, Phone and E-Mail) from console, validate it and calculate age(Age should not taken from user)

  # The application should show menu to store the same in file. Option for saving should be text/excel/pdf. 

   # Optional implementation - > Bulk read and store in list from Excel file


import re
from datetime import datetime
import xlsxwriter
from reportlab.pdfgen.canvas import Canvas
from reportlab.lib.pagesizes import letter

def validate_name(name):
    if len(name) > 0:
        return True
    else:
        print("Invalid name. Please enter a non-empty name.")
        return False

def validate_dob(dob):
    try:
        datetime.strptime(dob, "%Y-%m-%d")
        return True
    except ValueError:
        print("Invalid date format. Please use YYYY-MM-DD.")
        return False

def validate_phone(phone):
    if re.match(r"^\+?1?\d{9,15}$", phone):
        if len(phone)==10 :
            return True
        else:
            print("Enter the 10 Digit Valid Number")
    
    else:
        print("Invalid phone number. Please enter a valid phone number.")
        return False

def validate_email(email):
    if re.match(r"[^@]+@[^@]+\.[^@]+", email):
        return True
    else:
        print("Invalid email address. Please enter a valid email address.")
        return False

def calculate_age(dob):
    birth_date = datetime.strptime(dob, "%Y-%m-%d")
    today = datetime.today()
    age = today.year - birth_date.year - ((today.month, today.day) < (birth_date.month, birth_date.day))
    return age

def save_details(num,name,phone,email,age):
    if num==1:
        f=open("details.txt",'a')
        f.write(f"Name:{name}\nAge:{age}\nPhone:{phone}\nEmail:{email}")
    elif num==2:
        wb = xlsxwriter.Workbook("details.xlsx")
        ws = wb.add_worksheet()
        ws.write('A1',name)
        ws.write('B1',age)
        ws.write('C1',phone)
        ws.write('D1',email)
        wb.close()

    elif num==3:
        canvas = Canvas('details.pdf',pagesize=letter)
        x = 2
        _, height = letter
    
            # Draw each line separately
        canvas.drawString(x, height-20, f"Name: {name}")
        canvas.drawString(x, height-40, f"Age: {age}")
        canvas.drawString(x, height -60, f"Phone: {phone}")
        canvas.drawString(x, height- 80, f"Email: {email}")
        canvas.save()


def get_employee_details():
    while True:
        name = input("Enter Name: ")
        if validate_name(name):
            break

    while True:
        dob = input("Enter Date of Birth (YYYY-MM-DD): ")
        if validate_dob(dob):
            break

    while True:
        phone = input("Enter Phone Number: ")
        if validate_phone(phone):
            break

    while True:
        email = input("Enter E-Mail: ")
        if validate_email(email):
            break

    age = calculate_age(dob)
    print("Please Enter the Choice")
    print("1: Save Date as text File")
    print("2: Save data as Excel file")
    print("3: Save Data as Pdf File")

    num = int(input("Enter the Choice"))
    save_details(num,name,phone,email,age)
    


get_employee_details()

 