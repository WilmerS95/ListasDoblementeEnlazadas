namespace ListasDoblementeEnlazadas.DTO
{
    public class Nodo
    {
        public Nodo? ligaAnterior { get; set; }
        public string informacion { get; set; }
        public Nodo? ligaSiguiente { get; set; }
        public Nodo(string Informacion)
        {
            ligaAnterior = null; 
            ligaSiguiente = null; 
            informacion = Informacion;
        }
    }
}
