import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../../shared/api.service';
import { CourseRoutingModule } from '../course.routes';
import { CourseViewModel } from '../shared/models/course.viewModel';
import { MenuItem, PrimeIcons } from 'primeng/api';
import { ClassRoomViewModel } from '../../class-room/shared/models/viewModels/classRoom.viewModel';

@Component({
  selector: 'app-list-course',
  standalone: false,
  templateUrl: './list-course.component.html',
  styleUrl: './list-course.component.scss'
})
export class ListCourseComponent implements OnInit {
  courses: CourseViewModel[] = [];
  classRooms: ClassRoomViewModel[] = [];
  actionItems: MenuItem[] = [];
  constructor(private _apiService: ApiService) {
    this.actionItems = [
      {
        icon: PrimeIcons.EYE,
        command: () => {

        }
      }
    ];
  }
  ngOnInit(): void {
    this.listCourse();
    this.getClassRooms();
  }

  listCourse() {
    this._apiService.getCourses().subscribe(
      {
        next: (response) => {
          this.courses = response;
          console.log(this.courses);
        },
        error: (error) => {

        },
        complete: () => {

        }
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
