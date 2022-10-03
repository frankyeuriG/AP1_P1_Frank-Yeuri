using System.ComponentModel.DataAnnotations;

namespace AP1_P1_FrankYeuri.Models 
{ 
    public class Aportes
    {
        [Key]
        public int AportesId{ get; set;}

        [Required(ErrorMessage ="Obligatorio La fecha")]
        public DateTime fecha{get; set;}

        [Required(ErrorMessage ="Obligatorio el nombre")]
        public string? Persona {get; set;}

        public string? Observacion {get; set;}

        [Range(minimum: 1 , maximum: 10000000, ErrorMessage ="Monto valido de 1 hasta 10,000,000")]
        public double Monto {get; set;}
        
    }
 }