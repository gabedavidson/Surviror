using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    private int expValue;
    private float moveSpeed = 4f;

    // Start is called before the first frame update
    void Update()
    {
        MoveTowardsIfWithinRange();
    }

    private void MoveTowardsIfWithinRange()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        if (Vector2.Distance(transform.position, player.position) < 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            
        }
    }

    public void SetExpValue(int value)
    {
        expValue = value;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HeroParameters.heroExp += expValue;
            DestroyExpOrb();
        }
    }

    private void DestroyExpOrb()
    {
        Destroy(gameObject);
    }
}
