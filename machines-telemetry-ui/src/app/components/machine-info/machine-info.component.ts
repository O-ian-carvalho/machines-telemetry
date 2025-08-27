import { Component } from '@angular/core';
import { MachineService } from '../../services/machine.service';
import { ActivatedRoute } from '@angular/router';
import { Machine } from '../../interfaces/machine-interfaces';
import { MapComponent } from "../map/map.component";

@Component({
  selector: 'app-machine-info',
  standalone: true,
  imports: [MapComponent],
  templateUrl: './machine-info.component.html',
  styleUrl: './machine-info.component.css'
})
export class MachineInfoComponent {
    machine: Machine | null = null;
  
    constructor(
      private machineService: MachineService,
      private route: ActivatedRoute 
    ) {}
  
    ngOnInit(): void {
      this.getMachine();
    }
  
  
    getMachine(): void {
      const id = this.route.snapshot.paramMap.get('id');
        console.log(id)
      if (id) {
       
        this.machineService.getMachineById(id).subscribe({
          next: (data) => this.machine = data,
          error: (err) => console.error(err)
        });
        
      } else {
        console.error('ID da máquina não encontrado na rota!');
      }
      
    }
}
