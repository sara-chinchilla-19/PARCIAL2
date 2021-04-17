using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listadopromedio.clases
{
    class ClsArchivo
    {
        public string[] LeerArchivo(string archivo)
        {
            string[] lineas = File.ReadAllLines(archivo);
            return lineas;


        }
        public string LeerTodoArchivo(string archivo)
        {
            string ContenidoArchivo;

            using (StreamReader reader = new StreamReader(archivo, Encoding.Default))
            {
                ContenidoArchivo = reader.ReadToEnd();
            }
            return ContenidoArchivo;
        }


    }
}
