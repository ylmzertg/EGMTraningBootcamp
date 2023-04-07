using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.DataContracts
{
    public  interface ILanguageRepository:IRepository<Language>
    {
        public Language GetLanguageByCultureName(string culture);
    }
}
