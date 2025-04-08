using MelonLoader;

namespace EnhancedExperienceBar;

public class ModMain : MelonMod
{
    public override void OnInitializeMelon()
    {
        var category = MelonPreferences.CreateCategory("EnhancedExperienceBar");

        Global.DisableTicks = category.CreateEntry("DisableTicks", false).Value;
        
        category.SaveToFile(false);
    }
}