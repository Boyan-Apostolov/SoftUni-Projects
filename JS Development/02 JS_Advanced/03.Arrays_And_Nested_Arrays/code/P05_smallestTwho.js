function smallesTwo(nums){
    nums.sort((a, b) => {return a - b;});
    return nums[0]+ ' ' +nums[1]
    //return nums.sort((a, b) => {return a - b;}).slice(0,2).join(' ');
}
console.log(smallesTwo([30, 15, 50, 5]))
console.log(smallesTwo([3, 0, 10, 4, 7, 3]))

