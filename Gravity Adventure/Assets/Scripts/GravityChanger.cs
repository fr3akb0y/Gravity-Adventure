using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    private void Start()
    {
        ChangeGravityToDown();
    }

    public void ChangeGravityToDown()
    {
        Physics2D.gravity = new Vector3(0, -10, 0);
    }

    public void ChangeGravityToUp()
    {
        Physics2D.gravity = new Vector3(0, 10, 0);
    }

    public void ChangeGravityToLeft()
    {
        Physics2D.gravity = new Vector3(-10, 0, 0);
    }

    public void ChangeGravityToRight()
    {
        Physics2D.gravity = new Vector3(10, 0, 0);
    }
}
