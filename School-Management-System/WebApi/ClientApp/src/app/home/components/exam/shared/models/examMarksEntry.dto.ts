export interface SubjectMarkDto {
  studentId: string;              
  examType: string;               
  studentMarksLists: StudentMarksList[];
}

export interface StudentMarksList {
  courseId: string;              
  theoryCredit: number;
  practicalCredit: number;
  fullTheoryMarks: number;
  passTheoryMarks: number;
  fullPracticalMarks: number;
  passPracticalMarks: number;
  obtainedTheoryMarks: number;
  obtainedPracticalMarks: number;
}