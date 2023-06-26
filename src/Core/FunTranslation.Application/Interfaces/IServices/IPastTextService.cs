using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IServices
{
    public interface IPastTextService : IGenericService<PastText>
    {
        Task<TranslateViewModel> Translate(TranslateViewModel model);
        IQueryable<PastText> GetPastTranslation(PastTranslateRequestViewModel model);

    }
}
