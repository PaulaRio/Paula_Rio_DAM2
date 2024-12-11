namespace Examen.Interfaces
{
    public interface IEjemploProvider
    {
        bool IsShiny();

        int NumAtack();

        public bool CaptureSuccess(int PokeLifePercentage);
    }
}