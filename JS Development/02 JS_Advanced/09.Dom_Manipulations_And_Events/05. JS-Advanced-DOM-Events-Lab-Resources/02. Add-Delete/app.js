function addItem() {
    let input = document.getElementById('newText');
    let liElement = createElement('li', input.value);
    let ulElement = document.getElementById('items');
    ulElement.appendChild(liElement);

    const deleteBtn = createElement('a','[Delete]');
    deleteBtn.href = '#';
    deleteBtn.addEventListener('click',(event)=>{
        event.target.parentNode.remove()
    })
    liElement.appendChild(deleteBtn);
    function createElement(type, contet) {
        const element = document.createElement(type);
        element.textContent = contet;
        return element;
    }
}
