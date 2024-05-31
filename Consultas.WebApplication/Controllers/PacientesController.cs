using Consultas.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Consultas.WebApplication.Extensions;
using Consultas.ApplicationCore.Entities;
using Consultas.WebApplication.Support;

namespace Pacientes.WebApplication.Controllers
{
    public class PacientesController : Controller
    {
        private readonly AppSettings _appSettings;
        public PacientesController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        // GET: PacienteViewModels
        public IActionResult Index()
        {
            IEnumerable<PacienteViewModel> Pacientes;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                //HTTP GET
                var result = client.GetAsync("Pacientes").Result;

                if (result.IsSuccessStatusCode)
                {
                    Pacientes = result.Content.ReadAsAsync<IList<PacienteViewModel>>().Result;
                }
                else
                {
                    Pacientes = Enumerable.Empty<PacienteViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(Pacientes);
            }
        }

        [HttpGet]
        public IActionResult create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
            }
            return View();
        }

        [HttpPost]
        public IActionResult create(PacienteViewModel Paciente)
        {
            if (Paciente == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.PostAsJsonAsync<PacienteViewModel>("Pacientes", Paciente).Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(Paciente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            PacienteViewModel Paciente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.GetAsync("Pacientes/" + id.ToString()).Result;

                if (result.IsSuccessStatusCode)
                {
                    Paciente = result.Content.ReadAsAsync<PacienteViewModel>().Result;
                }

            }

            return View(Paciente);
        }

        [HttpPost]
        public IActionResult Edit(PacienteViewModel Paciente)
        {
            if (Paciente == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);

                var result = client.PutAsJsonAsync<PacienteViewModel>("Pacientes/" + Paciente.IdPaciente, Paciente).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Paciente);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
                return new BadRequestResult();

            PacienteViewModel Paciente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);
                var result = client.GetAsync("Pacientes/" + id.ToString()).Result;

                if (result.IsSuccessStatusCode)
                {
                    Paciente = result.Content.ReadAsAsync<PacienteViewModel>().Result;
                }
            }
            return View(Paciente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return new BadRequestResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.ApiUri);

                var result = client.DeleteAsync("Pacientes/" + id.ToString()).Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
