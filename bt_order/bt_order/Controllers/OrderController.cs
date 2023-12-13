using bt_order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bt_order.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderDbContext db;

        public OrderController(OrderDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var oList = await db.Orders.ToListAsync();
            return View(oList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await db.Orders.FirstOrDefaultAsync(o => o.Id == id);
            var listOrderDetail = await db.Details.Where(od => od.OrderId == id).ToListAsync();
            // xoa du lieu trong order detail
            foreach (var item in listOrderDetail)
            {
                db.Details.Remove(item);
            }
            // xoa du lieu trong order
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await db.Details
                                        .Where(d => d.OrderId == id)
                                        .Include(d => d.Order)
                                        .ToListAsync();
            ViewBag.OrderId = id;
            return View(orderDetails);
        }

        public IActionResult CreateOrderDetail(int OrderId)
        {
            ViewBag.OrderId = OrderId;  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(OrderDetail detail)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                await db.SaveChangesAsync();
                return Redirect($"Details/{detail.OrderId}");
            }
            ViewBag.OrderId = detail.OrderId;
            return View();
        }
        public async Task<IActionResult> DeleteOrderDetails(int OrderId, string ProductName)
        {
            var orderDetails = await db.Details.SingleOrDefaultAsync
                            (od => od.OrderId == OrderId && od.ProductName == ProductName);
            db.Details.Remove(orderDetails);
            await db.SaveChangesAsync();
            return Redirect($"Details/{OrderId}");
        }
    }
}
