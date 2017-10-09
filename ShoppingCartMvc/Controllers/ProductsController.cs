using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Core.Services.Contracts;

namespace ShoppingCartMvc.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index()
        {
            var list = await _productService.GetList();
            return View(list);
        }

        [HttpPost]
        [ActionName("AddToShoppingCart")]
        public ActionResult AddToShoppingCart(long id)
        {
            var result = _productService.AddToShoppingCart(id, User.Identity.Name);

            return Json(new { text = result });
        }

        #region redundant
        // GET: Products


        // GET: Products/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = await _repository.Find<Product>(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// GET: Products/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,ProductCode,Description,UnitPrice")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.Add(product);
        //        await _repository.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = await _repository.Find<Product>(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,ProductCode,Description,UnitPrice")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Entry(product).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = await _db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        // POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    Product product = await _db.Products.FindAsync(id);
        //    _db.Products.Remove(product);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #endregion
    }
}
