// 1. Function with Required Parameters
function getWelcomeMessage(name: string): string {
    return `Welcome ${name}! Glad to have you on board.`;
}

// 2. Optional Parameters
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age information.`;
}

// 3. Default Parameters
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name} is subscribed to the service.`
        : `${name} is not subscribed to the service.`;
}

// 4. Return Type (boolean)
function isEligibleForPremium(age: number): boolean {
    return age > 18;
}

// 5. Arrow Function 
const getAccountUpdateMessage = (name: string): string => {
    return `Hello ${name}, your account has been updated successfully.`;
};

// 6. Lexical 'this' using Arrow Function
const notificationService = {
    appName: "UserNotifyApp",

    sendNotification: (message: string): string => {
        // Arrow function preserves lexical this
        return `[${notificationService.appName}] ${message}`;
    }
};

// 7. Execution

const name: string = "John";

console.log(getWelcomeMessage(name));

console.log(getUserInfo(name, 25));     
console.log(getUserInfo(name));         

console.log(getSubscriptionStatus(name, true));
console.log(getSubscriptionStatus(name));  

console.log("Eligible for Premium:", isEligibleForPremium(20));

console.log(getAccountUpdateMessage(name));

console.log(notificationService.sendNotification("Your subscription is active."));