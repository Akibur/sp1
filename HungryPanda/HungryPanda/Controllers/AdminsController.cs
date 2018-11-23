using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HungryPanda.ViewModels;
using HungryPanda.Models;

namespace HungryPanda.Controllers
{
    public class AdminsController : Controller
    {
        private MyDbContext _context;
        public AdminsController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult orders_admin()
        {
            Admin customer = (Admin)Session["user"];

            IEnumerable<Order> orders = _context.Orders;
            IEnumerable<OrderedMenuItems> orderedMenuItems = _context.OrderedMenuItems;
            IEnumerable<ResturantOwner> resturantOwners = _context.ResturantOwners;
            IEnumerable<ResturantMenu> resturantMenu = _context.ResturantMenus;

            var resturants = from order in orders
                             join orderedMenuItem in orderedMenuItems on order.Id equals orderedMenuItem.OrderId
                             join resturantMenus in resturantMenu on orderedMenuItem.Id equals resturantMenus.Id
                             join resturantOwner in resturantOwners on resturantMenus.Id equals resturantOwner.Id
                             select resturantOwner;




            CustomerOrdersViewModels viewModel = new CustomerOrdersViewModels();
            viewModel.Orders = orders;
            viewModel.OrderedMenuItems = orderedMenuItems;
            viewModel.ResturantOwner = resturants;
            return View(viewModel);
        }

        public ActionResult resturantsList()
        {
            Admin customer = (Admin)Session["user"];

            IEnumerable<Order> orders = _context.Orders;
            IEnumerable<OrderedMenuItems> orderedMenuItems = _context.OrderedMenuItems;
            IEnumerable<ResturantOwner> resturantOwners = _context.ResturantOwners;
            IEnumerable<ResturantMenu> resturantMenu = _context.ResturantMenus;


            var resturants = from order in orders
                             join orderedMenuItem in orderedMenuItems on order.Id equals orderedMenuItem.OrderId
                             join resturantMenus in resturantMenu on orderedMenuItem.Id equals resturantMenus.Id
                             join resturantOwner in resturantOwners on resturantMenus.Id equals resturantOwner.Id
                             select resturantOwner;




            CustomerOrdersViewModels viewModel = new CustomerOrdersViewModels();
            viewModel.Orders = orders;
            viewModel.OrderedMenuItems = orderedMenuItems;
            viewModel.ResturantOwner = resturantOwners;
            return View(viewModel);
        }
        public ActionResult customersList()
        {

             IEnumerable<Customer> customers = _context.Customers;
             IEnumerable<Order> orders = _context.Orders;
            IEnumerable<OrderedMenuItems> orderedMenuItems = _context.OrderedMenuItems;
            IEnumerable<ResturantOwner> resturantOwners = _context.ResturantOwners;
            IEnumerable<ResturantMenu> resturantMenu = _context.ResturantMenus;





            return View(customers);
        }

        //// GET: Admins/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admin admin = _admin.FindById(id);
        //    if (admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admin);
        //}

        //// GET: Admins/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admins/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Gender,DOB,Email,Address,Password,Phone")] Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _admin.Add(admin);
        //        return RedirectToAction("Index");
        //    }
        //    return View(admin);
        //}

        //// GET: Admins/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admin admin = _admin.FindById(id);
        //    if (admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admin);
        //}

        //// POST: Admins/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Gender,DOB,Email,Address,Password,Phone")] Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _admin.Edit(admin);

        //        return RedirectToAction("Index");
        //    }
        //    return View(admin);
        //}

        //// GET: Admins/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admin admin = _admin.FindById(id);
        //    if (admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admin);
        //}

        //// POST: Admins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Admin admin = _admin.FindById(id);
        //    _admin.Remove(admin.Id);
        //    return RedirectToAction("Index");
        //}

        public ActionResult Dashboard()
        {
            Admin admin = (Admin)Session["user"];

            return View(admin);
        }
        public ActionResult Admin_profile()
        {
            Admin admin = (Admin)Session["user"];

            return View(admin);
        }
        [HttpGet]
        public ActionResult edit_admin_profile()
        {
            Admin customer = (Admin)Session["user"];

            return View(customer);

        }
        [HttpPost]
        public ActionResult edit_admin_profile([Bind(Include = "Name,Email,Address,Phone")] Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
             return View("Dashboard");
        }
        //[HttpGet]
        public ActionResult change_password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult change_password([Bind(Include = "Password")] Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
            return View();
            //    return View();
        }
        public ActionResult addNewResturant()
        {
            IEnumerable<Area> area = _context.Areas;
            IEnumerable<City> cities = _context.Cities;


            CityAndAreaViewModel viewModel = new CityAndAreaViewModel
            {
                Areas = area,
                Cities = cities
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult addNewResturant([Bind(Include = "JoinDate,ResturantStatus,Role,ResturantOwnerName,ResturantName,Email,Phone,Address,Password,AreaId")]ResturantOwner resturant)
        {
            //resturant.AreaId = Int32.Parse(Request["AreaId"]);

            _context.ResturantOwners.Add(resturant);
            _context.SaveChanges();
            ViewBag.messege = "Resturant Owner Created";

            return View("Dashboard");




        }





        [HttpGet]
        public ActionResult addNewAdmin()
        {

            return View();
        }

        [HttpPost]

        public ActionResult addNewAdmin([Bind(Include = "Name,Email,Phone,Address,Password")]Admin admin)
        {
            admin.DOB = DateTime.Now;
            admin.Gender = Gender.Male;
            admin.Role = "admin";
            _context.Admins.Add(admin);
            _context.SaveChanges();

            ViewBag.messege = "Admin Created";
            return View();
        }

        //public ActionResult admin_report()
        //{
        //    return View();
        //}







    }
}
