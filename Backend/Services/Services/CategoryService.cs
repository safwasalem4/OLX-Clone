using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryMapper _categoryMapper;
        private readonly ISubCategoryMapper _subCategoryMapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper, ISubCategoryRepository subCategoryRepository, ISubCategoryMapper subCategoryMapper, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._subCategoryRepository = subCategoryRepository;
            this._categoryMapper = categoryMapper;
            this._subCategoryMapper = subCategoryMapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAllCategories();
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = _categoryMapper.MapToDTO(category);
                List<SubCategoryDTO> subCategories = category.SubCategories.Select(subCategory => _subCategoryMapper.MapToDTO(subCategory)).ToList();
                categoryDTO.SubCategories = subCategories;
                categoryDTOs.Add(categoryDTO);
            }

            return categoryDTOs;
        }

        public CategoryDTO GetById(int id)
        {
            Category category = _categoryRepository.GetCategory(id);
            CategoryDTO categoryDTO = _categoryMapper.MapToDTO(category);
            categoryDTO.SubCategories = category.SubCategories.Select(subCategory => _subCategoryMapper.MapToDTO(subCategory)).ToList();

            return categoryDTO;
        }

        public CategoryDTO Add(CategoryDTO categoryDTO)
        {
            Category category = _categoryMapper.MapFromDTO(categoryDTO);
            Category addedCategory = _categoryRepository.Add(category);
            CategoryDTO result = _categoryMapper.MapToDTO(addedCategory);
            return result;
        }

        public void Update(int id, CategoryDTO categoryDTO)
        {
            Category category = _categoryMapper.MapFromDTO(categoryDTO);
            _categoryRepository.Update(id, category);
        }

        public void Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            IEnumerable<SubCategory> subCategories = _subCategoryRepository.GetAllByCategoryId(id);
            foreach (var subCategory in subCategories)
            {
                _subCategoryRepository.Delete(subCategory);
            }
            _categoryRepository.Delete(category);
        }

        public bool CategoryExists(int id)
        {
            return _categoryRepository.IsExist(id);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
