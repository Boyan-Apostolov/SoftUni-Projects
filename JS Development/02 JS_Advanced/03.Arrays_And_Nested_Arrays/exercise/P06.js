function biggerHalf(nums) {
    nums.sort((a, b) => { return a - b; });
    return nums.slice(Math.floor(nums.length / 2));
}
console.log(biggerHalf([4, 7, 2, 5]));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));
