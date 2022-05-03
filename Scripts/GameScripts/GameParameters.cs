using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Parameters concerning game state
 */
public static class GameParameters
{
    public static int currentScore = 0;
    public static float timeOnClock = 0;
    public static int round = 1;

    public static int difficulty;
    public static float spawnerSpawnDelay = 21f;
    private static float defaultSpawnerSpawnDelay = 21f;

    public static GameStateType gameState;
    private static GameStateType defaultGameState = GameStateType.StartingSoon;
    public static float timePerRound = 5; // seconds per round
    public static float timeBetweenRounds = 5;

    public static void Reset()
    {
        currentScore = 0;
        timeOnClock = 0f;
        round = 1;
        SetupGameParameters();
    }

    public static void SetupGameParameters()
    {
        difficulty = 1;
        spawnerSpawnDelay = defaultSpawnerSpawnDelay;
        gameState = defaultGameState;
    }

    public static void SetupGameParameters(int dif)
    {
        difficulty = dif;
        spawnerSpawnDelay = defaultSpawnerSpawnDelay;
        gameState = defaultGameState;
    }
}
