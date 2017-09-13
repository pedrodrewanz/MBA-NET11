using Fiap.MasterChef.Model;
using Fiap.MasterChef.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.MasterChef.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IReceitaRepository repository;
        private readonly ICategoriaRepository categoriaRepository;

        public ReceitaController(IReceitaRepository repository, ICategoriaRepository categoriaRepository)
        {
            this.repository = repository;
            this.categoriaRepository = categoriaRepository;
        }

        // GET: Receita
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Receita/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var receitaModel = repository.GetById(id.Value);
            if (receitaModel == null)
            {
                return NotFound();
            }

            return View(receitaModel);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = categoriaRepository.GetAll().ToList();
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceitaModel receitaModel)
        {
            if (ModelState.IsValid)
            {
                receitaModel.Categoria = categoriaRepository.GetById(receitaModel.Categoria.Id);
                repository.Add(receitaModel);
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = categoriaRepository.GetAll().ToList();
            return View(receitaModel);
        }

        // GET: Receita/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var receitaModel = repository.GetById(id.Value);
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
        public IActionResult Edit(int id, [Bind("Id,Titulo,Descricao,ModoPreparo")] ReceitaModel receitaModel)
        {
            if (id != receitaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(receitaModel);
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
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var receitaModel = repository.GetById(id.Value);
            if (receitaModel == null)
            {
                return NotFound();
            }

            return View(receitaModel);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var receitaModel = repository.GetById(id);
            repository.Remove(receitaModel);
            return RedirectToAction("Index");
        }

        private bool ReceitaModelExists(int id)
        {
            return repository.GetAll().Any(r => r.Id == id);
        }
    }
}
