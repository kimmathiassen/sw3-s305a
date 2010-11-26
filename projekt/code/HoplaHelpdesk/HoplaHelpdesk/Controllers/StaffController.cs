﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    //[Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        hoplaEntities DB = new hoplaEntities();

        public ActionResult Worklist()
        {
            List<Problem> problemList;

            //try{

            int myID = DB.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            problemList = DB.ProblemSet.Where(x => x.PersonsId == myID).ToList();

            //}catch (Exception){return View("Error");}


            var viewModel = new ProblemListViewModel()
            {
                Problems = problemList,
                Editable = true,
                Deletable = true
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(ProblemDetailsCommentListViewModel model, int id)
        {
            model.comment.Problem_Id = id;
            model.comment.Person = DB.PersonSet.Single(x => x.Name.ToLower() == User.Identity.Name.ToLower());
            
            model.comment.time = DateTime.Now;

            DB.ProblemSet.Single(x => x.Id == id).CommentSet.Add(model.comment);
            DB.SaveChanges();

            return this.Details(id);
        }

        public ActionResult Details(int id)
        {
            Problem problem = new Problem();
            try
            {
                problem = DB.ProblemSet.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return View("Error");
            }

            //try
            //{

            int myID = DB.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            List<Comment> comments = new List<Comment>();

            comments = (from Comment in DB.CommentSet
                        where Comment.Problem_Id == id
                        select Comment).ToList();

            //} catch (Exception) { return View("Error");}

            //try
            //{

            List<Solution> solutions = new List<Solution>();

            solutions = DB.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.ToList();

            //} catch (Exception) { return View("Error");}

            var viewModel = new ProblemDetailsCommentListViewModel()
            {
                Problem = problem,
                Comments = comments,
                Solutions = solutions
            };

            return View(viewModel);
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