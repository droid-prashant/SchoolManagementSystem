import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../../shared/api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClassRoomViewModel } from '../../class-room/shared/models/viewModels/classRoom.viewModel';

@Component({
  selector: 'app-add-course',
  standalone: false,
  templateUrl: './add-course.component.html',
  styleUrl: './add-course.component.scss'
})
export class AddCourseComponent implements OnInit {
  courseForm: FormGroup;
  classRooms: ClassRoomViewModel[] = []
  courseTypes: { id: number, type: string, typeAbbr: string }[] = [];
  constructor(private _apiService: ApiService,
    private _formBuilder: FormBuilder,
    private _router: Router
  ) {
    let fb = this._formBuilder;
    this.courseForm = fb.group({
      name: ['', Validators.required],
      creditHour: ['', Validators.required],
      classRoomId: [null, Validators.required],
      courseType: ['', Validators.required],
      fullMarks: [0, Validators.required],
      passMarks: [0, Validators.required]
    });
  }
  ngOnInit(): void {
    this.courseTypes.push({ id: 1, type: "Theory", typeAbbr: "TH" }, { id: 2, type: "Practical", typeAbbr: "PR" })
    this.getClassRooms();
  }

  addCourse() {
    let course = this.courseForm.value;
    this._apiService.postCourse(course).subscribe(
      {
        next: (response) => this._router.navigateByUrl("/home/course/list-course"),
        error: (err) => console.log(err),
        complete: () => console.log("Request is complete")
      }
    )
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
}
