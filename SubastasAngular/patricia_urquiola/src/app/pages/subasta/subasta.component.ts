import { Component,inject} from '@angular/core';
import {productComponent} from '../../components/housing-location/product.component';
import {Product} from '../../models/product'
import { CommonModule } from '@angular/common';
import {HousingService} from '../../services/housing.service';

@Component({
  selector: 'app-subasta',
  imports: [CommonModule, productComponent],
  templateUrl: './subasta.component.html',
  styleUrls: ['./subasta.component.css'],
})
export class SubastaComponent {
  productList: Product[]=[];
  filteredLocationList: Product[]=[];

  constructor(private housingService: HousingService) {
    this.housingService.getAllproducts().then((productList: Product[]) => {
      this.productList = productList;
      this.filteredLocationList = productList;
    });
  }
  
  }
  

