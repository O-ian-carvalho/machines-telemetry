import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-page-label',
  standalone: true,
  imports: [],
  templateUrl: './page-label.component.html',
  styleUrl: './page-label.component.css'
})
export class PageLabelComponent {
  @Input() title: string = 'Enviar';  
  @Input() description: string = 'Example description';  
}
