//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class envio
    {
        public int EnvioId { get; set; }
        public int ClienteId { get; set; }
        public int PaqueteId { get; set; }
        public System.DateTime fecha_envio { get; set; }
        public decimal valor_envio { get; set; }
        public bool estado { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual paquete paquete { get; set; }
    }
}
