using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoWeb.Views;

namespace TodoWeb.Controllers
{
    public class TodoController : Controller
    {
        //
        // GET: /Todo/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Update(ToDoViewModel model)
        {
            return Json("done");
        }

        public JsonResult Get()
        {
            var model = new ToDoViewModel { id = 1, todo = "Hello", todos = new TodoItem[] { new TodoItem { todo = "Fred", isDone = false }, new TodoItem { todo = "Alice", isDone = true}, } };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
