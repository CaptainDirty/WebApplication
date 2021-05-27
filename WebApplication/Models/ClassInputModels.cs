using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ClassInputModels
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public double CH4 { get; set; }
        public double C2H6 { get; set; }
        public double C3H8 { get; set; }
        public double C4H10 { get; set; }
        public double C5H12 { get; set; }
        public double N2 { get; set; }
        public double CO2 { get; set; }
        public double KPD { get; set; }
        public double ParPr { get; set; } 
        public double WorkPressureOnDrum { get; set; }
        public double WorkPressureOnExit { get; set; }
        public double Tpp { get; set; }
        public double Tpv { get; set; }
        public double Tug { get; set; }
        public double Tgv { get; set; }
        public double Thv { get; set; }
        public double Tpodgas { get; set; }
        public double Tpodvosd { get; set; }
        public double alfa { get; set; }
        public double himnedog { get; set; }
        public double Vlagosod { get; set; }
        public double D { get; set; }
        public double L { get; set; }
        [NotMapped]
        public string Description { get; set; }
    }
}
