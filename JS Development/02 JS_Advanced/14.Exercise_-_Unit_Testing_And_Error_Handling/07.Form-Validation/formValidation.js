function validate() {
    const companyInfo = document.getElementById('companyInfo');
    document.getElementById('company').addEventListener('change', () => {
        companyInfo.style.display == 'none' ? companyInfo.style.display = 'block' : companyInfo.style.display = 'none'
    })
    function checkInputs(e) {
        e.preventDefault();

        let hasErrorOccured = false;
        //Check username
        let username = inputFields[0].value;
        const usernameCheckPattern = /^[a-zA-Z0-9]{3,20}$/gm;
        if (!username || !usernameCheckPattern.test(username)) {
            inputFields[0].style.borderColor = 'red';
            hasErrorOccured = true;
        } else {
            inputFields[0].style.border = 'none';
        }

        //Check passwords
        let passwordInput = document.getElementById('password');
        let password = passwordInput.value;
        let confirmPassword = inputFields[3].value;
        let passwordsCheckPattern = /^\w{5,15}$/gm;

        let isPasswordOk = passwordsCheckPattern.test(password);
        let arePasswordEqual = password == confirmPassword;

        if (!arePasswordEqual || !isPasswordOk) {
            inputFields[2].style.borderColor = 'red';
            inputFields[3].style.borderColor = 'red';
            hasErrorOccured = true;
        } else {
            inputFields[2].style.borderColor = '';
            inputFields[3].style.borderColor = '';
        }

        // //Check Email
        let email = inputFields[1].value;
        const emailCheckPattern = /^\w+@\w+(\.\w+)*$/gm
        const secondEmailCheckPattern = /^\w+@\.+$/gm
        if (!email || !emailCheckPattern.test(email)) {
            if (!secondEmailCheckPattern.test(email)) {
                inputFields[1].style.borderColor = 'red';
                hasErrorOccured = true;
            }
        } else {
            inputFields[1].style.border = 'none';
        }

        //Check company
        let isCompany = inputFields[4].checked;
        if (isCompany) {
            let companyNumber = inputFields[5].value
            if (Number(companyNumber) >= 1000 && Number(companyNumber) <= 9999) {
                inputFields[5].style.border = 'none';
            } else {
                inputFields[5].style.borderColor = 'red';
                hasErrorOccured = true;
            }
        }

        if (!hasErrorOccured) {
            validationDiv.style.display = 'block'
        } else {
            validationDiv.style.display = 'none'
        }
    }
    let inputFields = Array.from(document.querySelectorAll('.pairContainer input'));
    let validationDiv = document.getElementById('valid');
    document.getElementById('submit').addEventListener('click', checkInputs)
}
