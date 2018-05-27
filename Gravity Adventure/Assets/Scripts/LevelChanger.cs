using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    private SceneDataStorage sceneDataStorage;

    private void Start()
    {
        sceneDataStorage = GameObject.FindWithTag("SceneDataStorage").GetComponent<SceneDataStorage>();
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SwitchScene(string sceneName)
    {
        if(sceneName == "Level")
        {
            GameState.CurrentLevel = 1;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchScene(string sceneName, string newLevelName)
    {
        if (sceneName == "Level")
        {
            GameState.CurrentLevel = 1;
        }
        sceneDataStorage.LevelName = newLevelName;
        GameState.IsCustomLevel = true;
        SceneManager.LoadScene(sceneName);
    }
}
