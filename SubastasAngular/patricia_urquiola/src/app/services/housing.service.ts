import { Injectable } from '@angular/core';
import { Product } from '../../app/models/product';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  productList: Product[];
  readonly baseUrl = 'http://localhost:5072/api/House';
  constructor() {
    this.productList= [];

   }

   async getAllproducts(): Promise<Product[]> {
    let headers = new Headers();
    headers.append('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJpbWJhX0pvZ2EiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MzgyNjQ3MTYsImV4cCI6MTczODI2NTEzNiwiaWF0IjoxNzM4MjY0NzE2fQ.0aj1ScoIed0ULksXfUel8MxbVWDlYTiUQGgYl2FHPkI');
    const data = await fetch(this.baseUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }

  async getproductById(id: number): Promise<Product | undefined> {
    const data = await fetch(`${this.baseUrl}/${id}`);
    return (await data.json()) ?? {};
  }

  submitApplication(firstName: string, lastName: string, email: string) {
    console.log(
      `Products application received: firstName: ${firstName}, lastName: ${lastName}, email: ${email}.`,
    );
  }
}
