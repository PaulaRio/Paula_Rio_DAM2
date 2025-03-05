using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;
using PlantillaWPF.Utils;

namespace PlantillaWPF.Models
{
    public  class ObjectModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdAutor { get; set; }
        public string GruposIds { get; set; }


        internal static ObjectModel CreateModelFromDTO(ObjectDTO objeto, IEnumerable<RelacionDTO> relaciones)
        {
            List<RelacionDTO> listaFiltrada = relaciones.Where(r => r.IdObjeto == objeto.Id).ToList();           
            string listaG = "";
            if (listaFiltrada.Count() == 0)
            {
                listaG += " ";
            }
            foreach (var relacion in listaFiltrada)
            {
                listaG += relacion.IdGrupo + ",";

            }
            return new ObjectModel
            {
                Id = objeto.Id,
                Name = objeto.Name,
                Description = objeto.Description,
                CreatedDate = objeto.CreatedDate,
                Photo = objeto.Photo,
                IdAutor = objeto.IdAutor, 
                GruposIds = listaG.Substring(0, listaG.Length - 1)
            };
        }

        /*
        internal static ObjectModel CreateModelFromDTO(ObjectDTO objeto)
        {
           
            string listaA="";
            string listaG = "";
            if (objeto.AutoresIds.Count == 0)
            {
                listaA += " ";
            }
            if (objeto.GruposIds.Count == 0)
            {
                listaG += " ";
            }
            foreach (var obj in objeto.AutoresIds)
            {
                listaA += obj+"," ;
                

            }
            foreach (var obj in objeto.GruposIds)
            {
                listaG += obj + ",";

            }
            return new ObjectModel
            {
                Id = objeto.Id,
                Name = objeto.Name,
                Description = objeto.Description,
                Photo =objeto.Photo,
                AutoresIds = listaA.Substring(0,listaA.Length-1),
                GruposIds = listaG.Substring(0, listaG.Length-1)
            };
        }
        */
    }
}
