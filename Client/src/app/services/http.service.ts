import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IEmpleado } from '../interfaces/empleado';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrl = "https://localhost:7144";
  http = inject(HttpClient);
  
  constructor() { }

  getAllEmpleado() {
    return this.http.get<IEmpleado[]>(this.apiUrl + "/api/Empleados");
  }
}
