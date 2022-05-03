using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBug : EnemyBase
{
    /*
     * Explodes on death
     */
    public override void Start()
    {
        health = 45;
        damage = 4;
        moveSpeed = 1.4f;
        armor = 4f;
        difficulty = 5;

        scoreReward = 5;
        expRewardMin = 16;
        expRewardMax = 21;
        base.Start();
    }
}
