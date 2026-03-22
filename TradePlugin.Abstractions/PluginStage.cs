using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Abstractions;
public enum PluginStage
{
    PreValidation,
    PostValidation,
    PreSave,
    PostSave,
}
