import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Objeto } from '../../interfaces/objeto';

@Component({
  selector: 'app-object',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './object.component.html',
  styleUrl: './object.component.css'
})
export class ObjectComponent {
  
   @Input() objeto!: Objeto;
}
