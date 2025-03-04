using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaWPF.Utils
{
    public static class Constantes
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
        internal const string BASE_URL = "https://localhost:7000/api/";
        internal const string LOGIN_PATH = "users";
        internal const string REGISTER_PATH = "users/register";
        internal const string IMAGES_EXTENSION = ".png";
        internal const string PATH_IMAGE_NOT_FOUND = "Not_found.png";
        internal const string OBJECT_URL = "Object/";
        internal static List<string> OBJETOS_POSIBLES = new List<string>()
        {
            "Altay.png",
            "Cenote.png",
            "HuskChair.png",
            "MoncloudSofa.png",
            "Plumon.png",
            "Silloncito.png"
        };
        #endregion
    }
}
