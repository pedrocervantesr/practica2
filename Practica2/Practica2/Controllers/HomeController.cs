using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practica2.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.Json;

namespace Practica2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Practica2bddContext _context;

        public HomeController(ILogger<HomeController> logger, Practica2bddContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Persona> personaList = new List<Persona>();
            personaList = _context.Personas.ToList();
            return View(personaList);
        }

        public JsonResult Filtrar(string columna, int filtro, string dato)
        {
            var parametro = new SqlParameter("dato", dato);

            List<Persona> personas = new List<Persona>();
            if(filtro == 1) {
                personas = _context.Personas
                .FromSqlRaw($"SELECT * FROM personas WHERE {columna} < @dato", parametro)
                .ToList();
            } else if(filtro == 2)
            {
                personas = _context.Personas
                .FromSqlRaw($"SELECT * FROM personas WHERE {columna} >  @dato", parametro)
                .ToList();
            } else if( filtro == 3)
            {
                personas = _context.Personas
                .FromSqlRaw($"SELECT * FROM personas WHERE {columna} =  @dato", parametro)
                .ToList();
            }
            

            foreach (var item in personas)
            {
                Console.WriteLine(item.Nombre);
            }

            //return RedirectToAction(nameof(Index), personas);
            JsonResult json = Json(personas);
            string jsonstring = JsonSerializer.Serialize(json);
            return json;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}