import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExamMarksEntryComponent } from './exam-marks-entry/exam-marks-entry.component';

const routes: Routes = [
    {path:'exam-marks-entry', component:ExamMarksEntryComponent},
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ExamRoutingModule { }
