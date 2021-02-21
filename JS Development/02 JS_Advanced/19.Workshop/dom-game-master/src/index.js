Object.assign(window.game, (function () {
    const player = game.createCharacter('Player', 100, 25);
    const playerSlot = document.getElementById('player');
    const enemySlot = ocument.getElementById('enemies');
    const enemies = [
        game.createCharacter('Bad Guy', 50, 10),
        game.createCharacter('Bad Guy', 50, 10),
        game.createCharacter('Bad Guy', 50, 10),
        game.createCharacter('Bad Guy', 50, 10),
        game.createCharacter('Bad Guy', 50, 10),
    ]

    const controlls = e('div', { id: 'controls' },
        e('button', { onClick: onPlayerAttack }, 'Attack')
    )

    playerSlot.appendChild(player.element);
    playerSlot.appendChild(controlls);
    enemies.forEach(e => e.enemySlot.appendChild(e.element))
    enemy.appendChild(enemy.element);

    function onPlayerAttack() {
        enemies.forEach(e=>e.element.classList.add('targettable'))
    }
})())
