using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LevelEditorUIManager : MonoBehaviour {

    public InputField SaveLevelInput;
    public InputField LoadLevelInput;
    public GameObject levelEditorMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !LoadLevelInput.isFocused && !SaveLevelInput.isFocused)
        {
            OpenAndCloseMenu();
        }
    }

    private void OpenAndCloseMenu()
    {
        if(!levelEditorMenu.activeSelf)
        {
            levelEditorMenu.SetActive(true);
        } else if (levelEditorMenu.activeSelf)
        {
            levelEditorMenu.SetActive(false);
        }
    }
}
