using MelonLoader;

namespace EnhancedExperienceBar;

public class ModMain : MelonMod
{
    public override void OnInitializeMelon()
    {
        var category = MelonPreferences.CreateCategory("EnhancedExperienceBar");

        Global.DisableTicks = category.CreateEntry("DisableTicks", true).Value;
        Global.FontSize = category.CreateEntry("FontSize", 16).Value;
        Global.ShowPercentGain = category.CreateEntry("ShowPercentGain", true).Value;
        Global.ShowXpGain = category.CreateEntry("ShowXpGain", true).Value;
        
        category.SaveToFile(false);
    }
}