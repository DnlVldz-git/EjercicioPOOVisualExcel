using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOOVisual
{
    class Juego
    {       
        private String gato1;
        private String gato2;
        private String gato3;
        private String ganador;
        private int[] num_gatos;
        public String PrintGato(int num)
        {
            switch (num)
            {
                case 0:
                    return ("Aldo");

                case 1:
                    return ("Kitty");

                case 2:
                    return ("Bola");

                case 3:
                    return ("Pelusa");

                case 4:
                    return ("Patas");


                case 5:
                    return ("Mr Puffle");


                case 6:
                    return ("Torisosu");

                case 7:
                    return ("Gilbert");

                case 8:
                    return ("Java");

                default:
                    return "";
            }
        }

        public void ObtenerGatosParticipantes() 
        {
            Random rnd = new Random();
            int gato1 = rnd.Next(8);
            int gato2 = rnd.Next(8);
            int gato3 = rnd.Next(8);
            this.num_gatos = new int[3];
            num_gatos[0] = gato1;
            num_gatos[1] = gato2;
            num_gatos[2] = gato3;
            while (true)
            {
                if ((gato1 == gato2) || (gato1 == gato3) || (gato2 == gato3))
                {
                    gato1 = rnd.Next(8);
                    gato2 = rnd.Next(8);
                    gato3 = rnd.Next(8);
                }
                else
                {
                    num_gatos[0] = gato1;
                    num_gatos[1] = gato2;
                    num_gatos[2] = gato3;
                    this.gato1 = PrintGato(gato1);
                    this.gato2 = PrintGato(gato2);
                    this.gato3 = PrintGato(gato3);
                    break;
                }
            }
        }

        public Boolean Jugar(Double dinero, Cuenta cuenta, int resp)
        {
            Random rnd = new Random();                                 

            int ganador = rnd.Next(2);

            this.ganador = PrintGato(num_gatos[ganador]);

            if (ganador == (resp - 1))
            {                
                cuenta.DineroGanado += (dinero + (dinero / 2));
                cuenta.calcularDineroTotal();
                return true;
            }
            else
            {                
                cuenta.DineroPerdido += (dinero);
                cuenta.calcularDineroTotal();
                return false;
            }

        }

        public String GetGato1() 
        {
            return this.gato1;
        }

        public String GetGato2()
        {
            return this.gato2;
        }

        public String GetGato3()
        {
            return this.gato3;
        }

        public String GetGanador()
        {
            return this.ganador;
        }
    }
}
