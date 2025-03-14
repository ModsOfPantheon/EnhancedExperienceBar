namespace EnhancedExperienceBar.Models;

public class PlayerExperience
{
    public double Current { get; }
    public double ToNextLevel { get; }
    public double CurrentLevel { get; }
    public float ExperiencePercentage { get; }

    public PlayerExperience(double currentLevel, double current, double toNextLevel, float experiencePercentage)
    {
        Current = current;
        ToNextLevel = toNextLevel;
        ExperiencePercentage = experiencePercentage;
        CurrentLevel = currentLevel;
    }
}