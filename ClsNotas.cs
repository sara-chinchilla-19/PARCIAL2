using System;
using System.Collections.Generic;
using System.Text;

namespace listadopromedio.clases
{
    class ClsNotas
    {
        private int datos;
        private int i, j;
        private int datoTemporal;



        public ClsNotas()

        {
        }

        public int[] MetodoBurbujaEnteros(string[,] arreglo, int col)
        {
            int[] ArregloTemporal = new int[arreglo.GetLength(0)];

            for (int i = 1; i < arreglo.GetLength(0); i++)
            {

                datos = Int32.Parse(arreglo[i, col]);
                ArregloTemporal[i] = datos;

            }

            for (i = 0; i < ArregloTemporal.GetLength(0) - 1; i++)
            {
                for (j = i + 1; j < ArregloTemporal.GetLength(0); j++)
                {

                    if (ArregloTemporal[i] > ArregloTemporal[j])
                    {
                        datoTemporal = ArregloTemporal[i];
                        ArregloTemporal[i] = ArregloTemporal[j];
                        ArregloTemporal[j] = datoTemporal;
                    }

                }
            }

            return ArregloTemporal;
        }


        public int promedios(int[] arreglo)
        {
            int acumulador = 0;
            int promedio;
            int totalFilas = arreglo.Length;

            for (int fila = 1; fila < totalFilas; fila++)
            {
                acumulador = acumulador + arreglo[fila];

            }
            promedio = acumulador / (totalFilas - 1);
            return promedio;
        }
    }
}
