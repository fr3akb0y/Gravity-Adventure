using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataStorage : MonoBehaviour {
    
	public string LevelName = "";
    public Sprite PlayerBallSprite;
    public int CurrentBallSpriteNumber = 1;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public string GetLevelName(bool emptyLevelName)
    {
        string tempLevelName = LevelName;

        if (emptyLevelName)
        {
            LevelName = "";
        }

        return tempLevelName;
    }
}
