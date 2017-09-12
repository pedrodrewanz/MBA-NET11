using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.MasterChef.Model;
using Fiap.MasterChef.Repository;

namespace Fiap.MasterChef.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly MasterChefContext _context;

        public ReceitaController(MasterChefContext context)
        {
            _context = context;    
        }

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receitas.ToListAsync());
        }

        // GET: Receita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitaModel = await _context.Receitas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (receitaModel == null)
            {
                return NotFound();
            }

            return View(receitaModel);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,ModoPreparo")] ReceitaModel receitaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receitaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(receitaModel);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitaModel = await _context.Receitas.SingleOrDefaultAsync(m => m.Id == id);
            if (receitaModel == null)
            {
                return NotFound();
            }
            return View(receitaModel);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,ModoPreparo")] ReceitaModel receitaModel)
        {
            if (id != receitaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receitaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaModelExists(receitaModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(receitaModel);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitaModel = await _context.Receitas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (receitaModel == null)
            {
                return NotFound();
            }

            return View(receitaModel);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receitaModel = await _context.Receitas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Receitas.Remove(receitaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReceitaModelExists(int id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
