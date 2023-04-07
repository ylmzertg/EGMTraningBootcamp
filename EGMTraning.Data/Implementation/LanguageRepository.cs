using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMTraning.Data.Implementation
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly EmployeeDbContext _ctx;
        public LanguageRepository(EmployeeDbContext context) : base(context)
        {
            _ctx = context;
        }

        public Language GetLanguageByCultureName(string culture)
        {
            return _ctx.Languages.FirstOrDefault(x => x.Culture.ToLower() == culture.ToLower());
        }
    }
}
