using Data.Repositories.Contracts;
using Mapper.Contracts;
using Mapper.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;

namespace WepAPI.Controllers
{
    [Authorize]
    public class SubCategoriesController : APIBaseController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        // GET SubCategories/getByCategoryId/1
        [HttpGet]
        [Route("getByCategoryId/{id}")]
        public IActionResult GetAllByCategoryId(int id)
        {
            if (!_categoryService.CategoryExists(id))
            {
                return NotFound();
            }

            IEnumerable<SubCategoryDTO> result = _subCategoryService.GetAllByCategoryId(id);
            return Ok(result);
        }

        // GET SubCategories/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            SubCategoryDTO subCategoryDTO = _subCategoryService.GetById(id);
            return Ok(subCategoryDTO);

        }

        // POST Subcategories
        [HttpPost]
        [Route("")]
        public IActionResult Add(SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_categoryService.CategoryExists(subCategoryDTO.CategoryID))
            {
                return NotFound();
            }

            SubCategoryDTO result = _subCategoryService.Add(subCategoryDTO);
            _subCategoryService.SaveSubCategory();
            return Ok(result);
        }


        // PUT Subcategories/1
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategoryDTO.SubCategoryID)
            {
                return BadRequest();
            }

            if (!_categoryService.CategoryExists(subCategoryDTO.CategoryID))
            {
                return NotFound();
            }

            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            _subCategoryService.Update(id, subCategoryDTO);
            _subCategoryService.SaveSubCategory();
            SubCategoryDTO result = _subCategoryService.GetById(id);

            return Ok(result);
        }

        // DELETE subcategories/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            _subCategoryService.Delete(id);
            _subCategoryService.SaveSubCategory();
            return Ok("SubCategory deleted");

        }
    }
}
