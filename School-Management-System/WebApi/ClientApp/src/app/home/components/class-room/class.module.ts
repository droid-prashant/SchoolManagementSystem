import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../../shared/shared.module";
import { HttpClientModule } from "@angular/common/http";
import { ClassRoutingModule } from "./class.routes";
import { ListClassComponent } from "./list-class/list-class.component";


@NgModule({
    declarations: [
        ListClassComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ClassRoutingModule,
        SharedModule,
        FormsModule,
        HttpClientModule
    ],
    exports: [],
})
export class ClassModule { }