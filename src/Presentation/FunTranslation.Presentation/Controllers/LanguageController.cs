using AutoMapper;
using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FunTranslation.Presentation.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        private readonly IMapper _mapper;
        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result =await _languageService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateViewModel model)
        {
            await _languageService.AddAsync(_mapper.Map<Language>(model));

            return RedirectToAction("Index", "Language");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updated = await _languageService.GetByIdAsync(id);
            return View(_mapper.Map<LanguageUpdateViewModel>(updated));
        }

        [HttpPost]
        public IActionResult Update(LanguageUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var result = _languageService.Update(_mapper.Map<Language>(model));

            if (result!= null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
           var deleted=await _languageService.GetByIdAsync(id);
            _languageService.Remove(deleted);
            return RedirectToAction(nameof(Index));
        }


    }
}
