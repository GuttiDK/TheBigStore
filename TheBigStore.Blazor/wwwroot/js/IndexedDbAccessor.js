export function initialize() {
    let Cart = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    Cart.onupgradeneeded = function () {
        let db = Cart.result;
        db.createObjectStore("items", { keyPath: "id", autoIncrement: true});
    }
}

export function set(collectionName, value) {
    let Cart = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

    Cart.onsuccess = function () {
        let transaction = Cart.result.transaction(collectionName, "readwrite");
        let collection = transaction.objectStore(collectionName)
        collection.put(value);
    }
}

export async function getAll(collectionName) {
    let request = new Promise((resolve) => {
        let Cart = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        Cart.onsuccess = function () {
            let transaction = Cart.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);
            let result = collection.getAll();

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }
    });

    let result = await request;

    return result;
}

export async function get(collectionName, id) {
    let request = new Promise((resolve) => {
        let Cart = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        Cart.onsuccess = function () {
            let transaction = Cart.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);
            let result = collection.get(id);

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }
    });

    let result = await request;

    return result;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "Cart";