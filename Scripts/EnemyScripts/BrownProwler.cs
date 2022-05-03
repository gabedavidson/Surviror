using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownProwler : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 30;
        damage = 3;
        moveSpeed = 1.1f;
        armor = 0;
        difficulty = 2;

        attackCooldown = 1.3f;
        scoreReward = 2;
        expRewardMin = 8;
        expRewardMax = 11;

        base.Start();
    }
}
