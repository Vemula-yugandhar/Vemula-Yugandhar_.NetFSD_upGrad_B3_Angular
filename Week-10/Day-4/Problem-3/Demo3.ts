// 1. Base Class: Employee
class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    // Constructor
    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    // 2. Getter
    public getSalary(): number {
        return this.salary;
    }

    // 2. Setter with validation
    public setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be greater than 0");
        }
    }

    // 3. Method
    public displayDetails(): void {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Employee Name: ${this.name}`);
        console.log(`Employee Salary: ${this.salary}`);
    }
}

// 4. Derived Class: Manager
class Manager extends Employee {
    public teamSize: number;

    // Constructor using super
    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }

    // 5. Method Overriding
    public displayDetails(): void {
        super.displayDetails(); // call base method
        console.log(`Team Size: ${this.teamSize}`);
    }
}

// 6. Object Creation

// Employee object
const emp1 = new Employee(101, "John", 30000);

// Manager object
const mgr1 = new Manager(201, "Alice", 60000, 5);

// Calling methods
console.log("----- Employee Details -----");
emp1.displayDetails();

// Using getter and setter
console.log("Current Salary:", emp1.getSalary());
emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());

console.log("\n----- Manager Details -----");
mgr1.displayDetails();