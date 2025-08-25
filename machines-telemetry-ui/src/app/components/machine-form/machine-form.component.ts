import { Component } from '@angular/core';
import { MachinePost } from '../../interfaces/machine-interfaces';
import { MachineService } from '../../services/machine.service';
import { FormsModule } from '@angular/forms';
import { SubmitButtonComponent } from "../submit-button/submit-button.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-machine-form',
  standalone: true,
  imports: [FormsModule, SubmitButtonComponent],
  templateUrl: './machine-form.component.html',
  styleUrl: './machine-form.component.css'
})
export class MachineFormComponent {
  machine: MachinePost = {
    name: '',
    telemetry: {
      latitude: 0,
      longitude: 0,
      status: ''
    }
  };

  constructor(private machineService: MachineService, private router: Router) {}

    submit() {
    this.machineService.createMachine(this.machine).subscribe({
      next: (res) => {
        console.log('Máquina criada:', res);
        this.router.navigate(['/']);
      },
      error: (err) => console.error('Erro ao criar máquina:', err)
    });
  }


}
