using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProwler : EnemyBase
{
    /*
     * Shoots
     */
    // Start is called before the first frame update
    public override void Start()
    {
        health = 34;
        damage = 4;
        moveSpeed = 1.15f;
        armor = 9f;
        difficulty = 3;

        scoreReward = 3;
        expRewardMin = 11;
        expRewardMax = 15;

        base.Start();
    }
}
