import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FormsModule} from '@angular/forms';
import { Objeto } from '../../interfaces/objeto';
import { ObjetoService } from '../../services/objeto.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit{
  route: ActivatedRoute = inject(ActivatedRoute);
  objetoId: number | null = null;
  objeto: Objeto = { id: 0, name: '', description:'', createdDate: new Date(),photo:'' };

  constructor(
    private objetoService: ObjetoService
  ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.objetoId = +id;
        this.cargarObjeto();
      }
    });
  }
  async cargarObjeto() {
    if (this.objetoId) {
      const objetoData = await this.objetoService.getObjectById(this.objetoId);
      if (objetoData) {
        this.objeto = objetoData;
      }
    }
  }
  async actualizarObjeto() {
    if (this.objetoId) {
      try {
        await this.objetoService.updateObjeto(this.objetoId, this.objeto);
        alert('Objeto actualizado correctamente.');
      } catch (error) {
        console.error('Error al actualizar el objeto', error);
        alert('Hubo un error al actualizar el objeto.');
      }
    }
  }

  async eliminarObjeto() {
    if (this.objetoId) {
      const confirmacion = confirm('¿Estás seguro de que deseas eliminar este objeto?');
      if (confirmacion) {
        try {
          await this.objetoService.deleteObjeto(this.objetoId);
          alert('Objeto eliminado correctamente.');
          //this.location.back();
        } catch (error) {
          console.error('Error al eliminar el objeto', error);
          alert('Hubo un error al eliminar el objeto.');
        }
      }
    }
  }

  
 
}
