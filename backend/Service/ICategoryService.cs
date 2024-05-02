namespace backend;

public interface ICategoryService
{
    Task<Category> InsertCategoryAsync(CategoryRequest category);
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> UpdateCategory(int id, CategoryRequest category);
    Task<bool> DeleteCategory(int id);
}
