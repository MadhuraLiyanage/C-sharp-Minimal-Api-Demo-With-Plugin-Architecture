using Plugin.Abstractions;
using Plugin.Framework;
using Trading.BusinessModels;
using Trading.SharesApi.CoreValidations;

namespace Trading.SharesApi.Services
{
    public class SharesService
    {
        private readonly PluginManager _pluginManager;
        private readonly IServiceProvider _serviceProvider;

        public SharesService(PluginManager pluginManager, IServiceProvider serviceProvider)
        {
            _pluginManager = pluginManager;
            _serviceProvider = serviceProvider;
        }

        public async Task<IResult> CreateShare(SharesModel share, HttpContext httpContext)
        {
            var context = new PluginContext
            {
                HttpContext = httpContext,
                Request = share,
                PluginId = share.PluginId,
                Services = _serviceProvider
            };

            // Execute before validation plugins
            var beforeValidation = await _pluginManager.ExecuteAsync(PluginStage.PreValidation, context);
            if (!beforeValidation.Continue)
            {
                return Results.BadRequest(beforeValidation.Message);
            }

            // Core validation logic
            (var isValid, var validationMessage) = CoreCalidations.Validate(share);
            if (!isValid)
            {
                return Results.BadRequest(validationMessage);
            }

            // Execute after validation plugins
            var afterValidation = await _pluginManager.ExecuteAsync(PluginStage.PostValidation, context);
            if (!afterValidation.Continue)
            {
                return Results.BadRequest(afterValidation.Message);
            }

            // Execute before save plugins
            var beforeSave = await _pluginManager.ExecuteAsync(PluginStage.PreSave, context);
            if (!beforeSave.Continue)
            {
                return Results.BadRequest(beforeSave.Message);
            }

            // Core save logic (e.g., save to database) would go here


            // Execute after save plugins
            var afterSave = await _pluginManager.ExecuteAsync(PluginStage.PostSave, context);
            if (!beforeSave.Continue)
            {
                return Results.BadRequest(beforeSave.Message);
            }

            // Return the created share
            return Results.Ok(share);
        }

    }
}
