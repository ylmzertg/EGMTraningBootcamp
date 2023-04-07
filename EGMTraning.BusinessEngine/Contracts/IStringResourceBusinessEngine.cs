using EGMTraning.Common.Dtos;

namespace EGMTraning.BusinessEngine.Contracts
{
    public interface IStringResourceBusinessEngine
    {
        Task<CustomResponseDto<StringResourceDto>> GetStringResource(string resourceKey, int languageId);
    }
}
