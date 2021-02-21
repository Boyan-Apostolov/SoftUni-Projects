class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(name, salary, position, department) {
        if (name == '' || name == undefined || name == null) {
            throw new Error('Invalid input!')
        }
        if (position == '' || position == undefined || position == null) {
            throw new Error('Invalid input!')
        }
        if (department == '' || department == undefined || department == null) {
            throw new Error('Invalid input!')
        }
        if (salary == '' || salary == undefined || salary == null || salary < 0) {
            throw new Error('Invalid input!')
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        salary = Number(salary);
        let employee = {
            name,
            salary,
            position
        }
        this.departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }
    bestDepartment() {
        let bestDepartment;
        let bestAvgSalary = Number.NEGATIVE_INFINITY;
        for (let departmentName in this.departments) {
            let department = this.departments[departmentName]
            let personnel = 0;
            let salary = 0;
            for (const employee of department) {
                personnel++;
                salary += employee.salary
            }
            let avgSalary = salary / personnel;
            if (avgSalary > bestAvgSalary) {
                bestAvgSalary = avgSalary;
                bestDepartment = departmentName
            }
        }
        let result = [];
        result.push(`Best Department is: ${bestDepartment}`)
        result.push(`Average salary: ${bestAvgSalary.toFixed(2)}`)
        let employees = this.departments[bestDepartment];
        employees.sort((a, b) => {
            if (a.salary !== b.salary) {
                return b.salary - a.salary
            } else {
                return a.name.localeCompare(b.name);
            }
        })
        employees.map(x => result.push(`${x.name} ${x.salary} ${x.position}`))
        return result.join('\n');
    }
}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment())