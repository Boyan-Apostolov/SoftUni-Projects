function fruitOrVeggie([product]) {
    if (product === 'banana' || product === 'apple' || product === 'kiwi' || product === 'cherry' || product === 'lemmon' || product === 'grapes') {
        console.log('fruit');
    } else if (product === 'tomato' || product === 'cucumber' || product === 'carrot' || product === 'perpper') {
        console.log('vegetable');
    } else {
        console.log('unknown');
    }
}
