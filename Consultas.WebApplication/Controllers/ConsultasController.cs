using Consultas.WebApplication.Support;
using Consultas.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Consultas.WebApplication.Extensions;
using Consultas.ApplicationCore.Entities;

namespace Consultas.WebApplication.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly AppSettings _appSettings;
        public ConsultasController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        // GET: ConsultaViewModels
        public IActionResult Index()
        {
            IEnumerable<ConsultaViewModel> Consultas;
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                //HTTP GET
                var result = client.GetAsync("Consultas").Result;

                if (result.IsSuccessStatusCode)
                {
                    Consultas = result.Content.ReadAsAsync<IList<ConsultaViewModel>>().Result;                    
                }
                else
                {
                    Consultas = Enumerable.Empty<ConsultaViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(Consultas);
            }
        }

        [HttpGet]
        public IActionResult create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                ViewBag.MedicosList = client.GetAsync("Medicos").Result.Content.ReadAsAsync<IList<Medico>>().Result;
                ViewBag.PacientesList = client.GetAsync("Pacientes").Result.Content.ReadAsAsync<IList<Paciente>>().Result;
            }
            return View();
        }

        [HttpPost]
        public IActionResult create(ConsultaViewModel Consulta)
        {
            if (Consulta == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.PostAsJsonAsync<ConsultaViewModel>("Consultas", Consulta).Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(Consulta);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            ConsultaViewModel Consulta = null;

            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.GetAsync("Consultas/" + id.ToString()).Result;
                ViewBag.MedicosList = client.GetAsync("Medicos").Result.Content.ReadAsAsync<IList<Medico>>().Result;
                ViewBag.PacientesList = client.GetAsync("Pacientes").Result.Content.ReadAsAsync<IList<Paciente>>().Result;

                if (result.IsSuccessStatusCode)
                {
                    Consulta = result.Content.ReadAsAsync<ConsultaViewModel>().Result;
                }

            }

            return View(Consulta);
        }

        [HttpPost]
        public IActionResult Edit(ConsultaViewModel Consulta)
        {
            if (Consulta == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);

                var result = client.PutAsJsonAsync<ConsultaViewModel>("Consultas/" + Consulta.IdConsulta, Consulta).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Consulta);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
                return new BadRequestResult();

            ConsultaViewModel Consulta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.GetAsync("Consultas/" + id.ToString()).Result;

                if (result.IsSuccessStatusCode)
                {
                    Consulta = result.Content.ReadAsAsync<ConsultaViewModel>().Result;
                }
            }
            return View(Consulta);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);

                var result = client.DeleteAsync("Consultas/" + id.ToString()).Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
