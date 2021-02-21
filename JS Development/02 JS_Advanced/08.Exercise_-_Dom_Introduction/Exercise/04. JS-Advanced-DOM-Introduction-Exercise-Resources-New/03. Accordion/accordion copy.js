function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let div = document.getElementById('extra');

    div.style.display = div.style.display == 'none' || div.style.display == ''  ? 'block' : 'none'

    button.textContent =  button.textContent == 'Less' ? 'More' : 'Less'
}