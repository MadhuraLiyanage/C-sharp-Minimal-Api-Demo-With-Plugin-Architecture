using Plugin.Abstractions;
using Trading.BaseModels;

namespace CustomePreValidationPlugin
{
    public class CustomPreValidation: IApiPlugin
    {
        public string Name => "SharesCustomPreValidation";
        public int Order => 1; // Execution order
        PluginStage IApiPlugin.Stage => PluginStage.PreValidation;

        public Task<PluginResult> ExecuteAsync(PluginContext context)
        {
            var share = context.Request as SharesBaseModel;
            if (share == null)
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Invalid request data to Pre valiadtion plugin. Expected SharesBaseModel."
                });
            }

            // If the share name is empty, return an error message and stop further processing
            if (share.Name.IsNullOrEmpty())
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Share name cannot be empty."
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
