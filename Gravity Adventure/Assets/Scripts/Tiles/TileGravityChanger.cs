using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGravityChanger : MonoBehaviour {

    public GravityChanger GravityChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            int rotation = Mathf.RoundToInt(transform.rotation.eulerAngles.z);

            switch (rotation)
            {
                case 0: GravityChanger.ChangeGravityToUp(); break;
                case 90: GravityChanger.ChangeGravityToLeft(); break;
                case 180: GravityChanger.ChangeGravityToDown(); break;
                case 270: GravityChanger.ChangeGravityToRight(); break;
                default: break;
            }
        }
    }
}