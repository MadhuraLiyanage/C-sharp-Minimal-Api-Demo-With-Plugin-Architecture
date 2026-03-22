using Plugin.Abstractions;
using Trading.BaseModels;

namespace CustomePreValidationPlugin
{
    public class CustomPreSave: IApiPlugin
    {
        public string Name => "SharesCustomPreSave";
        public int Order => 1; // Execution order
        PluginStage IApiPlugin.Stage => PluginStage.PreSave;

        public Task<PluginResult> ExecuteAsync(PluginContext context)
        {
            var share = context.Request as SharesBaseModel;
            if (share == null)
            {
                return Task.FromResult(new PluginResult
                {
                    Continue = false,
                    Message = "Invalid request data to Pre Save plugin. Expected SharesBaseModel."
                });
            }

            // Change the saher name
            share.Name = "Pre Save Plugin Updated Name";

            // If validation passes, continue to the next plugin or core logic
            return Task.FromResult(new PluginResult
            {
                Continue = true
            });
        }
    }
}
