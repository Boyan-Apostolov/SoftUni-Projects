function timeToWalk(steps,footprint,speed){
    let distance = footprint * steps;
    let rest = Math.floor(distance / 500) * 60;

    let speedInM = speed*1000/3600;    
    let time = distance / speedInM;
    time += rest;
    let hours = Math.floor(time / 3600).toFixed(0).padStart(2,"0");
    let minutes = Math.floor((time - hours*3600)/60).toFixed(0).padStart(2,"0");
    let seconds =(time % 60).toFixed(0).padStart(2,"0");
    return `${hours}:${minutes}:${seconds}`;
}
console.log(timeToWalk(4000, 0.60, 5))
console.log(timeToWalk(2564, 0.70, 5.5))