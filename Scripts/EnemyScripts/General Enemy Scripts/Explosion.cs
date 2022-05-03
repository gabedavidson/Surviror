using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float damage;

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Hero>().TakeDamage(damage);
        }
    }
}
