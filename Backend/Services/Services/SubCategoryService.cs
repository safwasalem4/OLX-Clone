using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ISubCategoryMapper _subCategoryMapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, ISubCategoryMapper subCategoryMapper, IUnitOfWork unitOfWork)
        {
            _subCategoryRepository = subCategoryRepository;
            _subCategoryMapper = subCategoryMapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SubCategoryDTO> GetAllByCategoryId(int categoryId)
        {
            IEnumerable<SubCategory> subCategories = _subCategoryRepository.GetAllByCategoryId(categoryId);
            IEnumerable<SubCategoryDTO> subCategoriesDTO = subCategories.Select(x => _subCategoryMapper.MapToDTO(x));
            return subCategoriesDTO;
        }

        public SubCategoryDTO GetById(int id)
        {
            SubCategory subCategory = _subCategoryRepository.GetById(id);
            SubCategoryDTO subCategoryDTO = _subCategoryMapper.MapToDTO(subCategory);
            return subCategoryDTO;
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _subCategoryRepository.GetById(id);
        }
        public SubCategoryDTO Add(SubCategoryDTO subCategoryDTO)
        {
            SubCategory subCategory = _subCategoryMapper.MapFromDTO(subCategoryDTO);
            SubCategory addedSubCategory = _subCategoryRepository.Add(subCategory);
            SubCategoryDTO addedSubCategoryDTO = _subCategoryMapper.MapToDTO(addedSubCategory);
            return addedSubCategoryDTO;
        }

        public void Update(int id, SubCategoryDTO subCategoryDTO)
        {
            SubCategory subCategory = _subCategoryMapper.MapFromDTO(subCategoryDTO);
            _subCategoryRepository.Update(id, subCategory);
        }

        public void Delete(int id)
        {
            SubCategory subCategory = _subCategoryRepository.GetById(id);
            _subCategoryRepository.Delete(subCategory);
        }

        public bool SubCategoryExists(int id)
        {
            SubCategory subCategory = _subCategoryRepository.GetById(id);
            return subCategory != null;
        }

        public void SaveSubCategory()
        {
            _unitOfWork.Commit();
        }
    }
}
