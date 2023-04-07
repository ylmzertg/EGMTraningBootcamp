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
    public class StringResourceRepository : Repository<StringResource>, IStringResourceRepository
    {
        private readonly EmployeeDbContext _db;

        public StringResourceRepository(EmployeeDbContext db)
            : base(db)
        {
            _db = db;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            return _db.StringResources.FirstOrDefault(x =>
                x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
                && x.LanguageId == languageId);
        }
    }
}
