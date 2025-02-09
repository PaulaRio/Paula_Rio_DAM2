import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productList: Product[];
  readonly baseUrl = 'https://localhost:7777/api/Product';
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

  submitApplication(valor: number) {
    console.log(
      `Products application received: valor: ${valor}`,
    );
  }
}
