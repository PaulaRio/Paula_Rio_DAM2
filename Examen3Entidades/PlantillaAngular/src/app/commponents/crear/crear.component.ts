import { Component, inject, NgModule, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Objeto } from '../../interfaces/objeto';
import { ObjetoService } from '../../services/objeto.service';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-crear',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './crear.component.html',
  styleUrl: './crear.component.css'
})
export class CrearComponent implements OnInit {
 route: ActivatedRoute = inject(ActivatedRoute);
 private router = inject(Router);
  objetoId: number | null = null;
  objeto: Objeto = { id: 0, name: '', description:'', createdDate: new Date(),photo:'' };
  

  constructor(
    private objetoService: ObjetoService
  ) {}
  @NgModule({
    imports: [FormsModule],
  })
  ngOnInit(): void {
    
  }
  
  async crearObjeto(): Promise<any> {
      try {
        await this.objetoService.createObjeto(this.objeto);
        alert('Objeto creado correctamente.');
        this.router.navigate(['inicio'])
      } catch (error) {
        console.error('Error al crear el objeto', error);
        alert('Hubo un error al crear el objeto.');
      }
    
  }

 
}
