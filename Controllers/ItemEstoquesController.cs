using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Treinando.Data;
using Treinando.Models;

namespace Treinando.Controllers
{
    public class ItemEstoquesController : Controller
    {
        private readonly AppDbContext _context;

        public ItemEstoquesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ItemEstoques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estoque.ToListAsync());
        }

        // GET: ItemEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemEstoque = await _context.Estoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemEstoque == null)
            {
                return NotFound();
            }

            return View(itemEstoque);
        }

        // GET: ItemEstoques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,Valor")] ItemEstoque itemEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemEstoque);
        }

        // GET: ItemEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemEstoque = await _context.Estoque.FindAsync(id);
            if (itemEstoque == null)
            {
                return NotFound();
            }
            return View(itemEstoque);
        }

        // POST: ItemEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,Valor")] ItemEstoque itemEstoque)
        {
            if (id != itemEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemEstoqueExists(itemEstoque.Id))
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
            return View(itemEstoque);
        }

        // GET: ItemEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemEstoque = await _context.Estoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemEstoque == null)
            {
                return NotFound();
            }

            return View(itemEstoque);
        }

        // POST: ItemEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemEstoque = await _context.Estoque.FindAsync(id);
            if (itemEstoque != null)
            {
                _context.Estoque.Remove(itemEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemEstoqueExists(int id)
        {
            return _context.Estoque.Any(e => e.Id == id);
        }
    }
}
