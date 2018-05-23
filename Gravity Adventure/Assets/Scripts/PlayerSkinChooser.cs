using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinChooser : MonoBehaviour {
    
    public Image BallImage;
    public Sprite[] BallTextures;

    private SceneDataStorage sceneDataStorage;

    private void Start()
    {
        sceneDataStorage = GameObject.FindWithTag("LevelNameDeliver").GetComponent<SceneDataStorage>();

        ChangeImage();
    }

    public void ChangeImageNumber(bool goNext)
    {
        if(goNext)
        {
            sceneDataStorage.CurrentBallSpriteNumber++;
        }
        else
        {
            sceneDataStorage.CurrentBallSpriteNumber--;
        }

        ChangeImage();
    }

    private void ChangeImage()
    {
        int imageCount = BallTextures.Length;

        if(sceneDataStorage.CurrentBallSpriteNumber > imageCount)
        {
            sceneDataStorage.CurrentBallSpriteNumber = 1;
        }
        else if(sceneDataStorage.CurrentBallSpriteNumber < 1)
        {
            sceneDataStorage.CurrentBallSpriteNumber = imageCount;
        }

        BallImage.sprite = BallTextures[sceneDataStorage.CurrentBallSpriteNumber - 1];
        sceneDataStorage.PlayerBallSprite = BallTextures[sceneDataStorage.CurrentBallSpriteNumber - 1];
    }
}
