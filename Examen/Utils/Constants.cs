using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Utils
{
    public static class Constants
    {
        #region Math
        public const string Mas = "+";
        public const string Menos = "-";
        public const string Por = "x";
        public const string Division = "÷";
        public const string Resultado = "Resultado";
        public const string Pi = "π";
        #endregion

        #region WPF_Views
        public const int MAX_NUMBER_ITEMS_STACK_PANEL = 15;
        public const int MIN_NUMBER_ITEMS_STACK_PANEL = 5;
        public const string HALLOWEEN_URL_PATH = "/Resources/Halloween.png";
        public const string JSON_FILTER = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
        #endregion

        #region API Url
        public const string BASE_URL = "http://localhost:5000/";
        public const string LIBROS_PATH = "libro";
        public const string ALLPOKE_URL = "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=100/";
        public const string HISTORICO_PATH = "pokeHistorico";
        #endregion

        #region Files
        public const string ROOTFILES = "../../.." + "/FILES";
        #endregion

    }
}
