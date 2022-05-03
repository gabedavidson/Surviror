    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStateType
{
    StartingSoon,
    Round
}

public class GameState : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    public Text gameStateText;

    public SpawnManager Spawners;

    private const string startingSoon = "Starting Soon...";
    private const string round = "Round";

    // Start is called before the first frame update
    void Start()
    {
        GameParameters.timeOnClock = GameParameters.timeBetweenRounds;
        GameParameters.currentScore = 0;
        GameParameters.gameState = GameStateType.StartingSoon;
        DisplayGameState();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClock();
        UpdateScore();
        ManageSpawners();
    }

    private void ManageSpawners()
    {
        if (ShouldStartSpawners())
        {
            Spawners.StartRound();
        }
        if (ShouldStopSpawners())
        {
            Spawners.EndRound();
        }
    }

    private bool ShouldStartSpawners()
    {
        return GameParameters.gameState == GameStateType.Round && Spawners.IsNotSpawning();
    }

    private bool ShouldStopSpawners()
    {
        return GameParameters.gameState == GameStateType.StartingSoon && !Spawners.IsNotSpawning();
    }

    private void DisplayGameState()
    {
        if (GameParameters.gameState == GameStateType.StartingSoon)
        {
            gameStateText.text = startingSoon;
        }
        else if (GameParameters.gameState == GameStateType.Round)
        {
            string roundDisplayText = round + " " + System.Convert.ToString(GameParameters.round);
            gameStateText.text = roundDisplayText;
        }
    }

    private void UpdateScore()
    {
        DisplayScore(HeroParameters.score);
    }

    private void DisplayScore(int score)
    {
        string s = "Score: " + System.Convert.ToString(score);
        scoreText.text = s;
    }

    private void UpdateClock()
    {
        if (GameParameters.timeOnClock > 0)
        {
            GameParameters.timeOnClock -= Time.deltaTime;
        }
        else
        {
            GameParameters.timeOnClock = 0;
            SwitchClockTimer();
        }
        DisplayTime(GameParameters.timeOnClock);
    }

    private void SwitchClockTimer()
    {
        GetGameState();
        if (GameParameters.gameState == GameStateType.StartingSoon){
            GameParameters.timeOnClock = GameParameters.timeBetweenRounds;
        }
        else if (GameParameters.gameState == GameStateType.Round)
        {
            GameParameters.timeOnClock = GameParameters.timePerRound;
        }
    }

    private void DisplayTime(float time)
    {
        if (time < 0)
        {
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GetGameState()
    {
        if (GameParameters.gameState == GameStateType.StartingSoon)
        {
            GameParameters.gameState = GameStateType.Round;
        }
        else if (GameParameters.gameState == GameStateType.Round)
        {
            GameParameters.round += 1;
            GameParameters.gameState = GameStateType.StartingSoon;
        }
        DisplayGameState();
    }
}
