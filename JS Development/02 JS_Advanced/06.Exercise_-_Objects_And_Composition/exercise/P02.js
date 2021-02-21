function solve(input) {
    let weight = Number(input['weight'])
    let experience = Number(input['experience'])
    let levelOfHydrated = Number(input['levelOfHydrated'])
    let dizziness = input['dizziness']

    if (dizziness) {
        levelOfHydrated += 0.1 * weight * experience;
        dizziness = false;
    }

    return {
        weight, experience, levelOfHydrated, dizziness
    }
}
console.log(solve({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
))