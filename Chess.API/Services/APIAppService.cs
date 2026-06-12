using Volo.Abp.Application.Services;
using Chess.API.Localization;

namespace Chess.API.Services;

/* Inherit your application services from this class. */
public abstract class APIAppService : ApplicationService
{
    protected APIAppService()
    {
        LocalizationResource = typeof(APIResource);
    }
}