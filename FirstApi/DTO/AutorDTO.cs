namespace FirstApi.DTO
{
    public class AutorDTO
    {//Quitar stack que luego da error
        public string Nombre { get; set; }
        public string TELF { get; set; }
        public List<int> Libros { get; set; }
    }
}
