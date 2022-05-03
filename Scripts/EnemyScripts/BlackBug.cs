using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBug : EnemyExplosionBase
{
    public override void Start()
    {
        health = 12;
        damage = 0;
        moveSpeed = 2.1f;
        armor = 0;
        difficulty = 2;

        scoreReward = 2;
        expRewardMin = 6;
        expRewardMax = 9;

        minDistance = 0.5f;
        explosionTimer = 1f;
        explosionRadius = 1.5f;
        explosionDamage = 25f;
        base.Start();
    }
}
