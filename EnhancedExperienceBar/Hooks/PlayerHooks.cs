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
            BarEnhancer.OnLocalPlayerReady(__instance);
        }
    }
}

[HarmonyPatch(typeof(Experience.Logic), nameof(Experience.Logic.SetExperience))]
public class ExperienceSetHook
{
    private static void Postfix(Experience.Logic __instance)
    {
        BarEnhancer.OnExperienceChanged(new PlayerExperience(__instance.Level, __instance.CalculateCurrentExperienceIntoLevel(), __instance.CalculateExperienceRequiredToNextLevel(), __instance.CalculatePercentThroughCurrentLevel()));
    }
}