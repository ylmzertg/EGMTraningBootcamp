using EGMTraning.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILanguageBusinessEngine _languageService;
        private readonly IStringResourceBusinessEngine _localizationService;

        public BaseController(ILanguageBusinessEngine languageService, IStringResourceBusinessEngine localizationService)
        {
            _languageService = languageService;
            _localizationService = localizationService;
        }

        public HtmlString Localize(string resourceKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = _localizationService.GetStringResource(resourceKey, language.Result.Data.Id);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.Result.Data.Value))
                {
                    return new HtmlString(resourceKey);
                }

                return new HtmlString((args == null || args.Length == 0)
                    ? stringResource.Result.Data.Value
                    : string.Format(stringResource.Result.Data.Value, args));
            }

            return new HtmlString(resourceKey);
        }
    }
}
