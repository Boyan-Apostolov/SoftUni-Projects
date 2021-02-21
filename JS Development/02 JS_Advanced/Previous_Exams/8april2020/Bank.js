class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer({ firstName, lastName, personalId }) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);
        if (customer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`)
        }
        this.allCustomers.push({ firstName, lastName, personalId, totalMoney: 0, transactions: [] });

        return {
            firstName,
            lastName,
            personalId
        }
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`)
        }
        customer.totalMoney += amount;

        let transaction = {
            number: customer.transactions.length + 1,
            names: `${customer.firstName} ${customer.lastName}`,
            type: `deposit`,
            amount: amount
        }

        customer.transactions.push(transaction)

        return `${customer.totalMoney}$`
    }
    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`)
        }
        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }

        customer.totalMoney -= amount;

        let transaction = {
            number: customer.transactions.length + 1,
            names: `${customer.firstName} ${customer.lastName}`,
            type: `withdrew`,
            amount: amount
        }

        customer.transactions.push(transaction)

        return `${customer.totalMoney}$`
    }
    customerInfo(personalId) { 
        let customer = this.allCustomers.find(x => x.personalId == personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`)
        }

        let result = [];
        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${customer.firstName} ${customer.lastName}`)
        result.push(`Customer ID: ${customer.personalId}`)
        result.push(`Total Money: ${customer.totalMoney}$`)
        result.push("Transactions:")

        for (const transaction of customer.transactions.sort((a,b)=>b.number - a.number)) {
            if(transaction.type == 'withdrew'){
                result.push(`${transaction.number}. ${transaction.names} ${transaction.type} ${transaction.amount}$!`)
            } else {
                result.push(`${transaction.number}. ${transaction.names} made ${transaction.type} of ${transaction.amount}$!`)
            }
        }
        return result.join('\n')
    }
}
let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));
console.log(bank.withdrawMoney(6233267, 900));

console.log(bank.customerInfo(6233267));


/*
•	number of the transaction in descending order;
•	names (firstName, lastName);
•	if the transaction is deposit/withdraw;
•	amount of the transaction.
 */