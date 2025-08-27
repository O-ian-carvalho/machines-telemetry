import { Component } from '@angular/core';
import { MachineService } from '../../services/machine.service';
import { ActivatedRoute } from '@angular/router';
import { Telemetry } from '../../interfaces/telemetry-interfaces';
import { DatePipe, NgFor } from '@angular/common';
import { Helpers } from '../../helpers/helpers';


@Component({
  selector: 'app-telemetries-list',
  standalone: true,
  imports: [NgFor, DatePipe],
  templateUrl: './telemetries-list.component.html',
  styleUrl: './telemetries-list.component.css'
})
export class TelemetriesListComponent {
  Helpers = Helpers
  telemetries: Telemetry[] = [];

  constructor(
    private machineService: MachineService,
    private route: ActivatedRoute 
  ) {}

  ngOnInit(): void {
    this.getMachinesTelemtry();
  }



  getMachinesTelemtry():void{
    const id = this.route.snapshot.paramMap.get('id');
     this.machineService.getTelemetriesHistoryByMAchineId(id!).subscribe({
      next: (data) => this.telemetries = data,
      error: (err) => console.error(err)
    });
  }

    
  
}
