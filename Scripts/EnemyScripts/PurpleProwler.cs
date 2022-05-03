using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Shoots weapon
 */
public class PurpleProwler : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 50;
        damage = 4;
        moveSpeed = 1.75f;
        armor = 12;
        difficulty = 5;

        scoreReward = 7;
        expRewardMin = 21;
        expRewardMax = 25;

        base.Start();
    }
}
