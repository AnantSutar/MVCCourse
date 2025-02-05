namespace WebApplication1.Model
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{CategoryId=1,Name="Beverage",Description="Beverage"},
            new Category{CategoryId=2,Name="Bakery",Description="Bakery"},
            new Category{CategoryId=3,Name="Meat",Description="Meat"}
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId+1;
            _categories.Add(category);
        }

        public static List<Category> getCategories() { return _categories; }

        public static Category? GetCategorybyId(int? id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                }

                    ;
            return null;
        }


        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
                return;
            
                var categorytoUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
                if (categorytoUpdate != null)
                {
                    categorytoUpdate.Name = category.Name;
                    categorytoUpdate.Description = category.Description;
                }

            
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(category != null)
            {
                _categories.Remove(category);
            }

        }
    }
}
