using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class GestorDeportista
    {
        public static List<Deportista> obtenerTodos()
        {
            List<Deportista> lista = new List<Deportista>();
            lista = DaoDeportista.select();
            return lista;
        }


        public static void guardarDeportista(string nombre, string ape, int cuil, bool tieneMail, string mail, string fechaNac,int doc, String tipoDoc, String gim, String pat, String sexo )
        {

            Gimnasio g =obtenerGim(gim);
            Patologia p =obtenerPatologia(pat);
            SexoDeportista s=obtenerSexo(sexo);
            TipoDocumento tipo = obtenerTipoDoc(tipoDoc);
            Deportista d = new Deportista(nombre, ape, doc, fechaNac, cuil, mail,tipo, p, g, s, traducirTieneMail(tieneMail));
            DaoDeportista.insertarDeportista(d);

        }

        public static void actualizarDeportista(string nombre, string ape, int cuil, bool tieneMail, string mail, string fechaNac, int doc, String tipoDoc, String gim, String pat, String sexo)
        {

            Gimnasio g = obtenerGim(gim);
            Patologia p = obtenerPatologia(pat);
            SexoDeportista s = obtenerSexo(sexo);
            TipoDocumento tipo = obtenerTipoDoc(tipoDoc);
            Deportista d = new Deportista(nombre, ape, doc, fechaNac, cuil, mail, tipo, p, g, s, traducirTieneMail(tieneMail));
            DaoDeportista.update(d);

        }

        public static Gimnasio obtenerGim(string nom)
        {
            return DaoGimnasio.obtenerGim(nom);
        }


        public static SexoDeportista obtenerSexo(string sexo)
        {
            return DaoSexo.obtenerSexo(sexo);
        }

        public static Patologia obtenerPatologia(string pat)
        {
            return DaoPatologia.obtenerPatologia(pat);
        }

        public static TipoDocumento obtenerTipoDoc(string tipo)
        {
            return DaoTipoDocumento.obtenerTipoDoc(tipo);
        }




        private static int traducirTieneMail(Boolean t)
        {
            if (t == true)
                return 1;
            else
                return 0;

        }

        public static List<SexoDeportista> obtenerSexos()
        {
            List<SexoDeportista> listaSexos = new List<SexoDeportista>();
            listaSexos = DaoSexo.select();
            return listaSexos;
        }

        public static List<TipoDocumento> obtenerTipoDocumentos()
        {
            List<TipoDocumento> listaDocumentos = new List<TipoDocumento>();
            listaDocumentos = DaoTipoDocumento.select();
            return listaDocumentos;
        }

        public static List<Gimnasio> obtenerGimnasios()
        {
            List<Gimnasio> listaGims = new List<Gimnasio>();
            listaGims = DaoGimnasio.select();
            return listaGims;
        }

        public static List<Patologia> obtenerPatologias()
        {
            List<Patologia> listaPato = new List<Patologia>();
            listaPato = DaoPatologia.select();
            return listaPato;
        }


        public static void eliminarDeportista(int cuit)
        {
            DaoDeportista.delete(cuit);
        }
    }
}
