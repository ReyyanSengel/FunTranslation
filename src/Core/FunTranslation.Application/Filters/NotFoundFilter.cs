using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : BaseEntity
    {
        private readonly IGenericService<TEntity> _genericService;

        public NotFoundFilter(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;
            var anyEntity = await _genericService.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(TEntity).Name}({id}) not found");

            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
