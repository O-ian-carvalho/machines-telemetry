import { Component } from '@angular/core';
import { LinkButtonComponent } from "../link-button/link-button.component";
import { Machine } from '../../interfaces/machine-interfaces';
import { MachineService } from '../../services/machine.service';
import { NgFor, NgStyle } from '@angular/common';
import { Helpers } from '../../helpers/helpers';


@Component({
  selector: 'app-machines-table',
  standalone: true,
  imports: [LinkButtonComponent, NgFor, NgStyle],
  templateUrl: './machines-table.component.html',
  styleUrl: './machines-table.component.css'
})
export class MachinesTableComponent {
  
  Helpers = Helpers;
  machines: Machine[] = [];
  statusBgColor = 'white';

  constructor(private machineService: MachineService) {}

    
  ngOnInit(): void {
      this.getMachines()
  }

  // TODO: Implementar paginação
  getMachines(status? : string):void{
     this.machineService.getMachines(status).subscribe({
      next: (data) => this.machines = data,
      error: (err) => console.error(err)
    });
  }

  onSelectChange(event: Event) {
    const value = (event.target as HTMLSelectElement).value;
    this.getMachines(value)
  }

    
  getStatusColor(status: string): string {
    switch (status) {
      case 'Maintenance':
        return 'lightyellow';
      case 'Operating':
        return 'lightgreen';
      case 'Stopped':
        return 'lightcoral';
      default:
        return 'lightgray';
    }
  }

  
}

