import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MachineService } from '../../services/machine.service';
import { Router } from '@angular/router';
import { SubmitButtonComponent } from '../submit-button/submit-button.component';
import { NgIf } from '@angular/common';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-machine-form',
  standalone: true,
  imports: [ReactiveFormsModule, SubmitButtonComponent, FormsModule, NgIf, ToastrModule],
  templateUrl: './machine-form.component.html',
  styleUrls: ['./machine-form.component.css']
})
export class MachineFormComponent {

  machineForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private machineService: MachineService,
    private router: Router,
    private toastr: ToastrService
  ) {

    this.machineForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      telemetry: this.fb.group({
        latitude: [null, [Validators.required, Validators.min(-90), Validators.max(90)]] ,
        longitude: [null, [Validators.required, Validators.min(-180), Validators.max(180)]],
        status: ['', Validators.required]
      })
    });

  }

  submit() {
    if (this.machineForm.invalid) return;

    const payload = this.machineForm.value;
    this.machineService.createMachine(payload).subscribe({
      next: (res) => {
        this.toastr.success('Máquina criada com sucesso!', 'Sucesso');
        this.router.navigate(['/']);
      },
      error: (err) => this.toastr.error('falha ao criar máquina!', 'Erro')
    });
  }

  // Helper para mensagens
  get name() { return this.machineForm.get('name') as FormControl; }
  get latitude() { return this.machineForm.get('telemetry.latitude') as FormControl; }
  get longitude() { return this.machineForm.get('telemetry.longitude') as FormControl; }
  get status() { return this.machineForm.get('telemetry.status') as FormControl; }
}
