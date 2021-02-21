function solution() {
    let [gifts, sent, discarded] = document.querySelectorAll('section ul');
    document.querySelector('button').addEventListener('click', addGift)

    function addGift() {
        let giftNameInput = document.getElementsByTagName('input')[0];
        let giftName = giftNameInput.value;
        giftNameInput.value = '';

        let li = e('li', giftName, 'gift');

        let sendBtn = e('button', 'Send', 'sendButton');
        sendBtn.addEventListener('click', () => sendGift(giftName,li));

        let discardBtn = e('button', 'Discard', 'discardButton')
        discardBtn.addEventListener('click', () => discardGift(giftName,li))

        li.appendChild(sendBtn);
        li.appendChild(discardBtn);

        gifts.appendChild(li)

        sortUls(gifts);
    }

    function sendGift(name, li) {
        li.remove();
        sent.appendChild(e('li', name, 'gift'))
    }
    function discardGift(name, li) {
        li.remove();
        discarded.appendChild(e('li', name, 'gift'))
    }

    function e(type, content, className) {
        const result = document.createElement(type);
        if (content != null) {
            result.textContent = content;
        }
        if (className != null) {
            result.className = className;
        }
        return result;
    }

    function sortUls(ul) {
        Array
            .from(ul.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => ul.appendChild(g))
    }
}