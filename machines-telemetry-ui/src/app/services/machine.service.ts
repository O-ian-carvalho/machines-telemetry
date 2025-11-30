import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Machine, MachinePost } from '../interfaces/machine-interfaces';
import { Telemetry } from '../interfaces/telemetry-interfaces';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MachineService {

  private controllerUrl = `${environment.apiUrl}/machines`;

  constructor(private http: HttpClient) { }

  getMachines(status?: string): Observable<Machine[]> {
    let params = new HttpParams();
    if (status) {
      params = params.set('status', status);
    }
    return this.http.get<Machine[]>(this.controllerUrl, { params });
  }

  getMachineById(id: string): Observable<Machine> {
  
    return this.http.get<Machine>(`${this.controllerUrl}/${id}` );
  }

  getTelemetriesHistoryByMAchineId(id: string): Observable<Telemetry[]> {
  
    return this.http.get<Telemetry[]>(`${this.controllerUrl}/${id}/telemetries` );
  }


  createMachine(machine: MachinePost): Observable<Machine> {
    return this.http.post<Machine>(this.controllerUrl, machine);
  }

  uploadImage(machineId: string, file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post(`${this.controllerUrl}/${machineId}/upload-image`, formData);
  }

}
