using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Spawner> Spawners;
    public List<GameObject> Enemies;

    private int[] spawnOddsByIndex;
    private List<int> roundOdds = new List<int>();
    private float spawnerStartDelay = .5f;

    private bool doNotSpawn = false;

    void Awake()
    {
        spawnOddsByIndex = new int[Enemies.Count];
        // SortEnemiesByDifficulty();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            MakeRoundOdds();
            print("Round spawn odds:");
            foreach (int odd in roundOdds)
            {
                print(odd);
            }
        }
    }

    public bool IsNotSpawning()
    {
        return doNotSpawn;
    }

    private bool CanUpdateSpawnDelay()
    {
        if (!PastRoundOne())
        {
            return false;
        }
        return (GameParameters.spawnerSpawnDelay > GameParameters.spawnerSpawnDelay / (GameParameters.spawnerSpawnDelay - GameParameters.difficulty));
    }

    private bool PastRoundOne()
    {
        return (GameParameters.round >= 2);
    }

    private void UpdateSpawnDelay()
    {
        if (!CanUpdateSpawnDelay())
        {
            return;
        }
        GameParameters.spawnerSpawnDelay -= GameParameters.spawnerSpawnDelay / (GameParameters.spawnerSpawnDelay - GameParameters.difficulty);
    }

    public void StartRound()
    {
        doNotSpawn = false;
        MakeRoundOdds();
        UpdateSpawnDelay();
        StartSpawners();
    }

    private void StartSpawners()
    {
        foreach (Spawner spawner in Spawners)
        {
            StartCoroutine(DoSpawnerStartDelay(spawner));
        }
    }

    public void EndRound()
    {
        doNotSpawn = true;
    }

    IEnumerator DoSpawnerStartDelay(Spawner spawner)
    {
        yield return new WaitForSeconds(spawnerStartDelay);
        StartSpawner(spawner);
    }

    private void StartSpawner(Spawner spawner)
    {
        if (doNotSpawn)
        {
            return;
        }
        spawner.Spawn(GetEnemyToSpawn());
        StartCoroutine(DoSpawnDelay(spawner));
    }

    IEnumerator DoSpawnDelay(Spawner spawner)
    {
        if (doNotSpawn)
        {
            yield break;
        }
        yield return new WaitForSeconds(GameParameters.spawnerSpawnDelay);
        StartSpawner(spawner);
    }

    private GameObject GetEnemyToSpawn()
    {
        return (Enemies[Random.Range(0, roundOdds.Count - 1)]);
    }

    private void MakeRoundOdds()
    {
        int possibleOdds = 0;
        UpdateSpawnOdds();
        roundOdds.Clear();
        foreach (int odd in spawnOddsByIndex)
        {
            possibleOdds += odd;
        }
        for (int i = 0; i < spawnOddsByIndex.Length; ++i)
        {
            for (int j = 0; j < spawnOddsByIndex[i]; ++j)
            {
                roundOdds.Add(i);
                print(i);
            }
        }
    }
    
    private void UpdateSpawnOdds()
    {
        if (!PastRoundOne())
        {
            return;
        }

        if (GameParameters.round <= Enemies.Count)
        {
            WeightWeakSideStep();
        }
        else if (Enemies.Count < GameParameters.round && GameParameters.round <= (Enemies.Count + Mathf.Ceil(Enemies.Count / 2)))
        {
            NormalizeStep();
        }
        else if (GameParameters.round - (Enemies.Count + Mathf.Ceil(Enemies.Count / 2)) <= Enemies.Count){
            WeightStrongSideStep();
        }
        else if (GameParameters.round > Enemies.Count && spawnOddsByIndex[Enemies.Count - 1] != 1)
        {
            StrongSideOddsStep();
        }
    }

    private void WeightWeakSideStep()
    {
        for (int i = 0; i < GameParameters.round; ++i)
        {
            spawnOddsByIndex[i] += 1;
        }
    }

    private void NormalizeStep()
    {
        int normalizeAround = (int)Mathf.Ceil(Enemies.Count / 2);
        for (int i = 0; i < spawnOddsByIndex.Length; ++i)
        {
            if (spawnOddsByIndex[i] > normalizeAround)
            {
                spawnOddsByIndex[i] -= 1;
            }
            else if (spawnOddsByIndex[i] < normalizeAround){
                spawnOddsByIndex[i] += 1;
            }
        }
    }

    private void WeightStrongSideStep()
    {
        for (int i = Enemies.Count - 1; i >= Enemies.Count - (GameParameters.round - (Enemies.Count + Mathf.Ceil(Enemies.Count / 2))); --i)
        {
            spawnOddsByIndex[i] += 1;
        }
    }

    private void StrongSideOddsStep()
    {
        for (int i = 0; i < Enemies.Count; ++i)
        {
            if (spawnOddsByIndex[i] != 0)
            {
                spawnOddsByIndex[i] -= 1;
            }
        }
    }

    private void SortEnemiesByDifficulty()
    {
        int currIndex = 0;
        int[] enemyIndices = new int[Enemies.Count];
        List<EnemyBase> enemies = new List<EnemyBase>();
        foreach (GameObject enem in Enemies)
        {
            enemies.Add(enem.gameObject.GetComponent<EnemyBase>());
        }
        for (int diff = 1; diff < Enemies.Count + 1; ++diff)
        {
            for (int i = 0; i < Enemies.Count; ++i)
            {
                if (enemies[i].GetDifficulty() == diff)
                {
                    enemyIndices[currIndex++] = i;
                }
            }
        }
        List<GameObject> holdEnemies = new List<GameObject>();
        foreach (int index in enemyIndices)
        {
            holdEnemies.Add(Enemies[index]); 
        }
        Enemies = holdEnemies;
    }
}


/*
 * Here is an example for spawn odds with 4 enemies where the number before the colon is the round #:
 * 
    1: 1 0 0 0 (WWSS)
    2: 2 1 0 0 (WWSS)
    3: 3 2 1 0 (WWSS)
    4: 4 3 2 1 (WWSS)
    5: 3 2 2 2 (NS)
    6: 2 2 2 2 (NS)
    7: 2 2 2 3 (WSSS)
    8: 2 2 3 4 (WSSS)
    9: 2 3 4 5 (WSSS)
    10: 3 4 5 6 (WSSS)
    11: 2 3 4 5 (SSOS)
    12: 1 2 3 4 (SSOS)
    13: 0 1 2 3 (SSOS)
    14: 0 0 1 2 (SSOS)
    15: 0 0 0 1 (SSOS)
    16: 0 0 0 1 (None)
    17: 0 0 0 1 (None)
    18: ...
  *
  */