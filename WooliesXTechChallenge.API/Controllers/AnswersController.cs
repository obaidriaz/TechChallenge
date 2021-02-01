using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;
using WooliesXTechChallenge.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WooliesXTechChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private IUserService _userService;
        private IProductService _productService;
        public AnswersController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        // GET: api/<AnswersController>

        /// <summary>
        /// Gets the user information 
        /// </summary>
        /// <returns>Basic user information</returns>
        [HttpGet]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> GetUser()
        {
            return Ok(_userService.GetUser());
        }

        /// <summary>
        /// Sorts the list of products based on the sorting option provided
        /// </summary>
        /// <param name="sortOption">Sorting option to be used for sorting
        /// "Low" - Low to High Price
        /// "High" - High to Low Price
        /// "Ascending" - A - Z sort on the Name
        /// "Descending" - Z - A sort on the Name
        /// "Recommended" - this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity
        /// </param>
        /// <returns>Sorted list of products</returns>
        [HttpGet]
        [Route("sort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Product>>> SortProducts(string sortOption)
        {
            if (string.IsNullOrEmpty(sortOption))
                return BadRequest();

            return Ok(await _productService.GetSortedProducts(sortOption));
        }

        /// <summary>
        /// Calculates the lowest trolley total
        /// </summary>
        /// <param name="trolleyData">Trolley data for calculation</param>
        /// <returns>Lowest trolley total</returns>
        [HttpPost]
        [Route("trolleyTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetLowestTrolleyTotal(TrolleyDataDTO trolleyData)
        {
            return Ok(await _productService.GetLowestTrolleyTotal(trolleyData));
        }
    }
}
