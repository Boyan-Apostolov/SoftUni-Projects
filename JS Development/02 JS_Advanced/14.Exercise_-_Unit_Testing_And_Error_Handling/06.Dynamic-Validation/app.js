function validate() {
    const input = document.getElementById('email');
    const pattern = /^\w+@\w+\.\w+$/gm
    input.addEventListener('change', (e) => {
        if (!pattern.test(input.value)) {
            input.classList.add('error')
        } else {
            input.removeAttribute('class')
        }
    })
}