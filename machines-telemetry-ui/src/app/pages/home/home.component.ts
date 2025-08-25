import { Component } from '@angular/core';
import { MachinesTableComponent } from "../../components/machines-table/machines-table.component";
import { LinkButtonComponent } from "../../components/link-button/link-button.component";
import { PageLabelComponent } from "../../components/page-label/page-label.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MachinesTableComponent, LinkButtonComponent, PageLabelComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
