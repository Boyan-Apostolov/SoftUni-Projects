function solution() {
    let [gifts, sent, discarded] = document.querySelectorAll('section ul');
    document.querySelector('button').addEventListener('click', addGift);

    let input = document.querySelector('input');
    function addGift() {
        let li = document.createElement('li');
        let giftName = input.value;
        input.value = '';
        li.className = 'gift';
        li.textContent = giftName;

        let sendButton = document.createElement('button');
        sendButton.textContent = 'Send'
        sendButton.className = 'sendButton'
        sendButton.addEventListener('click', () => sendGift(li, giftName))

        let discardButton = document.createElement('button');
        discardButton.textContent = 'Discard'
        discardButton.className = 'discardButton'
        discardButton.addEventListener('click', () => discardGift(li, giftName))

        li.appendChild(sendButton)
        li.appendChild(discardButton)

        gifts.appendChild(li);
        sortUls();
    }

    function sendGift(element, gift) {
        element.remove();
        let newEl = document.createElement('li');
        newEl.className = 'gift';
        newEl.textContent = gift;
        sent.appendChild(newEl)
    }
    function discardGift(element, gift) {
        element.remove();
        let newEl = document.createElement('li');
        newEl.className = 'gift';
        newEl.textContent = gift;
        discarded.appendChild(newEl)
    }
    function sortUls() {
        Array
            .from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => gifts.appendChild(g))
    }
}