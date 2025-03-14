using HarmonyLib;
using Il2Cpp;

namespace EnhancedExperienceBar.Hooks;

[HarmonyPatch(typeof(UIWindowPanel), nameof(UIWindowPanel.Start))]
public class UIPanelHooks
{
    private static void Postfix(UIWindowPanel __instance)
    {
        if (__instance.name == "Panel_XpBar")
        {
            BarEnhancer.OnExperienceBarReady(__instance);
        }
    }
}