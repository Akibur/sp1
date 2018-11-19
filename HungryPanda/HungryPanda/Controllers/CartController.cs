using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HungryPanda.Models;
 using HungryPanda.ViewModels;
using System.Diagnostics;


namespace HungryPanda.Controllers
{
    public class CartItem

    {

        public ResturantMenu OrderItem { get; set; }
        public int Quantity { get; set; }

        public CartItem(ResturantMenu OrderItem, int Quantity)
        {
            this.OrderItem = OrderItem;
            this.Quantity = Quantity;
        }

        public void UpdateQuantity(int Quantity)
        {
            this.Quantity = Quantity;

        }




    }


    //public class CartController : Controller
    //{



    //    //private ICityRepository _city;
    //    //private IAreaRepository _area;
    //    //private IResturantOwnerRepository _resturant;
    //    //private IResturantMenuRepository _resturantMenu;
    //    //private IResturantMenuCategoryRepository _resturantMenuCategory;
    //    //private IOrderRepository _order;
    //    //private IOrderedMenuItemsRepository _orderedMenuItems;






    //    //public CartController(IOrderedMenuItemsRepository orderedMenuItems, IOrderRepository order, IResturantMenuCategoryRepository resturantMenuCategory, ICityRepository city, IAreaRepository area, IResturantOwnerRepository resturant, IResturantMenuRepository resturantMenu)
    //    //{
    //    //    this._city = city;
    //    //    this._area = area;
    //    //    this._resturant = resturant;
    //    //    this._resturantMenu = resturantMenu;
    //    //    this._resturantMenuCategory = resturantMenuCategory;
    //    //    this._order = order;
    //    //    this._orderedMenuItems = orderedMenuItems;
    //    //}

    //    private MyDbContext _context;
    //    public CartController()
    //    {
    //        _context = new MyDbContext();
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        _context.Dispose();
    //    }




    //    // GET: Cart
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    //Add to cart
    //    public ActionResult AddToCart(int itemId)
    //    {
    //        ResturantMenu resturantMenu = _resturantMenu.FindById(itemId);


    //        if (Session["cart"] == null)

    //        {

    //            List<CartItem> cart = new List<CartItem>();

    //            cart.Add(new CartItem(resturantMenu, 1));
    //            Session["cart"] = cart;

    //        }
    //        else
    //        {

    //            List<CartItem> cart = (List<CartItem>)Session["cart"];


    //            cart.Add(new CartItem(resturantMenu, 1));
    //            Session["cart"] = cart;

    //        }




    //        return Json(resturantMenu, JsonRequestBehavior.AllowGet);
    //    }
    //    [HttpGet]
    //    public ActionResult RemoveFromCart(int itemId)
    //    {
    //        List<CartItem> cart = (List<CartItem>)Session["cart"];
    //        var itemToRemove = cart.FirstOrDefault(r => r.OrderItem.Id == itemId);
    //        cart.Remove(itemToRemove);

    //        Session["Cart"] = cart;

    //        return RedirectToAction("Index", "Cart");


    //    }

    //    public ActionResult EditQuantity(int itemId, int itemQuantity)
    //    {
    //        List<CartItem> cart = (List<CartItem>)Session["cart"];
    //        cart.FirstOrDefault(r => r.OrderItem.Id == itemId).UpdateQuantity(itemQuantity);

    //        Session["cart"] = cart;

    //        return RedirectToAction("Index", "Cart");

    //    }

    //    public ActionResult Checkout()
    //    {
    //        if (Session["user"] == null)
    //        {
    //            Response.Redirect("~/Authentication");

    //        }
    //        var user = Session["user"] as Customer;

    //        IEnumerable<Order> orders = _order.GetOrders();
    //        IEnumerable<OrderedMenuItems> orderedMenuItems = _orderedMenuItems.GetOrderedMenuItems();
    //        IEnumerable<ResturantOwner> resturantOwners = _resturant.GetResturantOwner();
    //        IEnumerable<ResturantMenu> resturantMenu = _resturantMenu.GetResturantMenu();

    //        var resturants = from o in orders
    //                         join orderedMenuItem in orderedMenuItems on o.Id equals orderedMenuItem.OrderId
    //                         join resturantMenus in resturantMenu on orderedMenuItem.ResturantMenuId equals resturantMenus.Id
    //                         join resturantOwner in resturantOwners on resturantMenus.ResturantOwnerId equals resturantOwner.Id

    //                         select new
    //                         {
    //                             rName = resturantOwner.ResturantName

    //                         };
    //        var res = "";
    //        foreach (var item in resturants)
    //        {
    //            res = item.rName;
    //        }
    //        //Add the order in the database

    //        Order order = new Order
    //        {
    //            ResturantName = res,
    //            OrderDate = DateTime.Now,
    //            OrderStatus = OrderStatus.Processing,
    //            DeliveryDate = DateTime.Now.AddHours(2),
    //            CustomerId = user.Id,
    //            ReviewId = null
    //        };


    //        _order.Add(order);

    //        //get OrderId from the database

    //        var or = _order.GetOrders().Last();

    //        var orderId = or.Id;
    //        //Insert Ordered Items

    //        foreach (var cart in (List<CartItem>)Session["cart"])
    //        {
    //            if (cart != null)
    //            {
    //                OrderedMenuItems orderedItems = new OrderedMenuItems
    //                {
    //                    Quantity = cart.Quantity,
    //                    Price = cart.OrderItem.Price,
    //                    OrderId = orderId,
    //                    ResturantMenuId = cart.OrderItem.Id
    //                };


    //                _orderedMenuItems.Add(orderedItems);
    //            }




    //        }
    //        Session["cart"] = null;






    //        return View();
    //    }













    //    // GET: Cart/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: Cart/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Cart/Create
    //    [HttpPost]
    //    public ActionResult Create(FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add insert logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: Cart/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: Cart/Edit/5
    //    [HttpPost]
    //    public ActionResult Edit(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add update logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: Cart/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: Cart/Delete/5
    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}
}
