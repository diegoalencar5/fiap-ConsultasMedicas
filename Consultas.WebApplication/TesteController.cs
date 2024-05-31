using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Consultas.WebApplication.Data;
using Consultas.WebApplication.Models;

namespace Consultas.WebApplication
{
    public class TesteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TesteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teste
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsultaViewModel.ToListAsync());
        }

        // GET: Teste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }

            return View(consultaViewModel);
        }

        // GET: Teste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,IdMedico,IdPaciente,DtConsulta,Observacoes")] ConsultaViewModel consultaViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultaViewModel);
        }

        // GET: Teste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel.FindAsync(id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }
            return View(consultaViewModel);
        }

        // POST: Teste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,IdMedico,IdPaciente,DtConsulta,Observacoes")] ConsultaViewModel consultaViewModel)
        {
            if (id != consultaViewModel.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaViewModelExists(consultaViewModel.IdConsulta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consultaViewModel);
        }

        // GET: Teste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }

            return View(consultaViewModel);
        }

        // POST: Teste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaViewModel = await _context.ConsultaViewModel.FindAsync(id);
            if (consultaViewModel != null)
            {
                _context.ConsultaViewModel.Remove(consultaViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaViewModelExists(int id)
        {
            return _context.ConsultaViewModel.Any(e => e.IdConsulta == id);
        }
    }
}
