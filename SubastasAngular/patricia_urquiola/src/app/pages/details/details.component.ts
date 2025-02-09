import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { Puja } from 'src/app/models/puja';
import { ProductService } from 'src/app/services/product.service';
import { PujaService } from 'src/app/services/puja.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-details',
  imports: [ReactiveFormsModule],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  

  applyForm = new FormGroup({
    valor: new FormControl(0),
   
  });
  
  product: Product | undefined;
  productService: ProductService;
  puja: Puja | undefined;
  pujaService: PujaService;
  
  constructor(productService: ProductService, pujaService: PujaService) {
      this.pujaService = pujaService;
      const productId = parseInt(this.route.snapshot.params['id'], 10);
      productService.getproductById(productId).then((product) => {
        this.product = product;  
      });
      this.load(productId);
      this.productService=productService;
  }
  load(idProduct: number) {
    this.pujaService.getTopPuja(idProduct).then((topPuja) => {
      this.puja = topPuja;
    });
  }

  async submitApplication() {
      const bid = this.applyForm.value.valor ?? 0;
      const nuevaPuja: Puja = {
        id: 0,  
        bid: bid,
        idProduct: this.product?.id ?? 0
      }; 
      
        this.pujaService.postPuja(nuevaPuja).then((response) => {
          console.log('Puja añadida con éxito:', response);
          this.load(nuevaPuja.idProduct);
        });
        
        this.applyForm.reset();
      
  }
}
