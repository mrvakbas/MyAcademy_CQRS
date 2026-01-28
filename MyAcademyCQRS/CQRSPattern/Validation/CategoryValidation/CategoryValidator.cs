using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;

namespace MyAcademyCQRS.CQRSPattern.Validation.CategoryValidation
{
    public abstract class CategoryValidator
    {
        protected CategoryValidator _next;
        public void SetNext(CategoryValidator next) => _next = next;

        public abstract Task ValidateAsync(CreateCategoryCommand command, AppDbContext context);
    }
}