import { Student } from "./student.model";
import { getGrade, getTopper } from "./student.service";
import { formatName, calculateAverage } from "./utils";

// Sample Data
const students: Student[] = [
    { id: 1, name: "john", marks: 85 },
    { id: 2, name: "alice", marks: 92 },
    { id: 3, name: "bob", marks: 67 }
];

// Formatted Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});

// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`);
});

// Average Marks
const avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);

// Topper
const topper = getTopper(students);
console.log("\nTopper:", formatName(topper.name), "-", topper.marks);