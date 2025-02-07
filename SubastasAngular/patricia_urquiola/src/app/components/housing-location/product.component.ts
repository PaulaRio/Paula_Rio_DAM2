import { Component, Input } from '@angular/core';
import { Product } from '../../models/product';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-product',
  imports: [RouterModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class productComponent {

  @Input() product!: Product;

}
