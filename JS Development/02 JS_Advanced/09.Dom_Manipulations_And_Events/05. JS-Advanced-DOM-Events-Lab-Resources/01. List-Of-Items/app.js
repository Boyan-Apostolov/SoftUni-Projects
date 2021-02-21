function addItem() {
    let input = document.getElementById('newItemText');
    let liElement = document.createElement('li');
    let ulElement = document.getElementById('items');

    liElement.textContent = input.value;
    ulElement.appendChild(liElement);

    input.value = ''
}