using Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Mapper.Contracts;
using Data.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace WepAPI.Controllers
{
    [Authorize]
    public class CategoriesController : APIBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET Categories
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryDTO> categoriesDTO = _categoryService.GetAll();
            return Ok(categoriesDTO);
        }

        // GET Categories/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_categoryService.CategoryExists(id))
            {
                return NotFound();
            }   

            CategoryDTO categoryDTO = _categoryService.GetById(id);
            return Ok(categoryDTO);
        }

        // POST Categories
        [HttpPost]
        [Route("")]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoryDTO result = _categoryService.Add(categoryDTO);
            _categoryService.SaveCategory();
            return Ok(result);
        }

        // PUT Categories/1
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryDTO.CategoryID)
            {
                return BadRequest();
            }

            if (!_categoryService.CategoryExists(id))
            {
                return NotFound();
            }

            _categoryService.Update(id, categoryDTO);
            _categoryService.SaveCategory();
            CategoryDTO result = _categoryService.GetById(id);
            return Ok(result);
        }

        // DELETE Categories/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_categoryService.CategoryExists(id))
            {
                return NotFound();
            }

            _categoryService.Delete(id);
            _categoryService.SaveCategory();
            return Ok("Category deleted");
        }

    }
}
