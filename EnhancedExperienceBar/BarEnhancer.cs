using EnhancedExperienceBar.Models;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;

namespace EnhancedExperienceBar;

public static class BarEnhancer
{
    private static TextMeshProUGUI? _text;
    
    public static void OnLocalPlayerReady(EntityPlayerGameObject entityPlayerGameObject)
    {
        var exp = entityPlayerGameObject.Experience;
        
        OnExperienceChanged(new PlayerExperience(exp.Level, exp.CalculateCurrentExperienceIntoLevel(), exp.CalculateExperienceRequiredToNextLevel(), exp.CalculatePercentThroughCurrentLevel()));
    }

    public static void OnExperienceBarReady(UIWindowPanel xpWindow)
    {
        var xpWindowRect = xpWindow.GetComponent<RectTransform>();
        xpWindowRect.sizeDelta = new Vector2(xpWindowRect.sizeDelta.x, xpWindowRect.sizeDelta.y + 10);
        
        var textGo = new GameObject("Test");
        textGo.transform.SetParent(xpWindow.transform);
        
        var textComponent = textGo.AddComponent<TextMeshProUGUI>();
        textComponent.text = "0 / 0";
        textComponent.fontSize = 16;
        textComponent.alignment = TextAlignmentOptions.Center;
        
        var textRect = textGo.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(500, 20);
        textRect.anchoredPosition = new Vector2(0, 0);

        _text = textComponent;
    }

    public static void OnExperienceChanged(PlayerExperience playerExperience)
    {
        if (_text == null)
        {
            return;
        }
        
        _text.text = CreateText(playerExperience);
    }
    
    private static string CreateText(PlayerExperience playerExperience)
    {
        return $"{playerExperience.Current:N0} / {playerExperience.ToNextLevel:N0} ({playerExperience.ExperiencePercentage * 100:F}%)";
    }
}