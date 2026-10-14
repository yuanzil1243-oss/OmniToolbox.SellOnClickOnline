using Dalamud.Bindings.ImGui;
using OmniToolbox.Common.Module.Abstractions;
using OmniToolbox.Common.Module.Enums;
using OmniToolbox.Common.Module.Models;
using OmniToolbox.Host;

namespace OmniToolbox.SellOnClickOnline;

/// <summary>
/// Modifier-key sell mode host for the online module repository.
/// The game-specific sell dispatch is intentionally isolated until the current ShopSell/RetainerSell ABI is verified.
/// </summary>
public sealed class SellOnClick : ModuleBase
{
    public override ModuleInfo Info { get; } = new()
    {
        Title = "按键出售",
        Description = "在出售界面按住修饰键点击物品进入出售模式。",
        Category = ModuleCategory.Item,
        Author = "yuanzil1243-oss",
        Commands = [new("按键出售开关", "/omni SellOnClick")]
    };

    private SellOnClickConfig config = new();

    public override bool HasSettings => true;

    protected override void OnEnable() => DalamudServices.PluginInterface.UiBuilder.Draw += DrawOverlay;

    protected override void OnDisable() => DalamudServices.PluginInterface.UiBuilder.Draw -= DrawOverlay;

    public override bool DrawSettings()
    {
        var changed = false;
        var enabled = config.Enabled;
        if (ImGui.Checkbox("启用按键出售模式", ref enabled))
        {
            config.Enabled = enabled;
            changed = true;
        }

        ImGui.TextUnformatted("支持 Alt、Ctrl、Shift 及其组合键。仅在出售界面显示状态。");
        return changed;
    }

    private void DrawOverlay()
    {
        if (!IsEnabled || !config.Enabled)
            return;

        var io = ImGui.GetIO();
        var modifierHeld = io.KeyAlt || io.KeyCtrl || io.KeyShift;
        if (!modifierHeld)
            return;

        ImGui.SetNextWindowBgAlpha(0.85f);
        ImGui.Begin("按键出售##SellOnClickStatus", ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoDecoration);
        ImGui.TextUnformatted("出售模式：已按住修饰键");
        ImGui.End();
    }
}

public sealed class SellOnClickConfig
{
    public bool Enabled { get; set; } = true;
}
