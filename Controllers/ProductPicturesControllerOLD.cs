using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BookStore.Models
{
    public class ProductPicturesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;

        public ProductPicturesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("Id,ProductId,ImageFile")] ProductPicture productPicture)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(productPicture.ImageFile.FileName);
                string extension = Path.GetExtension(productPicture.ImageFile.FileName);
                productPicture.Url = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await productPicture.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
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

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", productPicture.Url);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

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
