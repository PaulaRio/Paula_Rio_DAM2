using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examen.Model
{
    public class GalaxyModel
    {

        public string nombre { get; set; }
        public int distanciaTierra { get; set; }
        public string tipo { get; set; }
        public string atmosfera { get; set; }
        public int temperatura { get; set; }
        public string nombreImagen { get; set; }

    }
}
