using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;

namespace MyAcademyCQRS.CQRSPattern.Validation.CategoryValidation
{
    public class CategoryNameValidator : CategoryValidator
    {
        public override async Task ValidateAsync(CreateCategoryCommand command, AppDbContext context)
        {
            var exists = await context.Categories.AnyAsync(x => x.Name == command.Name);
            if (exists) throw new Exception("Bu kategori ismi zaten mevcut!");

            if (_next != null) await _next.ValidateAsync(command, context);
        }
    }
}