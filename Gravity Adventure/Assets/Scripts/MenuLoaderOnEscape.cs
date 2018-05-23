using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoaderOnEscape : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.IsCustomLevel = false;
            SceneManager.LoadScene("MainMenu");
        }
	}
}
