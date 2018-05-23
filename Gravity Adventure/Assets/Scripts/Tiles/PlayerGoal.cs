using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour {

    public LevelChanger LevelChanger;

    private LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = GameObject.Find("LevelManager").GetComponent<LevelGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !GameState.IsCustomLevel)
        {
            GameState.IncreaseLevel();
            levelGenerator.DeleteLevel();
            levelGenerator.GenerateLevel("Level_" + GameState.CurrentLevel);
        }
        else if(GameState.IsCustomLevel)
        {
            GameState.IsCustomLevel = false;
            LevelChanger.SwitchScene("MainMenu");
        }
    }
}
