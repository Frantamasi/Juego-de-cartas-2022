using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico
{
    public partial class Form1 : Form
    {

        struct Carta
        {
            public int numero;
            public string palo;
            public bool estado;  //indica si la carta esta en el mazo o no.
       
        }
        
        int pozo = 0;
        int mazoJ1 = 0;
        int mazoCompu=0;
        
       
        Carta[] mazo = new Carta[48];       //declaramos el mazo de manera publica                  

        Carta[] manoJugador = new Carta[3];     //sirve para graficar
        Carta[] manoCompu = new Carta[3];


        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             mazoJ1 = 0;
             mazoCompu = 0;

            mazopc.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;
            mazojug.Image = TrabajoPractico.Properties.Resources.ParteDeAtras; 
            this.MazoEnMesa.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;          //grafica el mazo principal
            GenerarMazo(mazo);
            
        }


        private void DarManoJugador()
        {
            int numTemp;
            string paloTemp;
            for (int i = 0; i < 3; i++)     //ciclo que reparte 
            {
                manoJugador[i] = Repartir(mazo);        //le reparte la carta al jugador    
                numTemp = manoJugador[i].numero;        //le asigna el palo y numero a una variable temporal para graficar
                paloTemp = manoJugador[i].palo;

                Graficar(paloTemp, numTemp, i);
            }

        }
        private void DarManoPc()
        {
            int numTemp;
            string paloTemp;
            for (int i = 0; i < 3; i++)
            {
                manoCompu[i] = Repartir(mazo);
                numTemp = manoCompu[i].numero;
                paloTemp = manoCompu[i].palo;
                //graficar mano oculta

                GraficarManoOcultaPc();
               
            }
             
        }
        private void QuienGano(int mazoJ1, int mazoCompu)
        { 
            if (mazoJ1 > mazoCompu && mazoCompu + mazoJ1 == 48)
            {
                MessageBox.Show("Gano el jugador 1");
            }
            else if(mazoCompu > mazoJ1 && mazoCompu + mazoJ1 == 48)
            {
                MessageBox.Show("Gano la computadora");

            }
           
            if( mazoCompu == mazoJ1 && mazoCompu + mazoJ1 == 48)
            {
                MessageBox.Show("empate");
            }

        }
        private void GenerarMazo(Carta[] mazo)
        {
            string[] palo = new string[4];
            palo[0] = "Basto";
            palo[1] = "Oro";
            palo[2] = "Espada";
            palo[3] = "Copa";
            int cont = 0;


            for(int i= 0; i < 4; i++)
            {
                int palotmp = i;
                for (int x = 1; x < 13; x++)
                {
                    Carta temp = new Carta();
                    temp.numero = x;
                    temp.palo = palo[palotmp];
                    temp.estado = true;                                     //chequea
                    mazo[cont] = temp;
                    cont+=1;
                }
            }

        }
        private Carta Repartir(Carta[] mazo)
        {

            Carta cartaTemp = new Carta();      //carta temporal que va a asignar al jugador
            Random rnd = new Random();  
            bool salir = false;

            while (!salir)
            {
                int posicionRandom = rnd.Next(0, 48);       //numero random para ir a buscar al mazo, entre 0 y 47 (recordar que el ultimo valor del .Next es siempre 1 mas del numero que necesitamos)
               
                if (mazo[posicionRandom].estado == true)   //si la carta sigue estando en el mazo entra al if
                {
                    mazo[posicionRandom].estado = false;  //la carta deja de estar disponible en el mazo   
                    cartaTemp = mazo[posicionRandom];   //la carta temporal va a tomar los valores de la carta previamente seleccionada

                    salir = true;       //sale del ciclo
                }


            }
            return cartaTemp;       //devuelve la carta temporal    //tengo que poner q la mano1 2 o 3 sea igual a esta carta



        }


        #region Graficar

        private void GraficarManoOcultaPc()
        {
            carta1PC.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;
            carta2PC.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;
            carta3PC.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;

        }
        private void GraficarManoPc(string paloTemp, int numTemp, int i)
        {
            bool grafico = false;
            if (paloTemp == "Basto")
            {
                grafico = GraficarBastoPC(numTemp, i);
                //llama a graficarbasto pasando como referencia el numero GraficarBasto(numTemp)
            }
            else if (paloTemp == "Espada")
            {
                GraficarEspadaPC(numTemp, i);
            }
            else if (paloTemp == "Oro")
            {
                GraficarOroPC(numTemp, i);
            }
            else if (paloTemp == "Copa")
            {
                GraficarCopaPC(numTemp, i);
            }
        }
        private void Graficar(string paloTemp, int numTemp, int i)          //grafica la mano del jugador
        {
            bool grafico=false;
            if ( paloTemp== "Basto")
            {
                grafico = GraficarBasto(numTemp, i);
                //llama a graficarbasto pasando como referencia el numero GraficarBasto(numTemp)
            }
            else if( paloTemp== "Espada")
            {
                GraficarEspada(numTemp,i);
            }
            else if (paloTemp == "Oro")
            {
                GraficarOro(numTemp,i);
            }
            else if (paloTemp == "Copa")
            {
                GraficarCopa(numTemp,i);
            }
        }


        #region Graficar palos


        private bool GraficarBastoPC(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
            }

            return true;
        }
        private bool GraficarOroPC(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
            }

            return true;
        }

        private bool GraficarEspadaPC(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
            }

            return true;
        }

        private bool GraficarCopaPC(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            pictureBox8.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.pictureBox8.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
            }

            return true;
        }


        private bool GraficarBasto(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            carta1J1.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            carta2J1.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            carta3J1.Image = TrabajoPractico.Properties.Resources._1_Basto;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._2_Basto;
                            break;
                        case 3:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._3_Basto;
                            break;
                        case 4:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._4_Basto;
                            break;
                        case 5:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._5_Basto;
                            break;
                        case 6:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._6_Basto;
                            break;
                        case 7:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._7_Basto;
                            break;
                        case 8:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._8_Basto;
                            break;
                        case 9:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._9_Basto;
                            break;
                        case 10:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._10_Basto;
                            break;
                        case 11:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._11_Basto;
                            break;
                        case 12:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._12_Basto;
                            break;

                    }
                    break;
            }
           
            return true;
        }
        private bool GraficarOro(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            carta1J1.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            carta2J1.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            carta3J1.Image = TrabajoPractico.Properties.Resources._1_Oro;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._2_Oro;
                            break;
                        case 3:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._3_Oro;
                            break;
                        case 4:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._4_Oro;
                            break;
                        case 5:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._5_Oro;
                            break;
                        case 6:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._6_Oro;
                            break;
                        case 7:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._7_Oro;
                            break;
                        case 8:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._8_Oro;
                            break;
                        case 9:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._9_Oro;
                            break;
                        case 10:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._10_Oro;
                            break;
                        case 11:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._11_Oro;
                            break;
                        case 12:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._12_Oro;
                            break;

                    }
                    break;
            }
            
            return true;
        }

        private bool GraficarEspada(int numTemp, int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            carta1J1.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            carta2J1.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            carta3J1.Image = TrabajoPractico.Properties.Resources._1_Espada;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._2_Espada;
                            break;
                        case 3:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._3_Espada;
                            break;
                        case 4:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._4_Espada;
                            break;
                        case 5:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._5_Espada;
                            break;
                        case 6:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._6_Espada;
                            break;
                        case 7:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._7_Espada;
                            break;
                        case 8:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._8_Espada;
                            break;
                        case 9:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._9_Espada;
                            break;
                        case 10:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._10_Espada;
                            break;
                        case 11:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._11_Espada;
                            break;
                        case 12:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._12_Espada;
                            break;

                    }
                    break;
            }
            
            return true;
        }

        private bool GraficarCopa(int numTemp,int i)
        {
            switch (i)
            {
                case 0:
                    switch (numTemp)
                    {
                        case 1:
                            carta1J1.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.carta1J1.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
                case 1:
                    switch (numTemp)
                    {
                        case 1:
                            carta2J1.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.carta2J1.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
                case 2:
                    switch (numTemp)
                    {
                        case 1:
                            carta3J1.Image = TrabajoPractico.Properties.Resources._1_Copa;   //si empieza con numero se le debe poner un guion bajo adelante
                            break;
                        case 2:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._2_Copa;
                            break;
                        case 3:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._3_Copa;
                            break;
                        case 4:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._4_Copa;
                            break;
                        case 5:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._5_Copa;
                            break;
                        case 6:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._6_Copa;
                            break;
                        case 7:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._7_Copa;
                            break;
                        case 8:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._8_Copa;
                            break;
                        case 9:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._9_Copa;
                            break;
                        case 10:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._10_Copa;
                            break;
                        case 11:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._11_Copa;
                            break;
                        case 12:
                            this.carta3J1.Image = TrabajoPractico.Properties.Resources._12_Copas;
                            break;

                    }
                    break;
            }
            
            return true;
        }


        #endregion


        #endregion


        #region formulario
        private void carta1J1_Click(object sender, EventArgs e)         //TIENE QUE BAJAR UN CARTA CUANDO HAGO CLICK
        {
            
            pictureBox9.Image = carta1J1.Image;
            this.carta1J1.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            pictureBox8.Image = carta1PC.Image;
            this.carta1PC.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            int numTemp = manoCompu[0].numero;
            string paloTemp = manoCompu[0].palo;
            int i = 0;

            GraficarManoPc(paloTemp, numTemp, i);

            if (manoJugador[0].numero > manoCompu[0].numero)
            {
               
                mazoJ1 += 2;
                textBox1.Text = (" " + mazoJ1);

                QuienGano(mazoJ1, mazoCompu);
                
            }
            else if(manoJugador[0].numero < manoCompu[0].numero)
            {

                mazoCompu += 2;
                textBox2.Text = (" " + mazoCompu);

                QuienGano(mazoJ1, mazoCompu);
            }
            else
            {                mazoCompu += 1;
                mazoJ1 += 1;
                textBox1.Text = (" " + mazoJ1);

                QuienGano(mazoJ1, mazoCompu);
            }

        }
        private void carta2J1_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = carta2J1.Image;
            this.carta2J1.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            pictureBox8.Image = carta2PC.Image;
            this.carta2PC.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            int numTemp = manoCompu[1].numero;
            string paloTemp = manoCompu[1].palo;
            int i = 1;
            GraficarManoPc(paloTemp, numTemp, i);

            if (manoJugador[1].numero > manoCompu[1].numero)
            {
                mazoJ1 += 2;
                textBox1.Text = (" " + mazoJ1);

                //le de puntos al jugador

                QuienGano(mazoJ1, mazoCompu);
            }
            else if (manoJugador[1].numero < manoCompu[1].numero)
            {

                mazoCompu += 2;
                textBox2.Text = (" " + mazoCompu);

                QuienGano(mazoJ1, mazoCompu);
            }
            else
            {
             
                mazoCompu += 1;
                mazoJ1 += 1;
                textBox1.Text = (" " + mazoJ1);
                textBox2.Text = (" " + mazoCompu);

                QuienGano(mazoJ1, mazoCompu);
            }
        }

        private void carta3J1_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = carta3J1.Image;
            this.carta3J1.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            pictureBox8.Image = carta3PC.Image;
            this.carta3PC.Image = TrabajoPractico.Properties.Resources.CartaVacia;

            int numTemp = manoCompu[2].numero;
            string paloTemp = manoCompu[2].palo;
            int i = 2;
            GraficarManoPc(paloTemp, numTemp, i);

            if (manoJugador[2].numero > manoCompu[2].numero)
            {

                mazoJ1 += 2;
                textBox1.Text = (" " + mazoJ1);
                //le de puntos al jugador

                QuienGano(mazoJ1, mazoCompu);
            }
            else if (manoJugador[2].numero < manoCompu[2].numero)
            {
                mazoCompu += 2;
                textBox2.Text = (" " + mazoCompu);

                QuienGano(mazoJ1, mazoCompu);
            }
            else
            {
                mazoCompu += 1;
                mazoJ1 += 1;
                textBox1.Text = (" " + mazoJ1);
                textBox2.Text = (" " + mazoCompu);

                QuienGano(mazoJ1, mazoCompu);
            }
        }

        private void button1_Click(object sender, EventArgs e)      //este es el boton para repartir las cartas
        {
            DarManoJugador();   //reparte las cartas
            DarManoPc();
        }

        #region no borrar
        private void carta1PC_Click(object sender, EventArgs e)
        {
           
        }

        private void carta2PC_Click(object sender, EventArgs e)
        {
           
        }

        private void carta3PC_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.MazoEnMesa.Image = TrabajoPractico.Properties.Resources.ParteDeAtras;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion 

        #endregion


       
    }
}

