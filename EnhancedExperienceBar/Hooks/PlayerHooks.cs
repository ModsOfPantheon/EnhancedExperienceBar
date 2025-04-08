using EnhancedExperienceBar.Models;
using HarmonyLib;
using Il2Cpp;

namespace EnhancedExperienceBar.Hooks;

[HarmonyPatch(typeof(EntityPlayerGameObject), nameof(EntityPlayerGameObject.NetworkStart))]
public class PlayerNetworkStart
{
    private static void Postfix(EntityPlayerGameObject __instance)
    {
        // Fired in character select
        if (__instance.NetworkId.Value == 1)
        {
            return;
        }
        
        if (__instance.NetworkId.Value == EntityPlayerGameObject.LocalPlayerId.Value)
        {
            Global.LastKnownPlayerXp = __instance.Experience.Total;
            BarEnhancer.OnLocalPlayerReady(__instance);
        }
    }
}

[HarmonyPatch(typeof(Experience.Logic), nameof(Experience.Logic.SetExperience))]
public class ExperienceSetHook
{
    private static void Postfix(Experience.Logic __instance)
    {
        if (Global.LastKnownPlayerXp == __instance.Total)
        {
            return;
        }
            
        var difference = __instance.Total - Global.LastKnownPlayerXp;
        Global.LastKnownPlayerXp = __instance.Total;
        Global.LastDifference = difference;
        Global.LastPercentGain = MathF.Round(difference / (float)__instance.CalculateExperienceRequiredToNextLevel() * 100, 2);
        
        BarEnhancer.OnExperienceChanged(new PlayerExperience(__instance.Level, __instance.CalculateCurrentExperienceIntoLevel(), __instance.CalculateExperienceRequiredToNextLevel(), __instance.CalculatePercentThroughCurrentLevel()));
    }
}