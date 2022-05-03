using System.Collections;
using UnityEngine;

/*
 * Base class for enemies
 * - Movement
 * - 
 */
public class EnemyBase : MonoBehaviour
{
    public GameObject deathAnimation;
    public GameObject expOrb;
    public Sprite damageTakenSprite;
    public Sprite normalSprite;

    protected float health = 0;
    protected float damage = 0;
    protected float moveSpeed = 0f;
    protected float armor = 0;
    protected int difficulty;

    protected float attackCooldown = 1f;
    protected int scoreReward;
    protected int expRewardMin;
    protected int expRewardMax;
    protected bool shouldMove;

    protected Transform player;

    private bool attackOnCooldown = false;
    private float minDistance = 1f;
    private float range;

    public virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        shouldMove = true;
    }

    // Update calls once per frame
    public virtual void Update()
    {
        MoveTowards();
    }

    // moves enemy towards player until they are minDistance away
    // rotates enemy to face player
    public void MoveTowards()
    {
        if (shouldMove)
        {
            player = GameObject.FindWithTag("Player").transform;
            range = Vector2.Distance(transform.position, player.position);

            Vector3 diff = player.position - transform.position;
            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            if (range > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    // when enemy collides with player (attacking)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && damage != 0f)
        {
            attackOnCooldown = true;
            collision.gameObject.GetComponent<Hero>().TakeDamage(damage);
            StartCoroutine(AttackCooldown());
        }
    }

    // enemy takes damage
    public void TakeDamage(int check)
    {
        if (check >= (HeroParameters.maxEnemiesHitWithBullet - armor))
        {
            return;
        }
        Debug.Log(health - (HeroParameters.bulletDamage - armor));
        health -= (HeroParameters.bulletDamage - armor);
        print(HeroParameters.bulletDamage - armor);
        if (CheckIfDead())
        {
            HeroParameters.score += scoreReward;
            // HeroParameters.heroExp += Random.Range(expRewardMin, expRewardMax);
            DestroyEnemy();
        }
        StartCoroutine(DamageTaken());
    }

    IEnumerator DamageTaken()
    {
        SwitchToDamageTakenSprite();
        yield return new WaitForSeconds(.05f);
        SwitchToNormalSprite();
    }

    protected void SwitchToDamageTakenSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = damageTakenSprite;
    }

    protected void SwitchToNormalSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    // checks if is dead
    private bool CheckIfDead()
    {
        return (health <= 0);
    }

    // destroys gameObject
    public void DestroyEnemy()
    {
        CreateExpOrb();
        MakeDeathAnimation();
        Destroy(gameObject);
    }

    private void CreateExpOrb()
    {
        GameObject exp = Instantiate(expOrb) as GameObject;
        exp.gameObject.transform.position = transform.position;
        exp.gameObject.GetComponent<ExperienceOrb>().SetExpValue(Random.Range(expRewardMin, expRewardMax));
        Destroy(exp, 15f);
    }

    // does death animation
    private void MakeDeathAnimation()
    {
        GameObject deathAnim = Instantiate(deathAnimation, gameObject.transform.position, Quaternion.identity);
        Destroy(deathAnim, 1f);
    }

    // enemy attack cooldown
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
