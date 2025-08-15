import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentDto } from '../home/components/student/shared/models/dtos/student.dto';
import { StudentViewModel } from '../home/components/student/shared/models/viewModels/student.viewModel';
import { ClassRoomViewModel } from '../home/components/class-room/shared/models/viewModels/classRoom.viewModel';
import { CourseDto } from '../home/components/course/shared/models/course.dto';
import { CourseViewModel } from '../home/components/course/shared/models/course.viewModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string = environment.API_BASE_URL;
  constructor(private _httpClient: HttpClient) { }

  postStudent(student: StudentDto): Observable<void> {
    return this._httpClient.post<void>(this.baseUrl + "api/Student/AddStudent", student);
  }

  getStudents(): Observable<StudentViewModel[]> {
    return this._httpClient.get<StudentViewModel[]>(this.baseUrl + "api/Student/GetStudent");
  }
  getStudentsByClass(classId: string): Observable<StudentViewModel[]> {
    return this._httpClient.get<StudentViewModel[]>(this.baseUrl + `api/Student/GetStudentByClassId?classId=${classId}`);
  }

  getClassRooms(): Observable<ClassRoomViewModel[]> {
    return this._httpClient.get<ClassRoomViewModel[]>(this.baseUrl + "api/ClassRoom/GetClassRoom")
  }

  postCourse(course: CourseDto): Observable<void> {
    return this._httpClient.post<void>(this.baseUrl + "api/Course/AddCourse", course);
  }

  getCourses(): Observable<CourseViewModel[]> {
    return this._httpClient.get<CourseViewModel[]>(this.baseUrl + "api/Course/GetCourse");
  }
  getCoursesByClass(classId: string): Observable<CourseViewModel[]> {
    return this._httpClient.get<CourseViewModel[]>(this.baseUrl + `api/Course/GetCourseByClassId?classId=${classId}`);
  }
}
