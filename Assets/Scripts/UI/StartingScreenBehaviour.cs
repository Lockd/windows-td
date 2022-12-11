using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource startingSound;
    bool isTransitionInitialized = false;
    void Update()
    {
        if (Input.anyKeyDown && !isTransitionInitialized)
        {
            isTransitionInitialized = true;
            startingSound.Play();
        }
        if (isTransitionInitialized && !startingSound.isPlaying)
        {
            SceneManager.LoadScene("Main-scene");
        }
    }
}
