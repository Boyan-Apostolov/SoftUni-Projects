function uppercase(word) {
    
    var newstringreplaced = word.toUpperCase().replace(/(([-!$%^&*()_+|~=`{}\[\]:";'<>?,.\/\s])+)/g, " ");
    let arrayOfWords = newstringreplaced.split(" ");
    if(arrayOfWords.length > 1){
        let temp = arrayOfWords.join(", ").toString();
        let temp2 = temp.substring(0,temp.length-2)
        return temp2
    }
    return arrayOfWords.toString()
}
console.log(uppercase('hello'))
console.log(uppercase('Hi, how are you?'))