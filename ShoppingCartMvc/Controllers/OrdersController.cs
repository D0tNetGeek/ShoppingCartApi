using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Core.Models;
using Domain.Core.Services.Contracts;

namespace ShoppingCartMvc.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        public async Task<ActionResult> Index()
        {
            var orders = await _orderService.GetList(User.Identity.Name);
            return View(orders);
        }
        
        public ActionResult Create()
        {
            var result = _orderService.GetOrderData(User.Identity.Name);
            ViewBag.ShoppingCartId = result.ShoppingCartId;
            ViewBag.ShoppingListItemsCount = result.ShoppingListItemsCount;
            ViewBag.TotalAmount = result.TotalAmount;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ShoppingCartId,Date,Address,Amount")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.ProceedOrder(order, User.Identity.Name);
                
                return RedirectToAction("Index");
            }

            return View(order);
        }

        #region redundant
        // GET: Orders/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = await _repository.Find<Order>(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        // GET: Orders/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = await _repository.Find<Order>(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.ShoppingCartId = new SelectList(_repository.ShoppingCarts, "Id", "Id", order.ShoppingCartId);
        //    return View(order);
        //}

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,ShoppingCartId,Date,Address,Amount")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.Entry(order).State = EntityState.Modified;
        //        await _repository.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ShoppingCartId = new SelectList(_repository.ShoppingCarts, "Id", "Id", order.ShoppingCartId);
        //    return View(order);
        //}

        // GET: Orders/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = await _repository.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    Order order = await _repository.Orders.FindAsync(id);
        //    _repository.Orders.Remove(order);
        //    await _repository.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _repository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #endregion
    }
}
