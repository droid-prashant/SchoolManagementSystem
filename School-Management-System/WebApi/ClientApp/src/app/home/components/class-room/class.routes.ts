import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListClassComponent } from './list-class/list-class.component';

const routes: Routes = [
    {path:'list-class', component:ListClassComponent},
    // {path:'add-class', component:AddStudentComponent}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ClassRoutingModule { }
