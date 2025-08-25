import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Machine, MachinePost } from '../interfaces/machine-interfaces';


@Injectable({
  providedIn: 'root'
})
export class MachineService {

  private apiUrl = 'http://localhost:5095/api/machines';

  constructor(private http: HttpClient) { }

  getMachines(status?: string): Observable<Machine[]> {
    let params = new HttpParams();
    if (status) {
      params = params.set('status', status);
    }
    return this.http.get<Machine[]>(this.apiUrl, { params });
  }


  createMachine(machine: MachinePost): Observable<Machine> {
    return this.http.post<Machine>(this.apiUrl, machine);
  }
}
