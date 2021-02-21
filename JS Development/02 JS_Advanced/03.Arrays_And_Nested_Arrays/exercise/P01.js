function evenPoss(nums){
    let result = [];
    for (let i = 0; i < nums.length; i+=2) {
        result.push(nums[i]);        
    }
    return result.join(' ')
}
console.log(evenPoss(['20', '30', '40', '50', '60']))
console.log(evenPoss(['5', '10']))