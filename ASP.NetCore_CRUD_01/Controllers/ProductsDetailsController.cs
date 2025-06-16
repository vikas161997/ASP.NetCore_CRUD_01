using ASP.NetCore_CRUD_01.DataBase;
using ASP.NetCore_CRUD_01.Model;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NetCore_CRUD_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : ControllerBase
    {
        //private static List<ProductsDetail> _ProductsDetails = new List<ProductsDetail>
        //{
        //    new ProductsDetail{PId=1,Name="Iphone",Description="Best phone in the world", Price=80000},
        //    new ProductsDetail{PId=2,Name="samsung",Description="best in the invention",Price = 700000},
        //    new ProductsDetail{PId=3,Name="Nothing" , Description= "Copy version of iphone and samsung",Price=40000},
        //    new ProductsDetail{PId=4,Name="google pixel", Description="best camera but processor is not goood",Price=60000}
        //};


        private readonly ApplicationDbContext _DbContext;

        public ProductsDetailsController(ApplicationDbContext appcontext)
        {
            _DbContext = appcontext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductsDetail>> GetProductsDetails()
        {
            return Ok(_DbContext.PDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<ProblemDetails> GetProductsdetailsById(int id)
        {
            var productsDetails = _DbContext.PDetails.FirstOrDefault(p => p.EmployeeId == id);

            if (productsDetails == null)
            {
                return NotFound();
            }
            return Ok(productsDetails);
        }

        [HttpPost]
        public ActionResult<ProductsDetail> CreateProduct(ProductsDetail productsDetails1)
        {
            productsDetails1.EmployeeId = 0;
            //productsDetails1.EmployeeId = _DbContext.PDetails.Max(p => p.EmployeeId) + 1;
            _DbContext.PDetails.Add(productsDetails1);
            _DbContext.SaveChanges();

            return Ok(productsDetails1);
        }



        [HttpPut]
        public ActionResult<ProductsDetail> updateProductsdetails(int id, ProductsDetail productsDetails1)
        {
            var ExistingProducts = _DbContext.PDetails.FirstOrDefault(p => p.EmployeeId == id);

            if (ExistingProducts == null)
            {
                return BadRequest();
            }

            ExistingProducts.FirstName = productsDetails1.FirstName;
            ExistingProducts.LastName = productsDetails1.LastName;
            ExistingProducts.Department = productsDetails1.Department;
            ExistingProducts.Salary = productsDetails1.Salary;
            ExistingProducts.dateOfJoining = productsDetails1.dateOfJoining;
            _DbContext.SaveChanges();
            return Ok(ExistingProducts);
        }


        [HttpDelete]
        public ActionResult<ProductsDetail> DeleteProduct(int id)
        {
            var ExistingProducts = _DbContext.PDetails.FirstOrDefault(p => p.EmployeeId == id);

            if (ExistingProducts == null)
            {
                return BadRequest();
            }

            _DbContext.PDetails.Remove(ExistingProducts);
            _DbContext.SaveChanges();
            return Ok(ExistingProducts);
        }
    }
}
