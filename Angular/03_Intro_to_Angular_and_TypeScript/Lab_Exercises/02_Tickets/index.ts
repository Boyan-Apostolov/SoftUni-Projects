class Ticket{
    constructor(public destination:string,public price:number, public status:string) {
    }
}

function manageTickets(tickets:Array<string>,sortingCriteria:string){
    let finalTickets = new Array<Ticket>();
for (const ticket of tickets) {
    const destination = ticket.split('|')[0];
    const price = Number(ticket.split('|')[1]);
    const status = ticket.split('|')[2];

    finalTickets.push(new Ticket(destination,price,status));
}
switch (sortingCriteria){
    case 'destination': finalTickets = finalTickets.sort((a,b) => a.status.localeCompare(b.status)); break;
    case 'price': finalTickets.sort((a, b) => {return a.price - b.price;});  break;
    case 'status': finalTickets = finalTickets.sort((a,b) => a.status.localeCompare(b.status));  break;
}


var resultStr = [];
for (const ticket of finalTickets) {
    resultStr.push(`Ticket { destination: '${ticket.destination}',
    price: '${ticket.price}',
    status: '${ticket.status}' }`);
}

console.log(resultStr.join('\n'));
}


manageTickets([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'destination'
    )