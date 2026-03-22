using Plugin.Abstractions;
using Trading.BaseModels;

namespace CustomePreValidationPlugin
{
    public class CustomPostSave : IApiPlugin
    {
        public string Name => "SharesCustomPostSave";
        public int Order => 1; // Execution order
        PluginStage IApiPlugin.Stage => PluginStage.PostSave;

        public Task<PluginResult> ExecuteAsync(PluginContext context)
        {
            var share = context.Request as SharesBaseModel;
            if (share == null)
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Invalid request data to Post Save plugin. Expected SharesBaseModel."
                });
            }

            // Change the saher name
            share.Name += ", Updated in Post same Plugin";

            // If validation passes, continue to the next plugin or core logic
            return Task.FromResult(new PluginResult
            {
                Continue = true
            });
        }
    }
}
