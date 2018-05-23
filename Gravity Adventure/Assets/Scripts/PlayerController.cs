using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GravityChanger GravityChanger;
    
    private GameObject moveTarget = null;

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            GravityChanger.ChangeGravityToUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            GravityChanger.ChangeGravityToDown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            GravityChanger.ChangeGravityToLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            GravityChanger.ChangeGravityToRight();
        }
    }

    public void SetCameraTarget(GameObject target)
    {
        moveTarget = target;
    }

    private void FixedUpdate()
    {
        if(moveTarget != null)
        {
            transform.position = new Vector3(moveTarget.transform.position.x, moveTarget.transform.position.y, -10);
        }
    }
}
