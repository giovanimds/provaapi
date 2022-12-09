using System;

namespace AcademiaIMC.Models
{
	public class IMC
	{
		public IMC() => CriadoEm = DateTime.Now;
		public int IMCId { get; set; }
		public double Altura { get; set; }
		public double Peso { get; set; }
		public double Resultado { get; set; }
		public string Classificacao { get; set; }
		public string Grau { get; set; }
		public DateTime CriadoEm { get; set; }
		public Usuario usuario { get; set; }
		
	}
}