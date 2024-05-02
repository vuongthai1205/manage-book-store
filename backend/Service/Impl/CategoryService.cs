

using AutoMapper;

namespace backend;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper mapper;

    public CategoryService(ICategoryRepository _categoryRepository, IMapper _mapper)
    {
        categoryRepository = _categoryRepository;
        mapper = _mapper;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        Category category = await categoryRepository.DeleteAsync(id);
        if (category is not null)
        {
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await categoryRepository.GetByIdAsync(id);
    }

    public async Task<Category> InsertCategoryAsync(CategoryRequest category)
    {
        Category category1 = mapper.Map<Category>(category);
        
        return await categoryRepository.AddAsync(category1);
    }

    public async Task<Category> UpdateCategory(int id, CategoryRequest categoryRequest)
    {
        Category category = await categoryRepository.GetByIdAsync(id);
        mapper.Map(categoryRequest, category);
        return await categoryRepository.UpdateAsync(category);
    }
}
