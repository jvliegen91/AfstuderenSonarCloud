using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afstuderen2020.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Afstuderen2020.Controllers
{
    public class CommentsController : Controller
    {
        private readonly Afstuderen2020Context _context;
        public CommentsController(Afstuderen2020Context context)
        {
            _context = context;
        }

        public ActionResult Index(string SearchComment)
        {
            var comments = from comment in _context.Comments select comment;

            if (!string.IsNullOrEmpty(SearchComment))
            {
                comments = comments.Where(c => c.Name.Contains(SearchComment) || c.Email.Contains(SearchComment) || c.Message.Contains(SearchComment));
            }
            return View(comments.ToList());
        }


        // GET: Xss/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Xss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Xss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Xss/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Xss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Xss/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Xss/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}