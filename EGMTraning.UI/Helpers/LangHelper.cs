using EGMTraning.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Html;

namespace EGMTraning.UI.Helpers
{
    public static class LangHelper
    {
        private static ILanguageBusinessEngine _languageBusinessEngine;
        private static IStringResourceBusinessEngine _stringResourceBusinessEngine;

        public static void Test(ILanguageBusinessEngine languageBusinessEngine, IStringResourceBusinessEngine stringResourceBusinessEngine)
        {
            _languageBusinessEngine=languageBusinessEngine;
            _stringResourceBusinessEngine=stringResourceBusinessEngine;
        }

        public static HtmlString Localize(string resourceKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageBusinessEngine.GetLanguageByCulture(currentCulture);
            if (language!=null)
            {
                var stringResource = _stringResourceBusinessEngine.GetStringResource(resourceKey, language.Result.Data.Id);
                if (stringResource==null || string.IsNullOrEmpty(stringResource.Result.Data.Value))
                {
                    return new HtmlString(resourceKey);
                }
                return new HtmlString((args == null || args.Length==0)
                                                    ? stringResource.Result.Data.Value
                                                    : string.Format(stringResource.Result.Data.Value, args));

            }
            return new HtmlString(resourceKey);
        }
    }
}
