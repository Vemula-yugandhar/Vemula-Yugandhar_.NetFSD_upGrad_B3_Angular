import { Student } from "./student.model";
import { PASS_MARKS } from "./constants";

// Get Grade
export function getGrade(marks: number): string {
    if (marks >= 90) return "A";
    if (marks >= 75) return "B";
    if (marks >= PASS_MARKS) return "C";
    return "Fail";
}

// Get Topper
export function getTopper(students: Student[]): Student {
    return students.reduce((topper, current) =>
        current.marks > topper.marks ? current : topper
    );
}