export function initialize() {
    var expires;
        var date = new Date();
        date.setTime(date.getTime() + (3 * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    document.cookie = "Cart" + "=" + expires + "; path=/";
}

export function get() {
    return document.cookie;
}

export function set(value) {
    document.cookie = `${value}`;
}