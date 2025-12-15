using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaDatos
{
    public class CD_Reparaciones
    {
        public int ReparacionID { get; set; }    
        public int EquipoID { get; set; }       
        public DateTime FechaSolicitud { get; set; } 
        public string Estado { get; set; }
    }
}