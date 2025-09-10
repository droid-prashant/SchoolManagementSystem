import { Component } from '@angular/core';

@Component({
  selector: 'app-result',
  standalone: false,
  templateUrl: './result.component.html',
  styleUrl: './result.component.scss'
})
export class ResultComponent {
  showResultPreview: boolean = false;

  constructor() {

  }
  printResult() {
    window.open("/home/result/")
    window.print();
  }
  previewResult() {
    window.open('/result-preview', '_blank', 'width:800, height:600')
  }
}
