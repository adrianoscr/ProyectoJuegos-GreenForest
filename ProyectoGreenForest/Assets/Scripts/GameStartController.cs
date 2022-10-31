using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public void OnPressStart()
    {
        LevelManager scene = FindObjectOfType<LevelManager>();

        scene.NextScene();
    }
}
