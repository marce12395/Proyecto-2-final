using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaDatos
{
    public class CD_Detalle
    {
        public int DetalleID { get; set; }          
        public int ReparacionID { get; set; }       
        public string Descripcion { get; set; }     
        public DateTime FechaInicio { get; set; }   
        public DateTime? FechaFin { get; set; }     
    }
}
