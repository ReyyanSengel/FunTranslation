using AutoMapper;
using FluentValidation.Resources;
using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FunTranslation.Presentation.Controllers
{
    public class TranslationController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IPastTextService _pastTextService;
        private readonly IMapper _mapper;

        public TranslationController(ILanguageService languageService, IPastTextService pastTextService, IMapper mapper)
        {
            _languageService = languageService;
            _pastTextService = pastTextService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TranslateViewModel model = new TranslateViewModel();
            await FillSelectListItem();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TranslateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                await FillSelectListItem();
                return View();
            }
            await FillSelectListItem();

            var addedResult=await _pastTextService.Translate(model);

            var jsonResult=JsonConvert.SerializeObject(addedResult);

            return Json(jsonResult);    
        }


        private async Task FillSelectListItem()
        {
            var result = await _languageService.GetAll();
            var values = (from x in result.OrderBy(p => p.Name)
                          select new SelectListItem
                          {
                              Text = x.Name,
                              Value = x.Id.ToString()
                          }).ToList();

            ViewBag.Languages = values;

        }
    }
}
