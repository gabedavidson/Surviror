using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void MoveTowards(GameObject enemy, Transform heroTransform)
    {
        enemy.gameObject.transform.position += enemy.gameObject.transform.forward * Time.deltaTime;
        enemy.gameObject.transform.LookAt(heroTransform);
    }
}
