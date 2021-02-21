function createCard(cards) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
    const suitToString = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663 ',
    }
    let validCards = [];
    for (const card of cards) {
        let suit = card.slice(-1);
        let suitIndex = card.indexOf(suit)
        let face = card.slice(0, suitIndex)

        try {
            let cardAppended = createCard(face, suit);
            validCards.push(cardAppended)
        } catch {
            console.log(`Invalid card: ${face}${suit}`)
            return;
        }

    }
    console.log(validCards.join(' '))

    function createCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
        const suitToString = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663 ',
        }
        if (validFaces.includes(face) == false) {
            throw new Error('Invalid face');
        } else if (Object.keys(suitToString).includes(suit) == false) {
            throw new Error('Invalid suit')
        }

        return {
            face,
            suit,
            toString() {
                return `${face}${suitToString[suit]}`
            }
        }

    }

}
createCard(['5S', '3D', 'QD', '1C'])