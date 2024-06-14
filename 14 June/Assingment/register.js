function validateName() {
    var name = document.getElementById('name').value;
    var nameText = document.getElementById('name-text');
    var nameInput = document.getElementById('name');
    
    if (name === '') {
        nameInput.classList.add('error');
        nameInput.classList.remove('correct');
        nameText.textContent = 'Name is required';
        nameText.classList.add('error-text');
        nameText.classList.remove('correct-text');
    } else {
        nameInput.classList.remove('error');
        nameInput.classList.add('correct');
        nameText.textContent = 'Looks good!';
        nameText.classList.remove('error-text');
        nameText.classList.add('correct-text');
    }
}

function validatePhone() {
    var phone = document.getElementById('phone').value;
    var phoneText = document.getElementById('phone-text');
    var phoneInput = document.getElementById('phone');
    var phoneRegex = /^[0-9]{10}$/; // 10 digit phone number

    if (!phoneRegex.test(phone)) {
        phoneInput.classList.add('error');
        phoneInput.classList.remove('correct');
        phoneText.textContent = 'Please enter a valid 10-digit phone number';
        phoneText.classList.add('error-text');
        phoneText.classList.remove('correct-text');
    } else {
        phoneInput.classList.remove('error');
        phoneInput.classList.add('correct');
        phoneText.textContent = 'Looks good!';
        phoneText.classList.remove('error-text');
        phoneText.classList.add('correct-text');
    }
}

function validateDOB() {
    var dob = document.getElementById('dob').value;
    var dobText = document.getElementById('dob-text');
    var dobInput = document.getElementById('dob');

    if (dob === '') {
        dobInput.classList.add('error');
        dobInput.classList.remove('correct');
        dobText.textContent = 'Date of Birth is required';
        dobText.classList.add('error-text');
        dobText.classList.remove('correct-text');
    } else {
        dobInput.classList.remove('error');
        dobInput.classList.add('correct');
        dobText.textContent = 'Looks good!';
        dobText.classList.remove('error-text');
        dobText.classList.add('correct-text');
    }

    // Calculate age
    var today = new Date();
    var birthDate = new Date(dob);
    var age = today.getFullYear() - birthDate.getFullYear();
    var monthDifference = today.getMonth() - birthDate.getMonth();

    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }

    document.getElementById('age').value = age;
}

function validateEmail() {
    var email = document.getElementById('email').value;
    var emailText = document.getElementById('email-text');
    var emailInput = document.getElementById('email');
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Simple email validation regex

    if (!emailRegex.test(email)) {
        emailInput.classList.add('error');
        emailInput.classList.remove('correct');
        emailText.textContent = 'Please enter a valid email address';
        emailText.classList.add('error-text');
        emailText.classList.remove('correct-text');
    } else {
        emailInput.classList.remove('error');
        emailInput.classList.add('correct');
        emailText.textContent = 'Looks good!';
        emailText.classList.remove('error-text');
        emailText.classList.add('correct-text');
    }
}

var validateProf=()=>{
    var professionInput = document.getElementById('prof');
    var professionList = document.getElementById('Professions');
    var inputValue = professionInput.value.trim();

    if (inputValue !== '') {
        var options = professionList.options;
        var exists = false;

        for (var i = 0; i < options.length; i++) {
            if (options[i].value.toLowerCase() === inputValue.toLowerCase()) {
                exists = true;
                break;
            }
        }

        if (!exists) {
            var newOption = document.createElement('option');
            newOption.value = inputValue;
            professionList.appendChild(newOption);
        }
        var professionText = document.getElementById('Prof-text');
        professionInput.classList.remove('error');
        professionInput.classList.add('correct');
        professionText.textContent = 'Looks good!';
        professionText.classList.remove('error-text');
        professionText.classList.add('correct-text');
        
    }
    else if(inputValue === ''){
        professionInput.classList.add('error');
        professionInput.classList.remove('correct');    
        var professionText = document.getElementById('Prof-text');
        professionText.textContent = 'Profession is required';
        professionText.classList.add('error-text');
        professionText.classList.remove('correct-text'); 
    }
   

}