using EGMTraning.Common.Dtos;

namespace EGMTraning.BusinessEngine.Contracts
{
    public interface ILanguageBusinessEngine
    {
        //    Task<CustomResponseDto<List<LanguageDto>>> GetCustomers();
        //    Task<CustomResponseDto<LanguageDto>> GetCustomerByName(string loginDtoName);
        Task<CustomResponseDto<List<LanguageDto>>> GetLanguages();
        Task<CustomResponseDto<LanguageDto>> GetLanguageByCulture(string culture);
    }
}
