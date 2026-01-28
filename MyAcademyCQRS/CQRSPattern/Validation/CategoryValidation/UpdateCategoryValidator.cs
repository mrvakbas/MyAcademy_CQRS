using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using Microsoft.EntityFrameworkCore;

namespace MyAcademyCQRS.CQRSPattern.Validation.CategoryValidation
{
    public class UpdateCategoryValidator
    {
        public async Task ValidateAsync(UpdateCategoryCommand command, AppDbContext context)
        {
            var exists = await context.Categories
                .AnyAsync(x => x.Name == command.Name && x.Id != command.Id);

            if (exists)
            {
                throw new Exception("Bu kategori ismi başka bir kategori tarafından kullanılıyor!");
            }

            if (string.IsNullOrEmpty(command.Name))
            {
                throw new Exception("Kategori adı boş geçilemez!");
            }
        }
    }
}