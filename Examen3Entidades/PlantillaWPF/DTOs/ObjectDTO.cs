using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PlantillaWPF.Models;

namespace PlantillaWPF.DTOs
{
    public class ObjectDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } 
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("idAutor")]
        public int IdAutor { get; set; }


        internal static ObjectDTO CreateDTOFromModel(ObjectModel objeto)
        {
            
            return new ObjectDTO
            {
                Id = objeto.Id,
                Name = objeto.Name,
                Description = objeto.Description,
                Photo = objeto.Photo,
                IdAutor = objeto.IdAutor,


            };
        }


        /*
        internal static ObjectDTO CreateDTOFromModel(ObjectModel objeto)
        {
            List<int> listaA = new List<int>();
            List<int> listaG = new List<int>();
            if (objeto.AutoresIds.Length != 0)
            {
                foreach (var obj in objeto.AutoresIds.Split(","))
                {
                    listaA.Add(int.Parse(obj));


                }
            }
            if (objeto.GruposIds.Length != 0) {
                foreach (var obj in objeto.GruposIds.Split(","))
                {
                    listaG.Add(int.Parse(obj));

                }
            }

            return new ObjectDTO
            {
                Id = objeto.Id,
                Name = objeto.Name,
                Description=objeto.Description,
                Photo = objeto.Photo,
                AutoresIds = listaA,
                GruposIds = listaG


            };
        }
        */

    }
}
