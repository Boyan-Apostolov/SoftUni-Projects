function solution() {
    const [gifts, sent, descarded] = document.querySelectorAll('section ul');
    const input = document.querySelector('input');
    document.querySelector('button').addEventListener('click', addGift);

    function addGift() {
        const name = input.value;
        input.value = '';

        const element = e('li', name, 'gift')
        const sendButton = e('button', 'Send', 'sendButton')
        const discardButton = e('button', 'Discard', 'discardButton')
        
        element.appendChild(sendButton);
        element.appendChild(discardButton);

        sendButton.addEventListener('click', () => sendGift(name, element))
        discardButton.addEventListener('click', () => discardGift(name, element))

        gifts.appendChild(element);

        sortGifts();
    }
    function sendGift(name, gift) {
        gift.remove();
        const element = e('li', name, 'gift');
        sent.appendChild(element);
    }
    function discardGift(name, gift) {
        gift.remove();
        const element = e('li', name, 'gift');
        descarded   .appendChild(element);
    }
    function sortGifts() {
        Array
            .from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => gifts.appendChild(g))
    }
    function e(type, content, className) {
        const result = document.createElement(type);
        result.textContent = content;
        if (className) {
            result.className = className;
        }
        return result;
    }
}