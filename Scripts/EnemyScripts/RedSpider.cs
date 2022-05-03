using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpider : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 120;
        damage = 16;
        moveSpeed = 1.2f;
        armor = 15;
        difficulty = 5;

        scoreReward = 6;
        expRewardMin = 21;
        expRewardMax = 29;

        base.Start();
    }
}
