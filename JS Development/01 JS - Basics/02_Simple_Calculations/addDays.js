//angleToRad(['3.1416']);
function addDays([date]) {
    var splitedDate = date.split("-");
    var newDate = new Date(Number(splitedDate[2]), Number(splitedDate[1]), Number(splitedDate[0]));
    newDate.setDate(newDate.getDate() + 1000);
    console.log(newDate);
}
