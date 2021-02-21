function sumFirstLast(nums){
    return Number(nums.pop()) + Number(nums.shift())
}
console.log(sumFirstLast(['20', '30', '40']))
console.log(sumFirstLast(['5', '10']))