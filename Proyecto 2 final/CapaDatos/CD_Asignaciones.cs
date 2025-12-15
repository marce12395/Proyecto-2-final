using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaDatos
{
    public class CD_Asignaciones
    {
        public int AsignacionID { get; set; }      
        public int ReparacionID { get; set; }       
        public int TecnicoID { get; set; }         
        public DateTime FechaAsignacion { get; set; } 
    }
}