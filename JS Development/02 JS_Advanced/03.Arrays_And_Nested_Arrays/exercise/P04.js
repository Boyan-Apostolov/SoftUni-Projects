function negativePostive(nums) {
    let arr = [];
    for (const num of nums) {
        if (num < 0) {
            arr.unshift(num);
        } else {
            arr.push(num)
        }
    }
    return arr.join('\n')
}
console.log(negativePostive([7, -2, 8, 9]))
console.log('\n')
console.log(negativePostive([3, -2, 0, -1]))