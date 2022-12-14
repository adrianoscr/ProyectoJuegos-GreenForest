using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public void OnPressStart()
    {
        LevelManager scene = FindObjectOfType<LevelManager>();
        AudioController.instance.PlayAudio(AudioController.instance.playSound);
        scene.NextScene();
    }


    /// <summary>
    /// Salirse del juego
    /// </summary>
    public void OnPressSalir() {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
