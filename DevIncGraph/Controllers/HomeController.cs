using System;
using Microsoft.AspNetCore.Mvc;
using DevIncGraph.Models;
using DevIncGraph.Models.ViewModels;
using DevIncGraph.Data;

namespace DevIncGraph.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevIncGraphContext _context;

        public HomeController(DevIncGraphContext context)
        {
            _context = context;
        }

        UserData userData = new UserData();

        public IActionResult Index()
        {
            Point point = new Point();
            point.PointX = 1;
            point.PointY = 1;
            userData.Points.Add(point);
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Points = userData.Points;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(int a, int b, int c, float step, int from, int to)
        {
            IndexViewModel viewModel = new IndexViewModel();

            if (ModelState.IsValid)
            {
                userData.RangeFrom = from;
                userData.RangeTo = to;
                userData.Step = step;
                userData.A = a;
                userData.B = b;
                userData.C = c;

                while (userData.RangeFrom <= userData.RangeTo)
                {
                    Point point = new Point();
                    
                    point.PointX = userData.RangeFrom;
                    point.PointY = userData.A * (int)Math.Pow(point.PointX, 2) + userData.B * point.PointX + userData.C;
                    userData.RangeFrom += (int)userData.Step;
                    userData.Points.Add(point);
                    _context.ContextPoints.Add(point);
                }
                _context.ContextUserDatas.Add(userData);
                _context.SaveChanges();
                viewModel.Points = userData.Points;
                viewModel.UserData = userData;
                return View(viewModel);
            }
            else
            {
                Point point = new Point();
                point.PointX = 1;
                point.PointY = 1;
                userData.Points.Add(point);
                viewModel.Points = userData.Points;
                return View(viewModel);
            }
        }
    }
}
