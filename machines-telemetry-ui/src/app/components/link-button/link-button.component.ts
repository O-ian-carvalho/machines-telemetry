import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-link-button',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './link-button.component.html',
  styleUrl: './link-button.component.css'
})
export class LinkButtonComponent {
    @Input() url: string = "";
    @Input() title: string = "Indefinido";
}
