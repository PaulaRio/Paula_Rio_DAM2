using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;
using PlantillaWPF.Utils;

namespace PlantillaWPF.Models
{
    public  class ObjectModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        internal static ObjectModel CreateModelFromDTO(ObjectDTO objeto)
        {
            return new ObjectModel
            {
                Id = objeto.Id,
                Name = objeto.Name,
                Email = objeto.Email,
                //Photo =objeto.Photo,
                //Photo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                //Constantes.OBJETOS_POSIBLES.Find(x => (objeto.Name + Constantes.IMAGES_EXTENSION) == x) ?? Constantes.PATH_IMAGE_NOT_FOUND
               //),
                
            };
        }
    }
}
