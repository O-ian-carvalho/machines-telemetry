import { Component } from '@angular/core';
import { MachineFormComponent } from "../../components/machine-form/machine-form.component";
import { PageLabelComponent } from "../../components/page-label/page-label.component";

@Component({
  selector: 'app-create-machine',
  standalone: true,
  imports: [MachineFormComponent, PageLabelComponent],
  templateUrl: './create-machine.component.html',
  styleUrl: './create-machine.component.css'
})
export class CreateMachineComponent {

}
