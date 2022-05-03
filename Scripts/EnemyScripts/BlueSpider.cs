using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpider : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 22;
        damage = 5;
        moveSpeed = 1.35f;
        armor = 3;
        difficulty = 2;

        scoreReward = 2;
        expRewardMin = 7;
        expRewardMax = 10;

        base.Start();
    }
}
