function running() {
    return 'Running';
}
function category(func, type) {
    console.log(func() + " " + type);
}
category(running, 'test');
