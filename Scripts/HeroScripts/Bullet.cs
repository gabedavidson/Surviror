using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private int enemiesHit = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DealDamage(collision);
            ++enemiesHit;
            if (enemiesHit == HeroParameters.maxEnemiesHitWithBullet)
            {
                MakeDestroyBulletEffect();
            }
        }
        if (collision.gameObject.tag == "Environment")
        {
            MakeDestroyBulletEffect();
        }
    }

    private void DealDamage(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyBase>().TakeDamage(enemiesHit);
    }

    private void MakeDestroyBulletEffect()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
