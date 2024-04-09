using ListasDoblementeEnlazadas.DTO;

namespace ListasDoblementeEnlazadas.Services
{
    public class ListasDoblementeEnlazadas
    {
        public Nodo? primerNodo { get; set; }
        public Nodo? ultimoNodo { get; set; }
        public Nodo? nodoActual { get; set; }

        public ListasDoblementeEnlazadas()
        {
            primerNodo = null;
            ultimoNodo = null;
            nodoActual = null;
        }

        public bool isEmpty => primerNodo == null;

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                primerNodo = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.ligaSiguiente = primerNodo;
                primerNodo.ligaAnterior = nuevoNodo;
                primerNodo = nuevoNodo;
            }
            nodoActual = nuevoNodo;
            return "Se ha agregado al inicio de la lista";
        }

        public Nodo Siguiente()
        {
            nodoActual = nodoActual.ligaSiguiente ?? ultimoNodo;
            return nodoActual;
        }

        public Nodo Anterior()
        {
            nodoActual = nodoActual.ligaAnterior ?? primerNodo;
            return nodoActual;
        }
    }
}