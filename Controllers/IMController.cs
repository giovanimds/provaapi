using System.Linq;
using AcademiaIMC.Data;
using AcademiaIMC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIMC.Controllers
{
	[ApiController]
	[Route("api/imc")]
	public class IMController : Controller
	{
		private readonly DataContext _ctx;

		public IMController(DataContext ctx)
		{
			_ctx = ctx;
		}
		
		[HttpPost]
		[Route("cadastrar")]
		public IActionResult CadastrarIMC([FromBody] IMC imc)
		{
			imc.usuario = _ctx.Usuarios.Find(imc.usuario.UsuarioId);
			imc.Resultado = imc.Peso / (imc.Altura * imc.Altura);
			imc.Classificacao = imc.Resultado switch
			{
				< 18.5 =>
					"Magreza",
				< 25 =>
					"Normal",
				< 30 =>
					"Sobrepeso",
				< 40 =>
					"Obesidade",
				_ => "Obesidade grave"
			};
			imc.Grau = imc.Resultado switch
			{
				< 18.5 =>
					"O",
				< 25 =>
					"O",
				< 30 =>
					"I",
				< 40 =>
					"II",
				_ => "III"
			};
			
			_ctx.Imcs.Add(imc);
			_ctx.SaveChanges();
			return Created("", imc);
		}

		[HttpPatch]
		[Route("alterar")]
		public IActionResult AlterarIMC([FromBody] IMC imc)
		{
			imc.usuario = _ctx.Usuarios.Find(imc.usuario.UsuarioId);
			imc.Resultado = imc.Peso / (imc.Altura * imc.Altura);
			imc.Classificacao = imc.Resultado switch
			{
				< 18.5 =>
					"Magreza",
				< 25 =>
					"Normal",
				< 30 =>
					"Sobrepeso",
				< 40 =>
					"Obesidade",
				_ => "Obesidade grave"
			};
			imc.Grau = imc.Resultado switch
			{
				< 18.5 =>
					"O",
				< 25 =>
					"O",
				< 30 =>
					"I",
				< 40 =>
					"II",
				_ => "III"
			};

			_ctx.Imcs.Update(imc);
			_ctx.SaveChanges();
			return Ok(imc);
		}

		[HttpGet]
		[Route("listar")]
		public IActionResult ListarIMC() => Ok(_ctx.Imcs.Include(x => x.usuario).ToList());

		[HttpGet]
		[Route("buscar/{id:int}")]
		public IActionResult BuscarIMC([FromRoute] int id)
		{
			_ctx.Usuarios.Load();
			IMC imc = _ctx.Imcs.Find(id);
			return Ok(imc);
		}
	}
}