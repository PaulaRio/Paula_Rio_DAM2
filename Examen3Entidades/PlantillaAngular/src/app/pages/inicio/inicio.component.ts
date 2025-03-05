import { Component, inject } from '@angular/core';

import { ObjetoService } from '../../services/objeto.service';
import { Objeto } from '../../interfaces/objeto';
import { CommonModule } from '@angular/common';
import { ObjectComponent } from '../../commponents/object/object.component';
import { CrearComponent } from '../../commponents/crear/crear.component';
import { Router } from '@angular/router';

@Component({
     selector: 'app-inicio',
     standalone: true,
     imports: [CommonModule, ObjectComponent,CrearComponent],
     templateUrl: './inicio.component.html',
     styleUrl: './inicio.component.css'
})
export class InicioComponent {

     private ObjetoServicio = inject(ObjetoService)
     public listaObjeto: Objeto[] = []
     private router = inject(Router);
     public mostrarCrear = false;
     

     constructor() {
          this.ObjetoServicio.lista().subscribe({
               next: (data) => {
                    if (data.length > 0) {
                         this.listaObjeto = data;
                    }
               },
               error: (err) => {
                    console.log(err.message);
               }
          })
     }
     abrirCrear() {
          this.router.navigate(['crear'])
      }
  
     
     

}
