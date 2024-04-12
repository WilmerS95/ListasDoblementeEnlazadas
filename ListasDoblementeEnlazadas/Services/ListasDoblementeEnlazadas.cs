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

        public string AddAfterSpecificPosition(int posicion, Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                return "La lista esta vacia.";
            }
            nodoActual = primerNodo;
            int contador = 1;

            while (nodoActual != null && contador < posicion)
            {
                nodoActual = nodoActual.ligaSiguiente;
                contador++;
            }

            if (nodoActual != null)
            {
                nuevoNodo.ligaSiguiente = nodoActual.ligaSiguiente;
                if(nodoActual.ligaSiguiente != null) 
                {
                    nodoActual.ligaSiguiente.ligaAnterior = nuevoNodo;
                }
                nuevoNodo.ligaAnterior = nodoActual;
                nodoActual.ligaSiguiente = nuevoNodo;
                
                if (nuevoNodo.ligaSiguiente == null)
                {
                    ultimoNodo = nuevoNodo;
                }

                return "Se ha agregado el video después de la posición específica.";
            }
            else
            {
                return "La posición específica no se encontró en la lista.";
            }
        }

       
        public string EliminarNodoAlFinal()
        {

            if (isEmpty)
            {
                return "No existen elementos";
            }
            else if (primerNodo == ultimoNodo)
            {
                primerNodo = ultimoNodo = null;
            }
            else
            {
                Nodo nodoEliminar;

                nodoEliminar = ultimoNodo;
                ultimoNodo = ultimoNodo.ligaAnterior;
                ultimoNodo.ligaSiguiente = null;

                nodoEliminar = null;
            }

            return "El video se ha eliminado";
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