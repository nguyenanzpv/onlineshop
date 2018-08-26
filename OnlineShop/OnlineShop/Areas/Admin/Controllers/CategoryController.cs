﻿using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var iplCate = new CategoryModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        // GET: Admin/Category/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create: khong co thuoc tinh nao
        //Lan dau khi goi create se chay phuong thuc nay goi view create.cshtml
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        //Khi click submit form se chay phuong thuoc nay
        [HttpPost]
        [ValidateAntiForgeryToken]//token de chong gia lap request. 
        public ActionResult Create(Category collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    //insert data
                    var model = new CategoryModel();
                    int res = model.Create(collection.Name,collection.Alias,collection.ParentID,collection.Order,collection.Status);
                    if(res>0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                
                return View(collection);
           

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
