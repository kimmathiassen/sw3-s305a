﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class StaffController : Controller
    {
        // GET: /Staff/

        [Authorize(Roles="Staff")]
        public ActionResult Worklist()
        {
            /*DBEntities DB = new DBEntities();

            var problems = (from Problem in DB.ProblemSet 
                            where (Problem.AssignedTo == "John")
                        select Problem;)

            var problems = (from cart in DB.ProblemSet select*/

            var problemList = new List<Problem>(){

                new Problem(){
                    Title = "Problem title 1", AssignedTo = "John"
                }, new Problem(){
                    Title = "Problem title 2" , AssignedTo = "Not john"
                }
            };

            


                //var cartItems = (from cart in storeDB.Carts where cart.CartId == shoppingCartId
                //return cartItems;

             
            var problems = new ProblemListViewModel()
            {
                Problems = problemList
            };
         

            return View(problemList);
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Staff/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Staff/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Staff/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Edit/5

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

        //
        // GET: /Staff/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Delete/5

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
