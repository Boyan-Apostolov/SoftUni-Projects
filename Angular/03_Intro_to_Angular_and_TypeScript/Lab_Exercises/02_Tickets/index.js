var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
function manageTickets(tickets, sortingCriteria) {
    var finalTickets = new Array();
    for (var _i = 0, tickets_1 = tickets; _i < tickets_1.length; _i++) {
        var ticket = tickets_1[_i];
        var destination = ticket.split('|')[0];
        var price = Number(ticket.split('|')[1]);
        var status_1 = ticket.split('|')[2];
        finalTickets.push(new Ticket(destination, price, status_1));
    }
    switch (sortingCriteria) {
        case 'destination':
            finalTickets = finalTickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
            break;
        case 'price':
            finalTickets.sort(function (a, b) { return a.price - b.price; });
            break;
        case 'status':
            finalTickets = finalTickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
            break;
    }
    var resultStr = [];
    for (var _a = 0, finalTickets_1 = finalTickets; _a < finalTickets_1.length; _a++) {
        var ticket = finalTickets_1[_a];
        resultStr.push("Ticket { destination: '" + ticket.destination + "',\n    price: '" + ticket.price + "',\n    status: '" + ticket.status + "' }");
    }
    console.log(resultStr.join('\n'));
}
manageTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'destination');
