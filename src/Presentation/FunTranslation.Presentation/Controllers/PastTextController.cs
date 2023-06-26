using AutoMapper;
using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FunTranslation.Presentation.Controllers
{
    public class PastTextController : Controller
    {
        private readonly ILanguageService _languageservices;
        private readonly IPastTextService _pastTextservices;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public PastTextController(ILanguageService languageservices, IMapper mapper, UserManager<AppUser> userManager, IPastTextService pastTextservices)
        {
            _languageservices = languageservices;
            _mapper = mapper;
            _userManager = userManager;
            _pastTextservices = pastTextservices;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PastTranslateRequestViewModel? model)
        {
            await FillSelectListItem();

            var query = _pastTextservices.GetPastTranslation(model);
            query = query.OrderByDescending(x => x.CreateDate);

            PastTextViewModel result = new PastTextViewModel
            {
                PastTranslations = query.ToList(),
                UserId = model.UserId,
                LanguageId = model.LanguageId,
            };
            return View(result);
        }

        private async Task FillSelectListItem()
        {
            var result = _userManager.Users.ToList();
            var values = (from x in result.OrderBy(p => p.UserName)
                          select new SelectListItem
                          {
                              Text = x.UserName,
                              Value = x.Id.ToString()
                          }).ToList();
            ViewBag.Users = values;

            var result2 = await _languageservices.GetAll();
            var values2 = (from x in result2.OrderBy(p => p.Name)
                           select new SelectListItem
                           {
                               Text = x.Name,
                               Value = x.Id.ToString()
                           }).ToList();
            ViewBag.Languages = values2;


        }
    }
}
