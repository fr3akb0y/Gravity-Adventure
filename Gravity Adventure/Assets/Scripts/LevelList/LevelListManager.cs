using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LevelListManager : MonoBehaviour {

    public GameObject ButtonPrefab;
    public Transform LevelListParent;

    private void Start()
    {
        GenerateLevelButtons();
    }

    public void GenerateLevelButtons()
    {
        string path = Application.dataPath + "/Resources/Levels/";
        DirectoryInfo info = new DirectoryInfo(path);
        FileInfo[] fileInfo = info.GetFiles("*.txt");
        
        foreach(FileInfo singleInfo in fileInfo)
        {
            CreateNewButtonForLevel(Path.GetFileNameWithoutExtension(singleInfo.Name));
        }
    }

    public void CreateNewButtonForLevel(string levelName)
    {
        GameObject newButton = Instantiate(ButtonPrefab, LevelListParent);
        newButton.GetComponentInChildren<Text>().text = levelName;
        LevelChanger newLevelChanger = newButton.AddComponent<LevelChanger>();
        newButton.GetComponent<Button>().onClick.AddListener(delegate { newLevelChanger.SwitchScene("Level", levelName); });
    }
}
