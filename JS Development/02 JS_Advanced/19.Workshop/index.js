/*globals e*/
function e(type, attributes = {}, ...content) {
    const result = document.createElement(type);

    for (let attr in attributes) {
        result[attr] = attributes[attr];
    }

    content.forEach(e => {
        if (typeof (e) == 'string' || typeof (e) === 'number') {
            const node = document.createTextNode(e)
            result.appendChild(node);
        } else {
            result.appendChild(e)
        }
    });

    return result;
}

function createCharacter(name, hp, dmg) {
    const character = {
        alive: true,
        name,
        maxHp: hp,
        hp,
        dmg,
        attack,
        takeDamage,
    };

    return character

    function attack(target) {
        target.takeDamage(character.dmg);
    }
    function takeDamage(incommingDmg) {
        character.hp -= Math.max(character.hp - incommingDmg, 0);

        if (character.hp == 0) {
            character.alive = false;
        }
    }
}

const player = createCharacter('Player', 100, 25)
const player = createCharacter('Bad Guy', 50, 10)

windows.game = {
    player,
    enemy
}