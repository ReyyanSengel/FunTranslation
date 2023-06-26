using AutoMapper;
using FunTranslation.Application.Dtos;
using FunTranslation.Application.Extension;
using FunTranslation.Application.Interfaces.IRepositories;
using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Application.SystemModels;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using FunTranslation.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace FunTranslation.Infrastructure.Services
{
    public class PastTextService : GenericService<PastText>, IPastTextService
    {
        private readonly FunTranslationSystemModel _funTranslationSystemModel;
        private readonly IMapper _mapper;
        private readonly IRestExtension _restExtension;
        private readonly ILanguageRepository _languageRepository;
        private readonly IPastTextRepository _pasttextRepository;

        public PastTextService(IGenericRepository<PastText> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRestExtension restExtension,
            IOptions<FunTranslationSystemModel> options,
            ILanguageRepository languageRepository,
            IPastTextRepository pasttextRepository)
            : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _restExtension = restExtension;
            _funTranslationSystemModel = options.Value;
            _languageRepository = languageRepository;
            _pasttextRepository = pasttextRepository;
        }

        public async Task<TranslateViewModel> Translate(TranslateViewModel model)
        {
            string originalText = HttpUtility.UrlEncode(model.MainText);

            var language = await _languageRepository.GetByIdAsync(model.LanguageId);

            string url=string.Format(_funTranslationSystemModel.LanguageTextUrl,language.Name.ToLower(),originalText);

            string uri=string.Concat(_funTranslationSystemModel.BaseUrl,url);

            var query = await _restExtension.Get(uri);

            if (!query.IsSuccessful)
            {
                var errorString=JsonConvert.DeserializeObject<ErrorDto>(query.Content);
            }
            else
            {
                var translationDto = JsonConvert.DeserializeObject<TranslationDto>(query.Content);

                translationDto.Contents.LanguageId=model.LanguageId;

                var result = await SavePastTranslationed(translationDto);

                return _mapper.Map<TranslateViewModel>(result);
            }
            return null;
        }

        public IQueryable<PastText> GetPastTranslation(PastTranslateRequestViewModel model)
        {
            var result=_pasttextRepository.Query();
            if (!string.IsNullOrEmpty(model?.LanguageId))
            {
                result = result.Where(x => x.LanguageId == Convert.ToInt32(model.LanguageId));
            }
            if (!string.IsNullOrEmpty(model?.UserId))
            {
                result = result.Where(x => x.CreateUserId == Convert.ToInt32(model.UserId));
            }
            return result.Include(x=>x.Language);
        } 

        private async Task<PastText> SavePastTranslationed(TranslationDto model) => await AddAsync(_mapper.Map<PastText>(model.Contents));


    }
}
