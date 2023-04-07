using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.DataContracts
{
    public interface IStringResourceRepository : IRepository<StringResource>
    {
        public StringResource GetStringResource(string resourceKey, int languageId);
    }
}
