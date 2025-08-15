import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../../shared/api.service';
import { ClassRoomViewModel } from '../shared/models/viewModels/classRoom.viewModel';

@Component({
  selector: 'app-list-class',
  standalone: false,
  templateUrl: './list-class.component.html',
  styleUrl: './list-class.component.scss'
})
export class ListClassComponent implements OnInit {
  classList: ClassRoomViewModel[] = [];

  constructor(private _apiService: ApiService) { }
  ngOnInit(): void {
    this.listClass();
  }

  listClass() {
    this._apiService.getClassRooms().subscribe({
      next: (response) => {
        this.classList = response;
      },
      error: (err) => {

      },
      complete: () => console.log("Req Complete")
    })
  }
}
