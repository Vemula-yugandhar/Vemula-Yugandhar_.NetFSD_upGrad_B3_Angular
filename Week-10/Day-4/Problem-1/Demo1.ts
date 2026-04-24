// 1. Variable Declaration 
const userName: string = "John";
let age: number = 25;
const email: string = "john@example.com";
const isSubscribed: boolean = true;

// 2. Type Inference 
let country = "India";        
let loginCount = 10;        



// 4. Template Literal (before update)
const userProfile: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;
console.log("User Profile:", userProfile);

// 5. Operators
// Increment age by 1
age = age + 1; 

// Check eligibility for premium plan
const isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Additional operator usage
const isAdult: boolean = age >= 18;
const hasHighLogin: boolean = loginCount > 5;

// 6. Output results
console.log("Updated Age:", age);
console.log("Is Subscribed:", isSubscribed);
console.log("Eligible for Premium:", isEligibleForPremium);
console.log("Is Adult:", isAdult);
console.log("High Login Activity:", hasHighLogin);
console.log("Country (Inferred):", country);
console.log("Login Count (Inferred):", loginCount);