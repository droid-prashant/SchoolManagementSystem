import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../../../shared/api.service';
import { Router } from '@angular/router';
import { ClassRoomViewModel } from '../../class-room/shared/models/viewModels/classRoom.viewModel';

@Component({
  selector: 'app-add-student',
  standalone: false,
  templateUrl: './add-student.component.html',
  styleUrl: './add-student.component.scss'
})
export class AddStudentComponent implements OnInit {
  genders: any[] = []
  classRooms: ClassRoomViewModel[] = []
  studentForm: FormGroup
  constructor(private _fb: FormBuilder,
    private _apiService: ApiService,
    private _router: Router
  ) {
    let fb = this._fb;
    this.studentForm = fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      grandFatherName: ['', Validators.required],
      fatherName: ['', Validators.required],
      motherName: ['', Validators.required],
      gender: [null, Validators.required],
      age: [null, [Validators.required, Validators.min(1)]],
      address: ['', Validators.required],
      contactNumber: ['', Validators.required],
      classRoomId: [null, Validators.required]
    });
  }
  ngOnInit(): void {
    this.genders = [
      { label: 'Male', value: 1 },
      { label: 'Female', value: 2 },
      { label: 'Other', value: 3 }
    ];
    this.getClassRooms();
  }

  getClassRooms() {
    this._apiService.getClassRooms().subscribe(
      {
        next: (response) => 
          {
            this.classRooms = response;
            console.log(this.classRooms);
          },
        error: (err) => console.log(err),
        complete: () => console.log("Request is complete")
      }
    )
  }

  addStudent() {
    let student = this.studentForm.value;
    this._apiService.postStudent(student).subscribe(
      {
        next: (response) => this._router.navigateByUrl("/home/student/list-student"),
        error: (err) => console.log(err),
        complete: () => console.log("Request is complete")
      }
    )
  }
}
