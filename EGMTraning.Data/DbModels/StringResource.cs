using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class StringResource
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;
    }
}
