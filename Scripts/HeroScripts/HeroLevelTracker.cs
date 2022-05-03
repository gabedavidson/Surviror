using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLevelTracker : MonoBehaviour
{
    public Hero Hero;
    public List<Sprite> HeroModels;
    public List<Sprite> HeroModelsDamaged;
    public List<GameObject> BulletPrefabs;

    private Sprite CurrentHeroModel;
    private Sprite CurrentHeroModelDamaged;
    private GameObject CurrentBulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (HeroParameters.heroLevel < HeroParameters.maxHeroLevel)
            {
                UpgradeHeroLevel();
                print("Hero bullet damage: " + HeroParameters.bulletDamage);
            }
        }
    }

    public void UpgradeHeroLevel()
    {
        OnLevelUp();
    }

    public void Reset()
    {
        UpdateModel();
        UpdateBullet();
    }

    private void OnLevelUp()
    {
        HeroParameters.OnLevelUp();
        UpdateBullet();
        UpdateModel();
        Hero.UpdateModel();
    }

    private void UpdateModel()
    {
        CurrentHeroModel = HeroModels[HeroParameters.heroLevel - 1];
    }

    private void UpdateModelDamaged()
    {
        CurrentHeroModelDamaged = HeroModelsDamaged[HeroParameters.heroLevel - 1];
    }

    private void UpdateBullet()
    {
        CurrentBulletPrefab = BulletPrefabs[HeroParameters.heroLevel - 1];
    }

    public GameObject GetCurrentBulletPrefab()
    {
        return CurrentBulletPrefab;
    }

    public Sprite GetCurrentModel()
    {
        return CurrentHeroModel;
    }

    public Sprite GetCurrentModelDamaged()
    {
        return CurrentHeroModelDamaged;
    }
}
