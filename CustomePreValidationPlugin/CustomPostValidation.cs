using Plugin.Abstractions;
using Trading.BaseModels;

namespace CustomePreValidationPlugin
{
    public class CustomPostValidation: IApiPlugin
    {
        public string Name => "SharesCustomPostValidation";
        public int Order => 1; // Execution order
        PluginStage IApiPlugin.Stage => PluginStage.PostValidation;

        public Task<PluginResult> ExecuteAsync(PluginContext context)
        {
            var share = context.Request as SharesBaseModel;
            if (share == null)
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Invalid request data to Post valiadtion plugin. Expected SharesBaseModel."
                });
            }

            // If the share name equeal to "Not Allowed", return an error message and stop further processing
            if (share.Name == "Not Allowed")
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Share name cannot me 'Not Allowed'."
                });
            }

            // If validation passes, continue to the next plugin or core logic
            return Task.FromResult(new PluginResult
            {
                Continue = true
            });

        }
    }
}
