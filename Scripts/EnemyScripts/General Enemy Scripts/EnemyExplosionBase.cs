using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionBase : EnemyBase
{
    public GameObject explosionAnimation;

    protected float minDistance;
    protected float explosionTimer;
    protected float explosionRadius; // area of explosion in world units
    protected float explosionDamage;

    public virtual void Start()
    {
        shouldMove = true;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Vector2.Distance(transform.position, player.position) < minDistance)
        {
            shouldMove = false;
            StartExplosion();
        }
    }

    public void StartExplosion()
    {
        StartCoroutine(ExplosionTimer());
    }

    IEnumerator ExplosionTimer()
    {
        StartCoroutine(IndicateExplosion());
        yield return new WaitForSeconds(explosionTimer);
        Explode();
    }

    IEnumerator IndicateExplosion()
    {
        SwitchToDamageTakenSprite();
        yield return new WaitForSeconds(.15f);
        SwitchToNormalSprite();
        yield return new WaitForSeconds(.15f);
    }

    private void Explode()
    {
        GameObject explo = Instantiate(explosionAnimation);
        Destroy(explo, 1f);
        Destroy(gameObject);
    }
}
