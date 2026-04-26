// 1. Generic Function
function getFirstElement<T>(items: T[]): T {
    return items[0];
}

// 2. Generic Interface
interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}

// 3. Generic Class
class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    // Add item
    public add(item: T): void {
        this.items.push(item);
    }

    // Get all items
    public getAll(): T[] {
        return this.items;
    }
}

// 4. Models

interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}

// 5. Use Case Implementation

// User Data Manager
const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "John" });
userManager.add({ id: 2, name: "Alice" });

// Product Data Manager
const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });

// 6. Testing & Output

// Get all users
const users = userManager.getAll();
console.log("Users:", users);

// Get all products
const products = productManager.getAll();
console.log("Products:", products);

// Using Generic Function
console.log("First User:", getFirstElement<User>(users));
console.log("First Product:", getFirstElement<Product>(products));