import { Component } from '@angular/core';
import { MapComponent } from "../../components/map/map.component";
import { Machine } from '../../interfaces/machine-interfaces';
import { MachineService } from '../../services/machine.service';
import { ActivatedRoute } from '@angular/router';
import { Telemetry } from '../../interfaces/telemetry-interfaces';
import { NgFor } from '@angular/common';
import { MachineInfoComponent } from "../../components/machine-info/machine-info.component";
import { TelemetriesListComponent } from "../../components/telemetries-list/telemetries-list.component";

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MapComponent, NgFor, MachineInfoComponent, TelemetriesListComponent],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {


  

}
