using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public SpriteRenderer HeroRenderer;
    public HeroLevelTracker levelTracker;
    public Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HeroParameters.ResetForNextGame();
        HealthBar.maxValue = HeroParameters.heroHealth;
        HealthBar.value = HeroParameters.heroHealth;
        levelTracker.Reset();
        UpdateModel();
    }

    void Update()
    {
        HealthBar.value = HeroParameters.heroHealth;
    }

    public void UpdateModel()
    {
        HeroRenderer.sprite = levelTracker.GetCurrentModel();
    }

    public void TakeDamage(float dmg)
    {
        HeroParameters.heroHealth -= dmg;
        StartCoroutine(DamageTaken());
    }

    IEnumerator DamageTaken()
    {
        SwitchToDamageTakenSprite();
        yield return new WaitForSeconds(.05f);
        SwitchToNormalSprite();
    }

    private void SwitchToDamageTakenSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = levelTracker.GetCurrentModelDamaged();
    }

    private void SwitchToNormalSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = levelTracker.GetCurrentModel();
    }
}
