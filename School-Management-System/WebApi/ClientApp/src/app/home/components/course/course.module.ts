import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterOutlet } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { AddCourseComponent } from "./add-course/add-course.component";
import { ListCourseComponent } from "./list-course/list-course.component";
import { CourseRoutingModule } from "./course.routes";


@NgModule({
    declarations: [
        AddCourseComponent,
        ListCourseComponent
    ],
    imports: [
        CommonModule,
        CourseRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        RouterOutlet,
        SharedModule
    ],
    exports: [],
})
export class CourseModule { }