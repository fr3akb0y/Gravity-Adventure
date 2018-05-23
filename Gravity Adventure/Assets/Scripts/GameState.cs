using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static int CurrentLevel = 1;
    public static bool IsCustomLevel = false;

    public static void IncreaseLevel()
    {
        CurrentLevel++;
    }

    public static void ResetLevel()
    {
        CurrentLevel = 1;
    }
}
