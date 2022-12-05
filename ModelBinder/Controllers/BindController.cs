using Microsoft.AspNetCore.Mvc;
using ModelBinder.Data;
using Models;

namespace ModelBinder.Controllers
{
    public class BindController : Controller
    {
        private readonly ApplicationDbContext _context;

        //[BindProperty]
        //public List<EnclosurePart> EnclosureParts { get; set; }

        public BindController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.EnclosurePart.AsEnumerable().ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(List<EnclosurePart> model)
        {
            foreach (var part in model)
            {
                var Existed_Emp = _context.EnclosurePart.Find(part.Id);
                Existed_Emp.Delivery = part.Delivery;
                Existed_Emp.EnclosureId = part.EnclosureId;
                Existed_Emp.Tag = part.Tag;
                Existed_Emp.Quantity = part.Quantity;
            }

            _context.SaveChanges();

            return View(model);
        }
    }
}
