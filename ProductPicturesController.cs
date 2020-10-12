using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore
{
    public class ProductPicturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductPicturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductPictures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductPictures.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductPictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPicture == null)
            {
                return NotFound();
            }

            return View(productPicture);
        }

        // GET: ProductPictures/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: ProductPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Url")] ProductPicture productPicture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // GET: ProductPictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures.FindAsync(id);
            if (productPicture == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // POST: ProductPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Url")] ProductPicture productPicture)
        {
            if (id != productPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPictureExists(productPicture.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // GET: ProductPictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPicture == null)
            {
                return NotFound();
            }

            return View(productPicture);
        }

        // POST: ProductPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productPicture = await _context.ProductPictures.FindAsync(id);
            _context.ProductPictures.Remove(productPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPictureExists(int id)
        {
            return _context.ProductPictures.Any(e => e.Id == id);
        }
    }
}
