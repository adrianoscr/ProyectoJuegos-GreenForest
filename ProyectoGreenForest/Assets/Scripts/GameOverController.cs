using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void OnPressRestart()
    {
        LevelManager scene = FindObjectOfType<LevelManager>();

        scene.FirstScene();
    }
}
