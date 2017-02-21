using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using AwesomeApp.Models.AddProducts;
using AwesomeApp.Models.Categories;
using AwesomeApp.Models.EditProduct;
using AwesomeApp.Models.IndexViewModels;
using BackEnd.Category;
using BackEnd.Models;
using BackEnd.Product;

namespace AwesomeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct product;
        private readonly ICategory category;

        public HomeController()
        {
            this.product = new Product();
            this.category = new Category();

            Mapper.Initialize(config =>
            {
                config.CreateMap<IEnumerable<ProductDomainModel>, IndexViewModel>()
                    .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src));

                config.CreateMap<ProductDomainModel, RowViewModel>()
                    .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category));

                config.CreateMap<CategoryDomainModel, CategoryViewModel>();

                config.CreateMap<IEnumerable<CategoryDomainModel>, AddProductViewModel>()
                    .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src));

                config.CreateMap<AddProductFormModel, ProductDomainModel>();

                config.CreateMap<AddProductFormModel, AddProductViewModel>();

                config.CreateMap<ProductDomainModel, EditProductViewModel>();

                config.CreateMap<EditProductFormModel, ProductDomainModel>();

                config.CreateMap<EditProductFormModel, EditProductViewModel>();
            });
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ProductDomainModel> products = product.Get();
            var viewModel = Mapper.Map<IndexViewModel>(products);
            return View(viewModel);
        }

        public ActionResult AddProduct()
        {
            IEnumerable<CategoryDomainModel> categories = category.Get();
            var addProduct = Mapper.Map<AddProductViewModel>(categories);

            return View(addProduct);
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductFormModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = Mapper.Map<ProductDomainModel>(inputModel);
                product.Add(domainModel);

                return RedirectToAction("Index");
            }

            var viewModel = Mapper.Map<AddProductViewModel>(inputModel);
            IEnumerable<CategoryDomainModel> categories = category.Get();
            viewModel.Categories = Mapper.Map<List<CategoryViewModel>>(categories);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            ProductDomainModel products = product.Get(productId);

            var viewModel = Mapper.Map<EditProductViewModel>(products);
            IEnumerable<CategoryDomainModel> categories = category.Get();
            viewModel.Categories = Mapper.Map<List<CategoryViewModel>>(categories);

            return View(viewModel);
        }

        public ActionResult EditProduct(EditProductFormModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = Mapper.Map<ProductDomainModel>(inputModel);
                if (product.Update(domainModel))
                {
                    return RedirectToAction("Index");
                }
            }

            var viewModel = Mapper.Map<EditProductViewModel>(inputModel);
            IEnumerable<CategoryDomainModel> categories = category.Get();
            viewModel.Categories = Mapper.Map<List<CategoryViewModel>>(categories);

            return View(viewModel);
        }

        public ActionResult Delete(int productId)
        {
            if (product.Delete(productId))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}