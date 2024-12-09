namespace Pokemon.Interfaces
{
    public interface IPokeOpsProvider
    {
        bool IsShiny();

        int NumAtack();
        public bool CaptureSuccess(int PokeLifePercentage);
    }
}