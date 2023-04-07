using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Common.Dtos;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMTraning.BusinessEngine.Implementation
{
    public class LanguageBusinessEngine : ILanguageBusinessEngine
    {
        private readonly IUnitOfWork _uow;
        //private readonly ITokenService _tokenService;
        //private IMapper _mapper;

        public LanguageBusinessEngine(IUnitOfWork uow)
        {
            _uow = uow;
            //_tokenService = tokenService;
            //_mapper = mapper;
        }

        public async Task<CustomResponseDto<List<LanguageDto>>> GetLanguages()
        {
            var data = _uow.language.GetAll();
            var returnData = new List<LanguageDto>();
            if (data!=null)
            {
                foreach (var lan in data)
                {
                    returnData.Add(new LanguageDto()
                    {
                        Name = lan.LanguageName,
                        Culture = lan.Culture
                    });
                }
                return await Task.FromResult(CustomResponseDto<List<LanguageDto>>.Success(200, returnData));
            }
            return await Task.FromResult(CustomResponseDto<List<LanguageDto>>.Fail(404, "Data not found"));
        }

        public async Task<CustomResponseDto<LanguageDto>> GetLanguageByCulture(string culture)
        {
            var data = _uow.language.GetLanguageByCultureName(culture);
            var returnData = new LanguageDto();
            if (data!=null)
            {
                //var datas = _mapper.Map<Language, LanguageDto>(data);
                //LanguageDto returnData = new LanguageDto();
                returnData.Culture = data.Culture;
                returnData.Id = data.Id;
                returnData.Name = data.LanguageName;

                return await Task.FromResult(CustomResponseDto<LanguageDto>.Success(200, returnData));
            }
            return await Task.FromResult(CustomResponseDto<LanguageDto>.Fail(404, "Data not found"));
        }
    }
}
