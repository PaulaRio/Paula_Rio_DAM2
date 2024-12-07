using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Interfaces;

namespace Pokemon.Services
{
    internal class PokeService : IPokeProvider
    {
        public bool IsShiny()
        {
            int randomNumber = new Random().Next(1, 100);

            return randomNumber <= 5;
        }
    }
}
