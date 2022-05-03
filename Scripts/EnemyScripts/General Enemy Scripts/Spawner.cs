using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 spawnLocation; // location of spawner

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.position;
    }

    public void Spawn(GameObject enemy)
    {
        Instantiate(enemy, spawnLocation, transform.rotation);
    }
}
