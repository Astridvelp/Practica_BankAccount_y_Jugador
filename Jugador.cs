using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    public class Jugador
    {
        private string nombre;
        private int vida;
        private double oro;
        private bool npc;
        private int resistencia;

        public Jugador()
        {
        }
        public Jugador(string nombre)
        {
            if (nombre == null)
            {
                throw new NullReferenceException("Nombre no puede ser null");
            }

            this.nombre = nombre;
            vida = 100;
            oro = 0;
            npc = false;
            resistencia = 50;
        }
        //--Método getters
        public string Nombre
        {
            get { return nombre; }
        }

        public int Vida
        {
            get { return vida; }
        }

        public double Oro
        {
            get { return oro; }
        }

        public bool Npc
        {
            get { return npc; }
        }

        public int Resistencia
        {
            get { return resistencia; }
        }
        public void CambiarNombre(string nuevoNombre)
        {
            if (nuevoNombre == null)
            {
                throw new NullReferenceException("Nombre no puede ser null");
            }

            nombre = nuevoNombre;
        }
        public void AnadirOro(int cantidad)
        {
            oro += cantidad;
        }
        public void QuitarOro(int cantidad)
        {
            if (cantidad > oro)
            {
                throw new ArgumentOutOfRangeException("cantidad");
            }

            oro -= cantidad;
        }
        public void AsignarNPC()
        {
            npc = true;
        }

        public void DesasignarNPC()
        {
            npc = false;
        }
        public void AnadirResistencia()
        {
            if (npc)
            {
                throw new Exception("Error de resistencia, este personaje es un npc");
            }

            resistencia += 10;
        }

        public void QuitarResistencia()
        {
            if (resistencia <= 0)
            {
                throw new ArgumentOutOfRangeException("resistencia");
            }

            resistencia -= 10;
        }
    }
}
