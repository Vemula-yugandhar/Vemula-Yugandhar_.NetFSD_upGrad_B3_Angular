import { Student } from "./student.model";

// Capitalize Name
export function formatName(name: string): string {
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}

// Calculate Average Marks
export function calculateAverage(students: Student[]): number {
    const total = students.reduce((sum, s) => sum + s.marks, 0);
    return students.length ? total / students.length : 0;
}