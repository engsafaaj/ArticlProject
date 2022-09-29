using ArticlProject.Core;
using ArticlProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ArticlProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataHelper<Author> dataHelper;
        private readonly IWebHostEnvironment webHost;
        private readonly Code.FilesHelper filesHelper;
        public AuthorController(IDataHelper<Author> dataHelper, IWebHostEnvironment webHost)
        {
            this.dataHelper = dataHelper;
            this.webHost = webHost;
            filesHelper = new Code.FilesHelper(this.webHost);
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            return View(dataHelper.GetAllData());
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = dataHelper.Find(id);
            CoreView.AuthorView authorView = new CoreView.AuthorView
            {
                Id = author.Id,
                Bio = author.Bio,
                Facbook = author.Facbook,
                FullName = author.FullName,
                Instagram = author.Instagram,
                Twitter = author.Twitter,
                UserId = author.UserId,
                UserName = author.UserName,
            };
            return View(authorView);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoreView.AuthorView collection)
        {
            try
            {
                var author = new Author
                {
                    Id = collection.Id,
                    Bio = collection.Bio,
                    Facbook = collection.Facbook,
                    FullName = collection.FullName,
                    Instagram = collection.Instagram,
                    Twitter = collection.Twitter,
                    UserId = collection.UserId,
                    UserName = collection.UserName,
                    ProfileImageUrl = filesHelper.UploadFile(collection.ProfileImageUrl, "Images")

                };
                dataHelper.Edit(id, author);

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = dataHelper.Find(id);
            CoreView.AuthorView authorView = new CoreView.AuthorView
            {
                Id = author.Id,
                Bio = author.Bio,
                Facbook = author.Facbook,
                FullName = author.FullName,
                Instagram = author.Instagram,
                Twitter = author.Twitter,
                UserId = author.UserId,
                UserName = author.UserName,
            };
            return View(authorView);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author collection)
        {
            try
            {
                dataHelper.Delete(id);
                string filePath = "~/Images/" + collection.ProfileImageUrl;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
