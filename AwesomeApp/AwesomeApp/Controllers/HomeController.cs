using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using AwesomeApp.Models;
using AwesomeApp.Models.AddProducts;
using AwesomeApp.Models.Categories;
using AwesomeApp.Models.IndexViewModels;
using BackEnd;
using BackEnd.Models;

namespace AwesomeApp.Controllers
{
    public class HomeController : Controller
    {
        private IBackEnd backEnd;

        public HomeController()
        {
            this.backEnd = new BackEnd.BackEnd();
            Mapper.Initialize(config =>
            {
                config.CreateMap<IEnumerable<ProductDomainModel>, IndexViewModel>()
                    .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src));

                config.CreateMap<ProductDomainModel, RowViewModel>()
                    .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category));

                config.CreateMap<CategoryDomainModel, CategoryViewModel>();
            });
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = backEnd.Get();
            var viewModel = Mapper.Map<IndexViewModel>(products);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductFormModel input)
        {
            var addModel = Mapper.Map<ProductDomainModel>(input);
            backEnd.Add(addModel);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProduct()
        {
            var addProduct = new AddProductViewModel()
            {
                Categories = new List<CategoryViewModel>()
                {
                    new CategoryViewModel()
                    {
                        Id = 1,
                        Name = "name"
                    },
                    new CategoryViewModel()
                    {
                        Id = 2,
                        Name = "dfkls"
                    }
                }
            };
            return View(addProduct);
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = Mapper.Map<ProductDomainModel>(inputModel);
                backEnd.Add(domainModel);
            }
            var viewModel = Mapper.Map<AddProductViewModel>(inputModel);
            return View(viewModel);
        }
    }
}