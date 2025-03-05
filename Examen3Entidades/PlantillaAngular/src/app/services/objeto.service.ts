import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../settings/appsettings';
import { Objeto } from '../interfaces/objeto';
import { Observable } from 'rxjs';


@Injectable({
     providedIn: 'root'
})
export class ObjetoService {
     private http = inject(HttpClient);
     private baseUrl: string = appsettings.apiUrl;
     constructor() { }

     private getAuthHeaders(): { [key: string]: string } {
          const token = localStorage.getItem('token');
          return {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          };
        }
     lista() : Observable<Objeto[]>{
          return  this.http.get<Objeto[]>(`${this.baseUrl}Object`)
       }

     async getObjectById(id: number): Promise<Objeto | undefined> {
          const response = await fetch(`${this.baseUrl}Object/${id}`, {
            method: 'GET',
            headers: this.getAuthHeaders()
          });
          return (await response.json()) as Objeto | undefined;
        }
      
        async updateObjeto(id: number, partialObjeto: Partial<Objeto>): Promise<Objeto> {
          const response = await fetch(`${this.baseUrl}Object/${id}`, {
            method: "PATCH",
            headers: this.getAuthHeaders(),
            body: JSON.stringify(partialObjeto)
          });
      
          return await response.json();
        }
      
        async createObjeto(objeto: Objeto): Promise<Objeto> {
          const response = await fetch(`${this.baseUrl}Object`, {
            method: "POST",
            headers: this.getAuthHeaders(),
            body: JSON.stringify(objeto)
          });
      
          return await response.json();
        }
        
        async deleteObjeto(id: number): Promise<boolean> {
          const response = await fetch(`${this.baseUrl}Object/${id}`, {
            method: "DELETE",
            headers: this.getAuthHeaders()
          });
        
          return response.ok; // Devuelve `true` si la eliminación fue exitosa
        }

}
