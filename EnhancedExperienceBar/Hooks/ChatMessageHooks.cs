using HarmonyLib;
using Il2Cpp;
using Il2CppPantheonPersist;

namespace EnhancedExperienceBar.Hooks;

[HarmonyPatch(typeof(UIChatWindows), nameof(UIChatWindows.PassMessage), typeof(string), typeof(string), typeof(ChatChannelType))]
public class TestMessage
{
    private static void Prefix(UIChatWindows __instance, string name, ref string message, ChatChannelType channel)
    {
        if (channel == ChatChannelType.Experience &&
            message.EndsWith("some experience.", StringComparison.InvariantCultureIgnoreCase))
        {
            message = message.Replace("some", Global.LastDifference.ToString("N0"));
            if (Global.ShowPercentGain)
            {
                message += $" (+{Global.LastPercentGain:F2}%)";
            }
        }
    }
}