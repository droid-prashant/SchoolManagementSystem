import { Component, OnInit } from '@angular/core';
import { ClassRoomViewModel } from '../../class-room/shared/models/viewModels/classRoom.viewModel';
import { ApiService } from '../../../../shared/api.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentViewModel } from '../../student/shared/models/viewModels/student.viewModel';
import { CourseViewModel } from '../../course/shared/models/course.viewModel';
import { MenuItem, MessageService, PrimeIcons } from 'primeng/api';
import { Section } from '../shared/models/section.dto';

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
  sections: Section[]
  studentCategory!: FormGroup;

  isClassSelected: boolean = false;
  isMarksEntryVisible: boolean = false;

  constructor(private _apiService: ApiService,
    private _formBuilder: FormBuilder,
    private _messageService: MessageService
  ) {
    this.sections = [
      { id: 1, name: "A" },
      { id: 2, name: "B" }]

    let fb = this._formBuilder;
    this.studentCategory = fb.group({
      classRoomId: ['', Validators.required],
      sectionId: [''],
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
    return this.studentCategory.get('marks') as FormArray;
  }

  setStudentMarksFormArray() {
    const marksArray = this.studentCategory.get('marks') as FormArray;
    this.courses.forEach(course => {
      marksArray.push(this._formBuilder.group({
        courseId: [course.id, Validators.required],
        examType: [],
        creditHour: [],
        fullMarks: [],
        passMarks: [],
        obtainedMarks: [0, [Validators.required, Validators.min(0), Validators.max(100)]]
      }));
    });
  }

  onClassRoomChange() {
    let classId = this.studentCategory.controls['classRoomId'].value;
    if (classId) {
      this.isClassSelected = true;
      this.listSubject();
      this.listStudent();
    }
    else {
      this.isClassSelected = false;
    }
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
    let classId = this.studentCategory.controls['classRoomId'].value;
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
    let classId = this.studentCategory.controls['classRoomId'].value;
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
    let studentMarks = this.marks.value;
    console.log(studentMarks);

  }
}