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
                return "La lista está vacía, no se puede agregar antes de Video X";
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
                    return "Se ha agregado el video antes del video específico.";
                }
                nodoActual = nodoActual.ligaSiguiente;
            }
            return "El link del video específico no se encontró en la lista.";
        }

        public string AddToAfterVideoX(string videoX, Nodo nuevoNodo)
        {
            if (isEmpty)
            {
                return "La lista está vacía, no se puede agregar después de Video X";
            }

            Nodo nodoActual = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == videoX)
                {
                    if (nodoActual == ultimoNodo)
                    {
                        nuevoNodo.ligaAnterior = nodoActual;
                        nodoActual.ligaSiguiente = nuevoNodo;
                        ultimoNodo = nuevoNodo;
                    }
                    else
                    {
                        Nodo siguiente = nodoActual.ligaSiguiente;
                        nuevoNodo.ligaSiguiente = siguiente;
                        nuevoNodo.ligaAnterior = nodoActual;
                        nodoActual.ligaSiguiente = nuevoNodo;
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
            if (posicion < 1)
            {
                return "La posición para agregar debe ser mayor a 0.";
            }

            if (isEmpty)
            {
                primerNodo = nuevoNodo;
                ultimoNodo = nuevoNodo;
                return "Se agregó el video en la posición 1 de la lista.";
            }

            Nodo nodoActual = primerNodo;
            int count = 1;

            while (nodoActual != null && count < posicion - 1)
            {
                nodoActual = nodoActual.ligaSiguiente;
                count++;
            }

            if (count == posicion - 1 && nodoActual != null)
            {
                nuevoNodo.ligaSiguiente = nodoActual.ligaSiguiente;
                nodoActual.ligaSiguiente = nuevoNodo;

                if (nuevoNodo.ligaSiguiente == null)
                {
                    ultimoNodo = nuevoNodo;
                }

                return $"Se agregó el video en la posición {posicion} de la lista.";
            }
            else if (posicion == 1)
            {
                AgregarNodoAlInicio(nuevoNodo);
                return $"Se agregó el video en la posición {posicion} de la lista";
            }
            else
            {
                return "La posición específica está fuera de rango.";
            }
        }

        public string AddBeforeSpecificPosition(int posicionEspecifica, Nodo nuevoNodo)
        {
            if (posicionEspecifica < 1)
            {
                return "La posición para gregar debe ser mayor a 0. ";
            }

            if (isEmpty)
            {
                return "La lista está vacía, no se puede agregar antes de posición específica";
            }

            Nodo nodoActual = primerNodo;
            int posicion = 1;

            while (nodoActual != null && posicion < posicionEspecifica)
            {
                nodoActual = nodoActual.ligaSiguiente; 
                posicion++;
            }

            if (nodoActual != null)
            {
                nuevoNodo.ligaAnterior = nodoActual.ligaAnterior;
                nuevoNodo.ligaSiguiente = nodoActual;
                nodoActual.ligaAnterior.ligaSiguiente = nuevoNodo;
                nodoActual.ligaAnterior = nuevoNodo;

                return $"Se agregó el video antes de la posición {posicionEspecifica}.";
            }
            return "La posición especifica esta fuera de rango. ";
        }

        public string AddAfterSpecificPosition(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 1)
            {
                return "La posición para gregar debe ser mayor a 0. ";
            }

            if (isEmpty)
            {
                return "La lista está vacía, no se puede agregar después de posición específica";
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

                return $"Se ha agregado el video después de la posición específica {posicion}.";
            }
            else
            {
                return "La posición específica no se encontró en la lista.";
            }
        }

        public string VideoSearch(string video)
        {
          
            nodoActual = primerNodo;
            int posicion = 1;

            while (nodoActual != null)
            {
                if (nodoActual.informacion.ToString() == video)
                {
                    return $"El video '{video}' fue encontrado en la posición {posicion}.";
                   
                }
                nodoActual = nodoActual.ligaSiguiente;
                posicion++;
            }

            return $"El video '{video}'  no fue encontrado en la lista ";
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
                    if (nodoActual == primerNodo || nodoActual.ligaAnterior == null)
                    {
                        return "No hay elementos antes del video específico para eliminar";
                    }
                    else
                    {
                        Nodo nodoAnterior = nodoActual.ligaAnterior;
                        nodoAnterior.ligaSiguiente = nodoActual.ligaSiguiente;

                        if (nodoActual.ligaSiguiente != null)
                        {
                            nodoActual.ligaSiguiente.ligaAnterior = nodoAnterior;
                        }

                        return "Se ha eliminado el elemento antes del video específico.";
                    }
                }

                nodoActual = nodoActual.ligaSiguiente;
            }

            return "El video específico no se encontró en la lista.";
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
                    if (nodoActual == ultimoNodo || nodoActual.ligaSiguiente == null)
                    {
                        return "No hay elementos después del video específico para eliminar";
                    }
                    else
                    {
                        Nodo nodoSiguiente = nodoActual.ligaSiguiente;
                        nodoActual.ligaSiguiente = nodoSiguiente.ligaSiguiente;

                        if (nodoSiguiente.ligaSiguiente != null)
                        {
                            nodoSiguiente.ligaSiguiente.ligaAnterior = nodoActual;
                        }

                        return "Se ha eliminado el elemento después del video específico.";
                    }
                }

                nodoActual = nodoActual.ligaSiguiente;
            }

            return "El video específico no se encontró en la lista.";
        }

        public string DeleteInSpecificPosition(int posicion)
        {
            if (posicion < 1)
            {
                return "La posición para eliminar debe ser mayor a 0.";
            }

            if (isEmpty)
            {
                return "La lista está vacía, no se puede eliminar en una posición específica";
            }

            Nodo nodoActual = primerNodo;
            int contador = 1;

            while (nodoActual != null && contador < posicion)
            {
                nodoActual = nodoActual.ligaSiguiente;
                contador++;
            }

            if (nodoActual != null)
            {
                if (nodoActual == primerNodo)
                {
                    primerNodo = nodoActual.ligaSiguiente;
                    if (primerNodo != null)
                    {
                        primerNodo.ligaAnterior = null;
                    }
                    else
                    {
                        ultimoNodo = null;
                    }
                }
                else if (nodoActual == ultimoNodo)
                {
                    ultimoNodo = nodoActual.ligaAnterior;
                    ultimoNodo.ligaSiguiente = null;
                }
                else
                {
                    Nodo nodoAnterior = nodoActual.ligaAnterior;
                    Nodo nodoSiguiente = nodoActual.ligaSiguiente;

                    nodoAnterior.ligaSiguiente = nodoSiguiente;
                    nodoSiguiente.ligaAnterior = nodoAnterior;
                }

                return $"Se ha eliminado el elemento en la posición {posicion} de la lista.";
            }
            else
            {
                return "La posición específica no se encontró en la lista.";
            }
        }

    }
}