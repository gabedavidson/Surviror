using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpider : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 35;
        damage = 6;
        moveSpeed = 1.7f;
        armor = 4;
        difficulty = 4;

        attackCooldown = .7f;
        scoreReward = 4;
        expRewardMin = 15;
        expRewardMax = 17;

        base.Start();
    }
}
