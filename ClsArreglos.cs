using System;
using System.Collections.Generic;
using System.Text;

namespace listadopromedio.clases
{
    class ClsArreglos
    {
        private string[,] ArregloTemporal;
        private string[,] datos;
        private int i, j;
        private string datoTemporal;
        private int columna;



        public ClsArreglos(string[,] arreglo)
        {
            datos = arreglo;
        }

        public string[,] MetodoBurbujaCadenas(int col)
        {
            columna = col;
            ArregloTemporal = datos;
            for (i = 1; i < ArregloTemporal.GetLength(0) - 1; i++)
            {
                for (j = i + 1; j < ArregloTemporal.GetLength(0); j++)
                {

                    if (ArregloTemporal[i, columna].CompareTo(ArregloTemporal[j, columna]) > 0)
                    {
                        datoTemporal = ArregloTemporal[i, columna];
                        ArregloTemporal[i, columna] = ArregloTemporal[j, columna];
                        ArregloTemporal[j, columna] = datoTemporal;
                    }

                }
            }

            return ArregloTemporal;
        }




    }
}
