function solve() {
    const formElements = document.querySelector('#container').children;
    const inputs = Array.from(formElements).slice(0, formElements.length - 1)//
    const onScreenButton = Array.from(formElements).slice(formElements.length - 1)[0]
    const moviesUl = document.querySelector('#movies>ul');
    const archiveUl = document.querySelector('#archive>ul');
    const clearButton = document.querySelector('#archive>button');

    function clear(e) {
        e.target.parentNode.children[1].textContent = ""
    }

    function archive(e) {
        let li = e.target.parentNode.parentNode;
        let div = e.target.parentNode;
        let input = Number(div.children[1].value);
        if (!input) { return; }

        let span = document.createElement('span');
        let name = li.children[0].textContent;
        span.textContent = name;

        let strong = document.createElement('strong');
        let price = Number(div.children[0].textContent);
        let totalPrice = input * price;
        strong.textContent = `Total amount: ${totalPrice.toFixed(2)}`

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete'
        deleteButton.addEventListener('click', (e) => {
            e.target.parentNode.remove()
        })

        const resultLi = document.createElement('li');
        resultLi.appendChild(span)
        resultLi.appendChild(strong)
        resultLi.appendChild(deleteButton)

        archiveUl.appendChild(resultLi);

        li.remove();

    }

    function createMovie(e) {
        e.preventDefault();

        const name = inputs[0].value;
        const hall = inputs[1].value;
        const price = Number(inputs[2].value);

        if (!name || !hall || !price) { return; }

        inputs[0].value = ''
        inputs[1].value = ''
        inputs[2].value = ''

        const li = document.createElement('li')

        const span = document.createElement('span')
        span.textContent = name;
        li.appendChild(span);

        const strong = document.createElement('strong');
        strong.textContent = `Hall: ${hall}`;
        li.appendChild(strong);

        const div = document.createElement('div');
        const innerStrong = document.createElement('strong');
        innerStrong.textContent = price.toFixed(2);

        const input = document.createElement('input');
        input.setAttribute('placeholder', 'Tickets Sold')

        const archiveButton = document.createElement('button');//
        archiveButton.textContent = 'Archive'
        archiveButton.addEventListener('click', archive)

        div.appendChild(innerStrong)
        div.appendChild(input)
        div.appendChild(archiveButton)

        li.appendChild(div);

        moviesUl.appendChild(li)
    }
    onScreenButton.addEventListener('click', createMovie)
    clearButton.addEventListener('click', clear)
}