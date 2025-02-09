import { Injectable } from '@angular/core';
import { Puja } from '../models/puja';

@Injectable({
  providedIn: 'root'
})
export class PujaService {
  pujaList: Puja[];
  readonly baseUrl = 'http://localhost:7777/api/Puja';
  constructor() {
    this.pujaList= [];

   }

   async getAllpujas(): Promise<Puja[]> {
    let headers = new Headers();
    headers.append('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJpbWJhX0pvZ2EiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MzgyNjQ3MTYsImV4cCI6MTczODI2NTEzNiwiaWF0IjoxNzM4MjY0NzE2fQ.0aj1ScoIed0ULksXfUel8MxbVWDlYTiUQGgYl2FHPkI');
    const data = await fetch(this.baseUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }

  async getpujaById(id: number): Promise<Puja | undefined> {
    const data = await fetch(`${this.baseUrl}/${id}`);
    return (await data.json()) ?? {};
  }
  async getTopPuja(idProduct:number): Promise<Puja> {
    const response = await fetch(`${this.baseUrl}/top/${idProduct}`);
    return await response.json();
  }
  
  async postPuja(puja: Puja) {
    const headers = new Headers();
    headers.append('Authorization', 'Bearer your_jwt_token');
    headers.append('Content-Type', 'application/json');

    const response = await fetch(`${this.baseUrl}/${puja.idProduct}/addPuja`, {
      method: 'POST',
      headers: headers,
      body: JSON.stringify(puja),
    });

    const data = await response.json();
    return data; 
  }
}
