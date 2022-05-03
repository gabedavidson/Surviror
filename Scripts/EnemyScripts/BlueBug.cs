using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Explodes when it dies
 */
public class BlueBug : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 30;
        damage = 3;
        moveSpeed = 1.9f;
        armor = 2;
        difficulty = 4;

        scoreReward = 3;
        expRewardMin = 9;
        expRewardMax = 15;

        base.Start();
    }
}
