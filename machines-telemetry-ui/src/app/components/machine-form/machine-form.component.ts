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
  preview: string | ArrayBuffer | null = null;


  constructor(
    private fb: FormBuilder,
    private machineService: MachineService,
    private router: Router,
    private toastr: ToastrService
  ) {

    this.machineForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      image: [null, Validators.required],
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
    const file: File = this.machineForm.value.image; // <-- A imagem

    this.machineService.createMachine(payload).subscribe({
      next: (res) => {

        // Se não houver imagem, só finaliza
        if (!file) {
          this.toastr.success('Máquina criada com sucesso!', 'Sucesso');
          this.router.navigate(['/']);
          return;
        }

        // Upload da imagem
        this.machineService.uploadImage(res.id, file).subscribe({
          next: () => {
            this.toastr.success('Máquina criada com sucesso!', 'Sucesso');
            this.router.navigate(['/']);
          },
          error: (err) => {
            console.error("Erro ao enviar imagem:", err);
            this.toastr.error('Máquina criada, mas houve erro ao enviar a imagem.', 'Erro');
          }
        });
      },

      error: (err) => {
        const errorResponse = err.error;

        if (errorResponse?.title === 'MachineNameDuplicated') {
          this.toastr.error('Esse nome de máquina já está em uso.', 'Erro');
          return;
        }

        if (errorResponse?.errors) {
          const errors = errorResponse.errors;

          for (const key in errors) {
            if (errors.hasOwnProperty(key)) {
              errors[key].forEach((message: string) => {
                this.toastr.error(message, 'Erro');
              });
            }
          }
        } else {
          this.toastr.error('Ocorreu um erro ao processar a requisição.', 'Erro');
        }
      }
    });
  }



  onImageSelected(event: any) {
    const file = event.target.files[0];
    if (!file) return;

    this.machineForm.patchValue({ image: file });
    this.machineForm.get('image')?.updateValueAndValidity();

    const reader = new FileReader();
    reader.onload = () => {
      this.preview = reader.result;
    };
    reader.readAsDataURL(file);
  }

  // Helper para mensagens
  get name() { return this.machineForm.get('name') as FormControl; }
  get image() { return this.machineForm.get('image') as FormControl; }
  get latitude() { return this.machineForm.get('telemetry.latitude') as FormControl; }
  get longitude() { return this.machineForm.get('telemetry.longitude') as FormControl; }
  get status() { return this.machineForm.get('telemetry.status') as FormControl; }
}
