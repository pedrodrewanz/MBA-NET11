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
    public class CategoriaController : Controller
    {
        private readonly MasterChefContext _context;

        public CategoriaController(MasterChefContext context)
        {
            _context = context;    
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categorias
                .SingleOrDefaultAsync(m => m.Id == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoriaModel);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categorias.SingleOrDefaultAsync(m => m.Id == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaModelExists(categoriaModel.Id))
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
            return View(categoriaModel);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categorias
                .SingleOrDefaultAsync(m => m.Id == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaModel = await _context.Categorias.SingleOrDefaultAsync(m => m.Id == id);
            _context.Categorias.Remove(categoriaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CategoriaModelExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
