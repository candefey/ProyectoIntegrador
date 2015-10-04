using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deportista
    {
        private int idDeportista;
        private String nombre;
        private String apellido;
        private int nroDoc;
        private String fechaNacimiento;
        private int cuit;
        private String mail;
        private int edad;
        private TipoDocumento tipoDoc;
        private Patologia patologia;
        private Gimnasio gim;
        private SexoDeportista sexo;
        private int tieneMail;

        
        public int IdDeportista
        {
            get
            {
                return idDeportista;
            }

            set
            {
                idDeportista = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public int NroDoc
        {
            get
            {
                return nroDoc;
            }

            set
            {
                nroDoc = value;
            }
        }

        public String FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public int Cuit
        {
            get
            {
                return cuit;
            }

            set
            {
                cuit = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }

        public TipoDocumento TipoDoc
        {
            get
            {
                return tipoDoc;
            }

            set
            {
                tipoDoc = value;
            }
        }

        public Patologia Patologia
        {
            get
            {
                return patologia;
            }

            set
            {
                patologia = value;
            }
        }

        public Gimnasio Gim
        {
            get
            {
                return gim;
            }

            set
            {
                gim = value;
            }
        }

        public SexoDeportista Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public int TieneMail
        {
            get
            {
                return tieneMail;
            }

            set
            {
                tieneMail = value;
            }
        }

        public Deportista()
        { }

        public Deportista(int idDeportista, string nombre, string apellido, int nroDoc, string fechaNacimiento, int cuit, string mail, int edad, TipoDocumento tipoDoc, Patologia patologia, Gimnasio gim, SexoDeportista sexo, int tieneMail)
        {
            this.idDeportista = idDeportista;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroDoc = nroDoc;
            this.fechaNacimiento = fechaNacimiento;
            this.cuit = cuit;
            this.mail = mail;
            this.edad = edad;
            this.tipoDoc = tipoDoc;
            this.patologia = patologia;
            this.gim = gim;
            this.sexo = sexo;
            this.tieneMail = tieneMail;
        }

        public Deportista(string nombre, string apellido, int nroDoc, string fechaNacimiento, int cuit, string mail,TipoDocumento tipoDoc, Patologia patologia, Gimnasio gim, SexoDeportista sexo, int tieneMail)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroDoc = nroDoc;
            this.fechaNacimiento = fechaNacimiento;
            this.cuit = cuit;
            this.mail = mail;
            this.edad = (int)calcularEdad(fechaNacimiento);
            this.tipoDoc = tipoDoc;
            this.patologia = patologia;
            this.gim = gim;
            this.sexo = sexo;
            this.tieneMail = tieneMail;
        }



        public double calcularEdad(String fechaNac)
        {
            return DateTime.Today.Subtract(DateTime.Parse(fechaNac)).TotalDays / 365;
        }
    }
}
