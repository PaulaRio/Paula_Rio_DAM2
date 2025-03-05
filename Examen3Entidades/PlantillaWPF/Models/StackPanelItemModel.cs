using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;
using PlantillaWPF.Utils;

namespace PlantillaWPF.Models
{
    public class StackPanelItemModel
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdObjeto { get; set; }

        //public string Email { get; set; }
        //public string Distance { get; set; }
        //public string Atmosphere { get; set; }
        //public string Temperature { get; set; }

        internal static StackPanelItemModel CreateModelFromDTO(AutorDTO objeto)
        {
            return new StackPanelItemModel
            {
                Name=$"Pedido {objeto.Id}",
                CreatedDate = objeto.CreatedDate,
                IdObjeto = objeto.IdObjeto,
                //Email = objeto.Email,
                
                //Photo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                //Constantes.OBJETOS_POSIBLES.Find(x => (objeto.Name + Constantes.IMAGES_EXTENSION) == x) ?? Constantes.PATH_IMAGE_NOT_FOUND
                //),
                //Distance = $"{objeto.Distancia} light years",
                //Atmosphere = objeto.Atmosfera,
                //Temperature = $"{objeto.Temperatura}ºC"
            };
        }
    }
}
