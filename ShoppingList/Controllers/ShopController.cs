using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShoppingListContext _context;

        public ShopController(ShoppingListContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var items = await _context.ShopItemModel.ToListAsync();
            return View(items);
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var shopItemModel = await _context.ShopItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopItemModel == null)
                return NotFound();

            return View(shopItemModel);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Unit,Section,Quantity")] ShopItemModel shopItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopItemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopItemModel);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var shopItemModel = await _context.ShopItemModel.FindAsync(id);
            if (shopItemModel == null)
                return NotFound();
            return View(shopItemModel);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Unit,Section,Quantity")] ShopItemModel shopItemModel)
        {
            if (id != shopItemModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopItemModelExists(shopItemModel.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopItemModel);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var shopItemModel = await _context.ShopItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopItemModel == null)
                return NotFound();

            return View(shopItemModel);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopItemModel = await _context.ShopItemModel.FindAsync(id);
            _context.ShopItemModel.Remove(shopItemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopItemModelExists(int id)
        {
            return _context.ShopItemModel.Any(e => e.Id == id);
        }
    }
}
