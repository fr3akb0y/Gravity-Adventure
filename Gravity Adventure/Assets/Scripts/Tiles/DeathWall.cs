using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

    public LevelChanger LevelChanger;

    private LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = GameObject.Find("LevelManager").GetComponent<LevelGenerator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (!GameState.IsCustomLevel)
            {
                levelGenerator.ReloadLevel();
            }
            else
            {
                LevelChanger.SwitchScene("MainMenu");
            }
        }
    }
}
