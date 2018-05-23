using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelGenerator : MonoBehaviour {

    public GameObject Tile_Back;
    public GameObject Tile_Wall;
    public GameObject Tile_Start;
    public GameObject Tile_Goal;
    public GameObject Tile_DeathWall;
    public GameObject Tile_BouncePad;
    public GameObject Tile_GravityChanger;
    public GameObject TileHolder;
    
    public void GenerateLevel(string targetLevelName)
    {
        string path = "Assets/Resources/Levels/" + targetLevelName + ".txt";

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);

            //Generating Process
            string line;

            line = reader.ReadLine();
            while (line != null)
            {
                string[] lineArray = line.Split(';');
                GameObject TilePiece = Tile_Wall;

                switch (lineArray[2])
                {
                    case "Tile_Wall": TilePiece = Tile_Wall; break;
                    case "Tile_Back": TilePiece = Tile_Back; break;
                    case "Tile_Start": TilePiece = Tile_Start; break;
                    case "Tile_Goal": TilePiece = Tile_Goal; break;
                    case "Tile_DeathWall": TilePiece = Tile_DeathWall; break;
                    case "Tile_BouncePad": TilePiece = Tile_BouncePad; break;
                    case "Tile_GravityChanger": TilePiece = Tile_GravityChanger; break;
                    default: break;
                }

                GameObject newTile = Instantiate(TilePiece, new Vector3(int.Parse(lineArray[0]), int.Parse(lineArray[1]), 0f), Quaternion.Euler(0f, 0, int.Parse(lineArray[3])));
                newTile.transform.rotation = Quaternion.Euler(0f, 0f, float.Parse(lineArray[3]));
                newTile.transform.parent = TileHolder.transform;
                newTile.name = TilePiece.name;
                line = reader.ReadLine();
            }

            reader.Close();
        } else
        {
            LevelChanger.LoadMenu();
        }
    }

    public void DeleteLevel()
    {
        GameObject.Destroy(GameObject.FindWithTag("Player"));
        GameObject.Destroy(GameObject.FindWithTag("MainCamera"));
        foreach (Transform tile in TileHolder.transform)
        {
            GameObject.Destroy(tile.gameObject);
        }
    }

    public void ReloadLevel()
    {
        DeleteLevel();
        GenerateLevel("Level_" + GameState.CurrentLevel);
    }
}
