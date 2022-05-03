using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSlider : MonoBehaviour
{
    public Slider slider;
    public Text expText;
    public HeroLevelTracker levelTracker;

    // Start is called before the first frame update
    void Start()
    {
        UpdateExperience();
        slider.maxValue = HeroParameters.expToNextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateExperience();
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (CheckIfShouldLevelUp())
        {
            int remainder = GetRemainderExp();
            HeroParameters.heroExp = remainder;
            HeroParameters.expToNextLevel = HeroParameters.expToNextLevel * HeroParameters.nextLevelExpDegree;
            slider.maxValue = HeroParameters.expToNextLevel;
            slider.value = HeroParameters.heroExp;
            levelTracker.UpgradeHeroLevel();
        }
    }

    private bool CheckIfShouldLevelUp()
    {
        return (slider.value >= HeroParameters.expToNextLevel && HeroParameters.heroLevel != 6);
    }

    private int GetRemainderExp()
    {
        return (HeroParameters.heroExp - HeroParameters.expToNextLevel);
    }

    private void UpdateExperience()
    {
        slider.value = HeroParameters.heroExp;
        expText.text = string.Format("{0}/{1}", HeroParameters.heroExp, HeroParameters.expToNextLevel);
    }
}
