using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWorm : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 5;
        damage = 5;
        moveSpeed = 1.5f;
        armor = -1;
        difficulty = 1;

        scoreReward = 1;
        expRewardMin = 4;
        expRewardMax = 5;

        base.Start();
    }
}
