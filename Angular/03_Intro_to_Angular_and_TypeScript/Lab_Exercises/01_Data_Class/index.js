var DataRequest = /** @class */ (function () {
    function DataRequest(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
    return DataRequest;
}());
var myData = new DataRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData);
