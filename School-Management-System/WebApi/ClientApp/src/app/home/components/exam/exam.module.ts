import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterOutlet } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { ExamMarksEntryComponent } from "./exam-marks-entry/exam-marks-entry.component";
import { ExamRoutingModule } from "./exam.routes";
import { ResultComponent } from "./result/result.component";


@NgModule({
    declarations: [
        ExamMarksEntryComponent,
        ResultComponent
    ],
    imports: [
        CommonModule,
        ExamRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        RouterOutlet,
        SharedModule
    ],
    exports: [],
})
export class ExamModule { }