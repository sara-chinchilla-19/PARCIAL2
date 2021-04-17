using listadopromedio.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listadopromedio
{
    public partial class Form1 : Form
    {

        string[,] ArregloDosDimensiones;
        private string[] ArregloNombres;
        private string[,] Nombres;
        private int[] NotasParcial1;
        private int[] NotasParcial2;
        private int[] NotasParcial3;
        private string[,] AlumnosSeccionA;
        private string[,] AlumnosSeccionB;
        private string[,] AlumnosSeccionC;

        private int Promedio1;
        private int Promedio2;
        private int Promedio3;
        private int X = 0;


        public Form1()
        {
            InitializeComponent();
        }

        

        private void CargarArchivo_Click(object sender, EventArgs e)
        {
            ClsArchivo ar = new ClsArchivo();
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Porfavor, seleccionar tu archivo plano";
            ofd.InitialDirectory = @"C:\Users\Sarita Chinchilla\OneDrive\Escritorio\archivoplano";
            ofd.Filter = "archivo plano (*.csv)|*.csv"; 
            if (ofd.ShowDialog()== DialogResult.OK)
            {
                var archivo = ofd.FileName;
                string resultado = ar.LeerTodoArchivo(archivo);
                ArregloNombres = ar.LeerArchivo(archivo);
                textBoxResultado.Text = resultado;
            }


        }

        private void buttonNombres_Click(object sender, EventArgs e)
        {
            int acumulador = 0;


            ArregloDosDimensiones = new string[ArregloNombres.Length, 6];


            foreach (string linea in ArregloNombres)
            {
                string[] datos = linea.Split(';');

                ArregloDosDimensiones[acumulador, 0] = datos[0];
                ArregloDosDimensiones[acumulador, 1] = datos[1];
                ArregloDosDimensiones[acumulador, 2] = datos[2];
                ArregloDosDimensiones[acumulador, 3] = datos[3];
                ArregloDosDimensiones[acumulador, 4] = datos[4];
                acumulador++;

            }


            ClsArreglos ObjArreglo = new ClsArreglos(ArregloDosDimensiones);
            Nombres = ObjArreglo.MetodoBurbujaCadenas(1);

            for (int i = 1; i < ArregloDosDimensiones.GetLength(0); i++)
            {
                listBoxResultado.Items.Add(Nombres[i, 1]);
            }

            ClsNotas ObjArregloNotas = new ClsNotas();
            NotasParcial1 = ObjArregloNotas.MetodoBurbujaEnteros(ArregloDosDimensiones, 2);
            NotasParcial2 = ObjArregloNotas.MetodoBurbujaEnteros(ArregloDosDimensiones, 3);
            NotasParcial3 = ObjArregloNotas.MetodoBurbujaEnteros(ArregloDosDimensiones, 4);
            Promedio1 = ObjArregloNotas.promedios(NotasParcial1);
            Promedio2 = ObjArregloNotas.promedios(NotasParcial2);
            Promedio3 = ObjArregloNotas.promedios(NotasParcial3);
        }

        private void textBoxResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonnotaparcial_Click(object sender, EventArgs e)
        {
            X = 1;
            listBoxnotas.Items.Clear();
            for (int i = 1; i < ArregloDosDimensiones.GetLength(0); i++)
            {
                listBoxnotas.Items.Add(NotasParcial1[i]);
            }

        }

        private void buttonnotaparcial2_Click(object sender, EventArgs e)
        {
            X = 2;
            listBoxnotas.Items.Clear();
            for (int i = 1; i < ArregloDosDimensiones.GetLength(0); i++)
            {
                listBoxnotas.Items.Add(NotasParcial2[i]);
            }
        }

        private void buttonnotaparcial3_Click(object sender, EventArgs e)
        {
            X = 3;
            listBoxnotas.Items.Clear();
            for (int i = 1; i < ArregloDosDimensiones.GetLength(0); i++)
            {
                listBoxnotas.Items.Add(NotasParcial3[i]);
            }
        }

        private void buttonpromedionotas_Click(object sender, EventArgs e)
        {
            switch (X)
            {
                case 1:
                    textBoxpromedio.Text = "" + Promedio1.ToString();
                    break;
                case 2:
                    textBoxpromedio.Text = "" + Promedio2.ToString();
                    break;
                case 3:
                    textBoxpromedio.Text = "" + Promedio3.ToString();
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxpromedio_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonnotamaxima_Click(object sender, EventArgs e)
        {
            switch (X)
            {
                case 1:
                    textBoxnotamaxima.Text = "" + NotasParcial1[60].ToString();
                    break;
                case 2:
                    textBoxnotamaxima.Text = "" + NotasParcial2[60].ToString();
                    break;
                case 3:
                    textBoxnotamaxima.Text = "" + NotasParcial3[60].ToString();
                    break;
            }
        }

        private void buttonnotaminima_Click(object sender, EventArgs e)
        {
            switch (X)
            {
                case 1:
                    textBoxnotaminima.Text = "" + NotasParcial1[1].ToString();
                    break;
                case 2:
                    textBoxnotaminima.Text = "" + NotasParcial2[1].ToString();
                    break;
                case 3:
                    textBoxnotaminima.Text = "" + NotasParcial3[1].ToString();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
