using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class Language
    {
        public Language()
        {
            StringResources = new HashSet<StringResource>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; } = null!;
        public string Culture { get; set; } = null!;

        public virtual ICollection<StringResource> StringResources { get; set; }
    }
}
