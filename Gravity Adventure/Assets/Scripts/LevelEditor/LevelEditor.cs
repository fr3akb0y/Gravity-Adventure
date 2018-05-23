using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LevelEditor : MonoBehaviour {
    
    public Camera PlayerCam;
    public float CamMoveSpeed;
    public GameObject TileHolder;
    public InputField SaveLevelInput;
    public InputField LoadLevelInput;
    public Text SaveLevelNameText;
    public Text LoadLevelNameText;
    public Text SaveProgressText;
    public LevelGenerator LevelGenerator;

    private GameObject currentTile;
    private Vector3 mousePos = new Vector3(0f, 0f, 0f);
    private bool camWasMoving = false;

    private void Update()
    {
        //All Interactions in the Level Editor
        if (currentTile != null)
        {
            Vector3 mouseWorldPos = GetMouseToWorldPos();
            currentTile.transform.position = new Vector3(Mathf.Round(mouseWorldPos.x), Mathf.Round(mouseWorldPos.y), 0f);
            
            if (Input.GetMouseButtonDown(0) && !LoadLevelInput.isFocused && !SaveLevelInput.isFocused)
            {
                PlaceTile();
            }

            if(Input.GetKeyDown(KeyCode.Q) && !LoadLevelInput.isFocused && !SaveLevelInput.isFocused)
            {
                GameObject.Destroy(currentTile);
                currentTile = null;
            }

            if (Input.GetKeyDown(KeyCode.R) && !LoadLevelInput.isFocused && !SaveLevelInput.isFocused)
            {
                currentTile.transform.Rotate(new Vector3( 0, 0, -90));
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && PlayerCam.GetComponent<Camera>().orthographicSize > 5) //forward
        {
            PlayerCam.GetComponent<Camera>().orthographicSize -= 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && PlayerCam.GetComponent<Camera>().orthographicSize < 25) //backwards
        {
            PlayerCam.GetComponent<Camera>().orthographicSize += 1;
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (!camWasMoving)
            {
                RemoveTile();
            }
            camWasMoving = false;
        }

        if(Input.GetMouseButton(1))
        {
            MoveScreenWithMouse();
        }
    }

    public void GetNewTile(GameObject newTile)
    {
        if(currentTile != null)
        {
            GameObject.Destroy(currentTile);
        }
        currentTile = Instantiate(newTile, transform.position, Quaternion.identity);
        currentTile.name = newTile.name;
    }

    private void PlaceTile()
    {
        float tileRotation = currentTile.transform.rotation.eulerAngles.z;
        int childLength = TileHolder.transform.childCount;
        bool placeable = true;

        for(int i = 0; i < childLength; i++)
        {
            if(TileHolder.transform.GetChild(i).position == currentTile.transform.position)
            {
                placeable = false;
            }
        }

        if(placeable)
        {
            GameObject newTile = Instantiate(currentTile, currentTile.transform.position, Quaternion.Euler(0, 0, tileRotation));
            newTile.transform.rotation = Quaternion.Euler(0f, 0f, tileRotation);
            newTile.transform.parent = TileHolder.transform;
            newTile.name = currentTile.name;
        }
    }

    private Vector3 GetMouseToWorldPos()
    {
        mousePos.y = Input.mousePosition.y;
        mousePos.x = Input.mousePosition.x;
        mousePos.z = 0f;
        Vector3 mouseWorldPos = PlayerCam.ScreenToWorldPoint(mousePos);
        return mouseWorldPos;
    }

    private void RemoveTile()
    {
        int childLength = TileHolder.transform.childCount;
        GameObject removeObject = null;
        Vector3 mouseWorldPos = GetMouseToWorldPos();

        for (int i = 0; i < childLength; i++)
        {
            if (TileHolder.transform.GetChild(i).position == new Vector3(Mathf.Round(mouseWorldPos.x), Mathf.Round(mouseWorldPos.y), 0f))
            {
                removeObject = TileHolder.transform.GetChild(i).gameObject;
            }
        }

        if (removeObject != null)
        {
            GameObject.Destroy(removeObject);
        }
    }

    public void SaveLevel()
    {
        if (SaveLevelNameText.text != null)
        {
            string path = "Assets/Resources/Levels/" + SaveLevelNameText.text + ".txt";
            string[] tileData = new string[TileHolder.transform.childCount];
            int childLength = TileHolder.transform.childCount;

            for (int i = 0; i < childLength; i++)
            {
                Transform singleChild = TileHolder.transform.GetChild(i);
                tileData[i] = singleChild.position.x.ToString() + ";" + singleChild.position.y.ToString() + ";" + singleChild.name + ";" + singleChild.rotation.eulerAngles.z;
            }

            File.WriteAllLines(path, tileData);
            SaveProgressText.text = "Saving...";

            while(!File.Exists(path))
            {
                StartCoroutine(WaitUntilSaveFinished(1));
            }

            SaveProgressText.text = "Finished Saving";
            StartCoroutine(WaitUntilSaveFinished(5));
            SaveProgressText.text = "";
        }
    }

    public void LoadLevel()
    {
        if (LoadLevelNameText.text != null && File.Exists("Assets/Resources/Levels/" + LoadLevelNameText.text + ".txt"))
        {
            LevelGenerator.DeleteLevel();
            LevelGenerator.GenerateLevel(LoadLevelNameText.text);
        }
    }

    public void MoveScreenWithMouse()
    {
        float mouseX = -Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        if (mouseX > 0 || mouseY > 0)
        {
            camWasMoving = true;
        }
        
        PlayerCam.transform.position = new Vector3(PlayerCam.transform.position.x + (mouseX * CamMoveSpeed * Time.deltaTime), PlayerCam.transform.position.y + (mouseY * CamMoveSpeed * Time.deltaTime), -10f);
    }

    private IEnumerator WaitUntilSaveFinished(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
