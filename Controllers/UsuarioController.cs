using System.Linq;
using AcademiaIMC.Data;
using AcademiaIMC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaIMC.Controllers
{
	[ApiController]
	[Route("api/usuario")]
	public class UsuarioController : Controller
	{
		private readonly DataContext _ctx;

		public UsuarioController(DataContext ctx)
		{
			_ctx = ctx;
		}
		
		[HttpPost]
		[Route("cadastrar")]
		public IActionResult CadastrarUsuario([FromBody] Usuario usuario)
		{
			_ctx.Usuarios.Add(usuario);
			_ctx.SaveChanges();
			return Ok(usuario);
		}

		[HttpGet]
		[Route("listar")]
		public IActionResult ListarUsuario()
		{
			return Ok(_ctx.Usuarios.ToList());
		}
		
	}
}