using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour {

    public GameObject PlayerSpherePrefab;
    public GameObject PlayerCam;

    private SceneDataStorage sceneDataStorage;

    void Start () {
        sceneDataStorage = GameObject.FindWithTag("SceneDataStorage").GetComponent<SceneDataStorage>();

        GameObject newBall = Instantiate(PlayerSpherePrefab, transform.position, Quaternion.identity);
        GameObject newCam = Instantiate(PlayerCam, transform.position, Quaternion.identity);
        newCam.GetComponent<PlayerController>().SetCameraTarget(newBall);
        newBall.GetComponent<SpriteRenderer>().sprite = sceneDataStorage.PlayerBallSprite;
    }
}