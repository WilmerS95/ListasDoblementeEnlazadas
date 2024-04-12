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

        public string AddToEnd( Nodo nuevoNodo)
        {
            if (primerNodo == null)
            {
                primerNodo = ultimoNodo = nuevoNodo;
                return "No se encontraron videos.";
            }
            else
            {
                nuevoNodo.ligaAnterior = ultimoNodo;
                ultimoNodo.ligaSiguiente = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
            return "El video se a agregado al final de la lista.";
        }
        public string AddBeforeSpecificPosition(int posicionEspecifica, Nodo nuevoNodo)
        {
            if (primerNodo == null)
            {
                primerNodo = ultimoNodo = nuevoNodo;
            }
            else if (posicionEspecifica <= 1)
            {
                nuevoNodo.ligaSiguiente = primerNodo;
                primerNodo.ligaAnterior = nuevoNodo;
                primerNodo = nuevoNodo;
                return "Se ha agregado el video al la lista";
            }
            else
            {
                nodoActual = primerNodo;
            }

                int contador = 1;

            while (nodoActual != null && contador < posicionEspecifica - 1)
            {
                nodoActual = nodoActual.ligaSiguiente;
                contador++;
            }
            if (nodoActual != null)
            {
                nuevoNodo.ligaSiguiente = nodoActual.ligaSiguiente;
                nuevoNodo.ligaAnterior = nodoActual;
                nodoActual.ligaSiguiente = nuevoNodo;
                return "Se ha agregado al inicio de la lista";
            }
            if (nuevoNodo.ligaSiguiente != null)
            {
                nuevoNodo.ligaSiguiente.ligaAnterior = nuevoNodo;
                return "Se ha agregado el video en la posición requerida.";
            }
            else
            {
                ultimoNodo = nuevoNodo;
                return "Se ha agregado el video en la posición requerida.";
            }

        }

        public string DeleteToTop()
        {
            if (primerNodo == null)
            {
                return "La lista esta vacía. ";
            }

            Nodo nodoSiguiente = primerNodo.ligaSiguiente;

            primerNodo = nodoSiguiente;
            primerNodo.ligaAnterior = null;
            return "Se ha eliminado el primer video de la lista. ";
        }
    } 
}