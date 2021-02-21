function solve(flavors,startingFlavor,engingFlavor){
    let startingIndex = flavors.indexOf(startingFlavor);
    let endginIndex = flavors.indexOf(engingFlavor);
    return flavors.slice(startingIndex,endginIndex+1);
}
console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
))
console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
))