using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public LevelGenerator levelGenerator;

    private SceneDataStorage sceneDataStorage;

	void Start () {
        sceneDataStorage = GameObject.FindWithTag("LevelNameDeliver").GetComponent<SceneDataStorage>();
        string levelName = sceneDataStorage.GetLevelName(true);

        if(levelName != "")
        {
            levelGenerator.GenerateLevel(levelName);
        }
        else
        {
            levelGenerator.GenerateLevel("Level_" + GameState.CurrentLevel);
        }
    }
}
