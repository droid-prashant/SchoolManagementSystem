import { Component, OnInit } from '@angular/core';
import { ClassRoomViewModel } from '../../class-room/shared/models/viewModels/classRoom.viewModel';
import { ApiService } from '../../../../shared/api.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentViewModel } from '../../student/shared/models/viewModels/student.viewModel';
import { CourseViewModel } from '../../course/shared/models/course.viewModel';
import { MenuItem, MessageService, PrimeIcons } from 'primeng/api';
import { Section } from '../shared/models/section.dto';
import { ExamTerminal } from '../shared/models/examTerminal.dto';
import { StudentMarksList, SubjectMarkDto } from '../shared/models/examMarksEntry.dto';

@Component({
  selector: 'app-exam-marks-entry',
  standalone: false,
  templateUrl: './exam-marks-entry.component.html',
  styleUrl: './exam-marks-entry.component.scss'
})
export class ExamMarksEntryComponent implements OnInit {
  classRooms: ClassRoomViewModel[] = []
  students: StudentViewModel[] = [];
  courses: CourseViewModel[] = [];
  sections: Section[];
  examTerminals: ExamTerminal[] = [];

  studentMarks!: FormGroup;

  isClassSelected: boolean = false;
  isMarksEntryVisible: boolean = false;

  constructor(private _apiService: ApiService,
    private _formBuilder: FormBuilder,
    private _messageService: MessageService
  ) {
    this.sections = [
      { id: 1, name: "A" },
      { id: 2, name: "B" }]

    this.examTerminals = [
      { id: 1, terminalName: 'First Terminal' },
      { id: 2, terminalName: 'Second Terminal' },
      { id: 3, terminalName: 'Third Terminal' },
      { id: 4, terminalName: 'Final Terminal' }
    ]

    let fb = this._formBuilder;
    this.studentMarks = fb.group({
      classRoomId: ['', Validators.required],
      examType: [''],
      marks: fb.array([])
    });
  }

  ngOnInit(): void {
    this.getClassRooms();
  }

  getFormGroup(index: number): FormGroup {
    return this.marks.at(index) as FormGroup
  }

  get marks(): FormArray {
    return this.studentMarks.get('marks') as FormArray;
  }

  setStudentMarksFormArray() {
    const marksArray = this.studentMarks.get('marks') as FormArray;
    this.courses.forEach(course => {
      marksArray.push(this._formBuilder.group({
        courseId: [course.id, Validators.required],
        examType: ['Test', Validators.required],
        creditHour: [course.creditHour, Validators.required],
        fullMarks: [course.fullMarks, Validators.required],
        passMarks: [course.passMarks, Validators.required],
        obtainedMarks: [0, [Validators.required, Validators.min(0), Validators.max(100)]]
      }));
    });
  }

  onClassRoomChange() {
    let classId = this.studentMarks.controls['classRoomId'].value;
    if (classId) {
      this.isClassSelected = true;
      this.listSubject();
      this.listStudent();
    }
    else {
      this.isClassSelected = false;
    }
  }

  onExamTerminalChange() {

  }

  getClassRooms() {
    this._apiService.getClassRooms().subscribe(
      {
        next: (response) => {
          this.classRooms = response;
        },
        error: (err) => console.log(err),
        complete: () => console.log("Request is complete")
      }
    )
  }

  listSubject() {
    let classId = this.studentMarks.controls['classRoomId'].value;
    this._apiService.getCoursesByClass(classId).subscribe(
      {
        next: (response) => {
          this.courses = response;
          this.setStudentMarksFormArray();
        },
        error: (error) => {

        },
        complete: () => {

        }
      }
    )
  }

  listStudent() {
    let classId = this.studentMarks.controls['classRoomId'].value;
    this._apiService.getStudentsByClass(classId).subscribe(
      {
        next: (response) => {
          this.students = response;
        },
        error: (err) => {

        },
        complete: () => console.log("Req is completed")
      }
    )
  }

  showDialog() {
    this.isMarksEntryVisible = true;
  }

  saveStudentMarks() {
    let studentMarks: SubjectMarkDto = this.studentMarks.value;
    let theoryPracticalCommon = studentMarks.studentMarksLists.forEach(x => {
      
    })
    this._apiService.postStudentMarks(studentMarks).subscribe(
      {
        next: (response) => {

        },
        error: (err) => {

        },
        complete: () => console.log("Req is completed")
      }
    )
  }
}