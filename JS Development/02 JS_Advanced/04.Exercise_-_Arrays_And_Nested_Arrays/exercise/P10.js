function ticTac(playerMoves) {
    let messages = [];
    var initialBoard = [[false, false, false],
    [false, false, false],
    [false, false, false]]
    let counter = 0;
    let xWins = false;
    let oWins = false;
    for (const move of playerMoves) {
        if (!isWon(initialBoard)) {
            if (counter % 2 == 0) {
                if (!placeOnBoard(initialBoard, 'X', move)) {
                    counter--;
                }
                if (isWon(initialBoard)) { xWins = true; break; }
            } else {
                if (!placeOnBoard(initialBoard, 'O', move)) {
                    counter--;
                }
                if (isWon(initialBoard)) { oWins = true; break; }
            }
            counter++;
        }
        else { break; }

    }

    function placeOnBoard(initialBoard, player, move) {
        let x = Number(move[0]);
        let y = Number(move[2]);
        if (isSpaceTaken(initialBoard, x, y)) {
            messages.push('This place is already taken. Please choose another!');
            return false;
        }
        initialBoard[x][y] = player;
        if (isWon(initialBoard)) {
            return true;
        }
        return true;
    }

    function isSpaceTaken(initialBoard, x, y) {
        return initialBoard[x][y] == false ? false : true;
    }

    function isWon(initialBoard) {
        let isGameWon = false;

        let leftDiag = 0;
        let rightDiag = 0;
        for (let i = 0; i < initialBoard.length; i++) {
            if (initialBoard[i][i] == 'X') {
                leftDiag++;
            }
            else if(initialBoard[i][i] == 'O'){
                rightDiag++;
            }

        }
        if (leftDiag == 3) {
            isGameWon = true;
        }
        if (rightDiag == 3) {
            isGameWon = true;
        }
        if (initialBoard.every((el, i, arr) => { return el == arr[0] })) { isGameWon = true; }
        if (initialBoard.every((el, i, arr) => { return el == arr[1] })) { isGameWon = true; }
        if (initialBoard.every((el, i, arr) => { return el == arr[2] })) { isGameWon = true; }

        if (initialBoard[0][0] == 'X' && initialBoard[0][1] == 'X' && initialBoard[0][2] == 'X') { isGameWon = true }
        if (initialBoard[1][0] == 'X' && initialBoard[1][1] == 'X' && initialBoard[1][2] == 'X') { isGameWon = true }
        if (initialBoard[2][0] == 'X' && initialBoard[2][1] == 'X' && initialBoard[2][2] == 'X') { isGameWon = true }

        if (initialBoard[0][0] == 'O' && initialBoard[0][1] == 'O' && initialBoard[0][2] == 'O') { isGameWon = true }
        if (initialBoard[1][0] == 'O' && initialBoard[1][1] == 'O' && initialBoard[1][2] == 'O') { isGameWon = true }
        if (initialBoard[2][0] == 'O' && initialBoard[2][1] == 'O' && initialBoard[2][2] == 'O') { isGameWon = true }


        return isGameWon;
    }
    let result = [[], [], []]
    for (let i = 0; i < initialBoard.length; i++) {
        for (let y = 0; y < initialBoard.length; y++) {
            result[i].push(initialBoard[i][y])
        }
    }
    let tempRes = [[result[0].join('\t')],[result[1].join('\t')],[result[2].join('\t')]]
    if (isWon(initialBoard)) {
       
        return messages.join('\n') + '\n' + `Player ${xWins == true ? 'X' : 'O'} wins!` + '\n' + tempRes.join('\n');
    }
    return "The game ended! Nobody wins :(" + '\n' + tempRes.join('\n')
}
console.log(ticTac(["0 1",   
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]));

console.log('\n');
console.log('New Game   '.repeat(5))
console.log('\n');

console.log(ticTac(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]
));

console.log('\n');
console.log('New Game   '.repeat(5))
console.log('\n');

console.log(ticTac(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
));