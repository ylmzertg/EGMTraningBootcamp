using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Common.Dtos;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;

namespace EGMTraning.BusinessEngine.Implementation
{
    public class StringResourceBusinessEngine : IStringResourceBusinessEngine
    {
        private readonly IUnitOfWork _uow;
        

        public StringResourceBusinessEngine(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CustomResponseDto<StringResourceDto>> GetStringResource(string resourceKey, int languageId)
        {
            var data = _uow.stringResourceRepository.GetStringResource(resourceKey, languageId);
            var returnData = new StringResourceDto();
            if (data!=null)
            {
                //var datas = _mapper.Map<StringResource, StringResourceDto>(data);
                returnData.Value = data.Value;
                returnData.Name = data.Name;
                returnData.LanguageId = data.LanguageId;
                returnData.Id=data.Id;

                return await Task.FromResult(CustomResponseDto<StringResourceDto>.Success(200, returnData));
            }
            return await Task.FromResult(CustomResponseDto<StringResourceDto>.Fail(404, "Data not found"));
        }
    }
}
