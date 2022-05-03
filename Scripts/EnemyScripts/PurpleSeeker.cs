using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSeeker : EnemyBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 6f;
        damage = 6.5f;
        moveSpeed = 3f;
        armor = -1;
        difficulty = 1;

        attackCooldown = .75f;
        scoreReward = 1;
        expRewardMin = 4;
        expRewardMax = 5;

        base.Start();
    }
}
