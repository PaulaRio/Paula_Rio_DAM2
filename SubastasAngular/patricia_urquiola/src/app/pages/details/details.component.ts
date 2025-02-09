import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';
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

  constructor(productService: ProductService) {
      const productId = parseInt(this.route.snapshot.params['id'], 10);
      productService.getproductById(productId).then((product) => {
        this.product = product;
      });
      this.productService=productService;
  }
  submitApplication() {
    this.productService.submitApplication(
      this.applyForm.value.valor ?? 0,
      
    );
  }
}
