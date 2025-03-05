import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../settings/appsettings';
import { RegisterDTO } from '../interfaces/register';
import { Observable } from 'rxjs';
import { ResponseAcceso } from '../interfaces/responseAcceso';
import { LoginDTO } from '../interfaces/login';

@Injectable({
     providedIn: 'root'
})
export class AccesoService {

     private https = inject(HttpClient);
     private baseUrl: string = appsettings.apiUrl;

     constructor() { }

     registrarse(objeto: RegisterDTO): Observable<ResponseAcceso> {
          return this.https.post<ResponseAcceso>(`${this.baseUrl}users/register`, objeto)
     }

     login(objeto: LoginDTO): Observable<ResponseAcceso> {
          return this.https.post<ResponseAcceso>(`${this.baseUrl}users/login`, objeto)
     }

     validarToken(): Observable<ResponseAcceso> {
          return this.https.get<ResponseAcceso>(`${this.baseUrl}users/validar`)
     }
} 
