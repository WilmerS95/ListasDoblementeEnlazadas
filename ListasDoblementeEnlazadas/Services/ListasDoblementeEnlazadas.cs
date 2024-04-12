using ListasDoblementeEnlazadas.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                if (nodoActual.ligaSiguiente != null)
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

        public (Nodo, int)  VideoSearch(string dato)
        {
            Nodo nodoActual = primerNodo;
            int posicion = 1;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == dato)
                {
                    return (nodoActual, posicion);
                }
                nodoActual = nodoActual.ligaSiguiente;
                posicion++;
            }

            return (null, -1);
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

        public void SortTheListAZ()
        {
            bool intercambio;
            do
            {
                intercambio = false;
                nodoActual = primerNodo;
                Nodo nodosiguiente = primerNodo?.ligaSiguiente;
              
                while (nodosiguiente != null)
                {
                    if (string.Compare(nodoActual.informacion.ToString(), nodosiguiente.informacion.ToString(), StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        string temp = nodoActual.informacion;
                        nodoActual.informacion = nodosiguiente.informacion;
                        nodosiguiente.informacion = temp;

                        intercambio = true;
                    }

                    nodoActual = nodosiguiente;
                    nodosiguiente = nodosiguiente.ligaSiguiente;
                }
            } while (intercambio);
        }

        public void SortTheListZA()
        {
            bool intercambio;
            do
            {
                intercambio = false;
                nodoActual = primerNodo;
                Nodo nodosiguiente = primerNodo?.ligaSiguiente;

                while (nodosiguiente != null)
                {
                    if (string.Compare(nodoActual.informacion.ToString(), nodosiguiente.informacion.ToString(), StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        string temp = nodoActual.informacion;
                        nodoActual.informacion = nodosiguiente.informacion;
                        nodosiguiente.informacion = temp;

                        intercambio = true;
                    }

                    nodoActual = nodosiguiente;
                    nodosiguiente = nodosiguiente.ligaSiguiente;
                }
            } while (intercambio);

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
        public string AddToEnd(Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                primerNodo = ultimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.ligaAnterior = ultimoNodo;
                ultimoNodo.ligaSiguiente = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
            nodoActual = nuevoNodo;
            return "El video se a agregado al final de la lista.";
        }
        public string AddBeforeSpecificPosition(int posicionEspecifica, Nodo nuevoNodo)
        {
            if (posicionEspecifica < 1)
            {
                return "La posición para gregar debe ser mayor a 0. ";
            }

            Nodo nodoActual = primerNodo;
            int posicion = 1;

            while (nodoActual != null && posicion < posicionEspecifica)
            {
                nodoActual = nodoActual.ligaSiguiente; posicion++;
            }

            if (nodoActual != null)
            {
                if (nodoActual.ligaAnterior == null)
                {
                    AgregarNodoAlInicio(nuevoNodo);
                }
                else
                {
                    nuevoNodo.ligaAnterior = nodoActual.ligaAnterior;
                    nuevoNodo.ligaSiguiente = nodoActual;
                    nodoActual.ligaAnterior.ligaSiguiente = nuevoNodo;
                    nodoActual.ligaAnterior = nuevoNodo;
                }
                nodoActual = nuevoNodo;
                return "Se agrego el video antes de la posición especifica. " ;
            }
            return "La posición especifica esta fuera de rango. ";
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
    /*
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

        public string DeleteBeforeVideoX(string videoX)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no hay elementos para eliminar";
            }

            Nodo nodoActual = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == videoX)
                {
                    if (nodoActual == primerNodo)
                    {
                        return "No hay elementos antes del video específico para eliminar";
                    }
                    else if (nodoActual.ligaAnterior == primerNodo)
                    {
                        primerNodo = nodoActual;
                        primerNodo.ligaAnterior = null;
                        nodoActual = null;
                    }
                    else
                    {
                        Nodo nodoAnterior = nodoActual.ligaAnterior;
                        nodoAnterior.ligaSiguiente = nodoActual.ligaSiguiente;

                        if (nodoActual.ligaSiguiente != null)
                        {
                            Nodo nodoSiguiente = nodoActual.ligaSiguiente;
                            nodoSiguiente.ligaAnterior = nodoAnterior;
                        }

                        nodoActual = null;
                    }

                    return "Se ha eliminado el elemento antes del video específico.";
                }

                nodoActual = nodoActual.ligaSiguiente;
            }

            return "El video específico no se encontró en la lista.";
        }
        public void EliminarNodo(Nodo nodo)
        {
            if (isEmpty || nodo == null)
            {
                return;
            }

            if (nodo == primerNodo)
            {
                primerNodo = nodo.ligaSiguiente;
            }

            if (nodo == ultimoNodo)
            {
                ultimoNodo = nodo.ligaAnterior;
            }

            if (nodo.ligaAnterior != null)
            {
                nodo.ligaAnterior.ligaSiguiente = nodo.ligaSiguiente;
            }

            if (nodo.ligaSiguiente != null)
            {
                nodo.ligaSiguiente.ligaAnterior = nodo.ligaAnterior;
            }

            nodo = null;
        }
        public string DeleteAfterVideoX(string videoX)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no hay elementos para eliminar";
            }

            Nodo nodoActual = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == videoX)
                {
                    if (nodoActual == ultimoNodo)
                    {
                        return "No hay elementos después del video específico para eliminar";
                    }
                    else if (nodoActual.ligaSiguiente == ultimoNodo)
                    {
                        Nodo nodoEliminar = nodoActual.ligaSiguiente;
                        nodoActual.ligaSiguiente = null;
                        ultimoNodo = nodoActual;
                        nodoEliminar = null;
                    }
                    else
                    {
                        Nodo nodoSiguiente = nodoActual.ligaSiguiente;
                        nodoActual.ligaSiguiente = nodoSiguiente.ligaSiguiente;
                        nodoSiguiente.ligaSiguiente.ligaAnterior = nodoActual;
                        nodoSiguiente = null;
                    }

                    return "Se ha eliminado el elemento después del video específico.";
                }

                nodoActual = nodoActual.ligaSiguiente;
            }

            return "El video específico no se encontró en la lista.";
        }
        public string DeleteInSpecificPosition(int posicion)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no hay elementos para eliminar";
            }

            if (posicion < 0)
            {
                return "La posición debe ser un número positivo";
            }

            Nodo nodoActual = primerNodo;
            int count = 0;

            while (nodoActual != null && count < posicion)
            {
                nodoActual = nodoActual.ligaSiguiente;
                count++;
            }

            if (count == posicion && nodoActual != null)
            {
                if (nodoActual == primerNodo)
                {
                    primerNodo = nodoActual.ligaSiguiente;
                    if (primerNodo != null)
                    {
                        primerNodo.ligaAnterior = null;
                    }
                }
                else if (nodoActual == ultimoNodo)
                {
                    ultimoNodo = nodoActual.ligaAnterior;
                    if (ultimoNodo != null)
                    {
                        ultimoNodo.ligaSiguiente = null;
                    }
                }
                else
                {
                    Nodo nodoAnterior = nodoActual.ligaAnterior;
                    Nodo nodoSiguiente = nodoActual.ligaSiguiente;

                    nodoAnterior.ligaSiguiente = nodoSiguiente;
                    nodoSiguiente.ligaAnterior = nodoAnterior;
                }

                nodoActual = null;
                return "Se ha eliminado el elemento en la posición específica";
            }
            else
            {
                return "La posición específica no se encontró en la lista";
            }
        }
    }

        }*/


}