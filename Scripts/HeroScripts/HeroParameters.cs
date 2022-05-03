using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroParameters
{
    // hero
    public static int heroLevel = 1;
    public static int heroExp = 0;
    public static int expToNextLevel = 100;
    public static int nextLevelExpDegree = 2;
    public static int score = 0;
    public static int maxHeroLevel = 6;
    public static float heroMoveSpeed = 4f;
    public static float heroHealth = 100f;
    public static int livesRemaining = 3;
    public static Transform heroTransform;

    // bullet
    public static float bulletSpeed = 15f;
    public static int maxEnemiesHitWithBullet = 1;
    public static int maxEnemiesHitWithBulletMax = 3;
    public static float bulletDamage = 6f;
    public static float bulletDamageStep = 1.5f;
    public static float bulletCooldown = 1f;
    public static float bulletCooldownReduction = 0.157f;

    public static void ResetForNextLife()
    {
        heroHealth = 100;
        livesRemaining -= 1;
    }

    public static void ResetForNextGame()
    {
        heroLevel = 1;
        heroHealth = 100;
        livesRemaining = 3;
        score = 0;
        heroExp = 0;

        maxEnemiesHitWithBullet = 1;
        bulletDamage = 5;
        bulletCooldown = 1f;
    }

    public static void OnLevelUp()
    {
        ++heroLevel;
        heroHealth = 100;
        bulletDamage = bulletDamage * bulletDamageStep;
        bulletCooldown -= bulletCooldownReduction;
        if (maxEnemiesHitWithBullet < maxEnemiesHitWithBulletMax)
        {
            ++maxEnemiesHitWithBullet;
        }
    }
}
