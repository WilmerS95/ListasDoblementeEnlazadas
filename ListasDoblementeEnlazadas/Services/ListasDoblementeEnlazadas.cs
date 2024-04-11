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

        public string AddBeforeVideoX(string videoX, Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no hay videos para eliminar";
            }

            Nodo nodoActual = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == videoX)
                {
                    if (nodoActual == primerNodo)
                    {
                        nuevoNodo.ligaSiguiente = primerNodo;
                        primerNodo.ligaAnterior = nuevoNodo;
                        primerNodo = nuevoNodo;
                    }
                    else
                    {
                        nuevoNodo.ligaSiguiente = nodoActual;
                        nuevoNodo.ligaAnterior = nodoActual.ligaAnterior;
                        nodoActual.ligaAnterior.ligaSiguiente = nuevoNodo;
                        nodoActual.ligaAnterior = nuevoNodo;
                    }
                    nodoActual = nuevoNodo;
                    return "Se ha agregado el video antes del video específico.";
                }
                nodoActual = nodoActual.ligaSiguiente;
            }
            return "El link del video específico no se encontró en la lista.";
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

        public string AddToAfterVideoX(string videoX, Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no hay videos para eliminar";
            }

            Nodo nodoActual = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == videoX)
                {
                    if (nodoActual == ultimoNodo)
                    {
                        ultimoNodo = nuevoNodo;
                    }
                    else
                    {
                        Nodo siguiente = nodoActual.ligaSiguiente;
                        siguiente.ligaAnterior = nuevoNodo;
                    }

                    return "Se ha agregado el nodo después del video indicado";
                }

                nodoActual = nodoActual.ligaSiguiente;
                
                }
            return "Video no encontrado en la lista";
        }

        public string AddInSpecificPosition(int posicion, Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                return "Lista vacía";
            }

            Nodo nodoActual = primerNodo;
            int count = 0;

            while (nodoActual != null && count < posicion)
            {
                nodoActual = nodoActual.ligaSiguiente;
                count++;
            }

            if (count == posicion)
            {
                nuevoNodo.ligaSiguiente = nodoActual;

              
            if (nodoActual == primerNodo)
                {
                    primerNodo.ligaAnterior = nuevoNodo;
                    primerNodo = nuevoNodo;
                }
                else
                {
                    Nodo previo = nodoActual.ligaAnterior;
                    previo.ligaSiguiente = nuevoNodo;
                    nuevoNodo.ligaAnterior = previo;
                    nodoActual.ligaAnterior = nuevoNodo;
                }

                return "Nodo agregado en la posición " + posicion;
            }
            else
            {
                return "Posición inválida";
            }

        }



    }
}