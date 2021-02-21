function solve(input) {
    console.log('Vavedi broi uchenici:__3')
    let poveche = 0;
    let sNad200 = 0;

    let person = [100, 99, 205];
    let person2 = [13, 100, 45];
    let person3 = [30, 29, 15];
    console.log(`student1: 100, 99, 205`)
    console.log(`student2: 13, 100, 45`)
    console.log(`student3: 30, 29, 15`)

    for (const grade of person) {
    
        if(grade >= 200){
            sNad200++;
        }
        else if(grade >= 100){
             poveche++;
        }
    }
    for (const grade of person2) {
        if(grade >= 200){
            sNad200++;
        }
        else if(grade >= 100){
             poveche++;
        }
    }
    for (const grade of person3) {
        if(grade >= 200){
            sNad200++;
        }
        else if(grade >= 100){
             poveche++;
        }
    }
    console.log("Uchenici reshili zadacha "+ poveche)
    console.log("Uchenici reshili poveche ot edna zadacha "+ sNad200)
}
solve()