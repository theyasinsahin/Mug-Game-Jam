using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Voices : MonoBehaviour
{
    private AudioSource audioSource;

    private bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Müziði oynat
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                audioSource.Play();
                isPaused = false;
            }
            else if(isPaused == false)
            {
                audioSource.Pause();
                isPaused = true;
            }
        }
    }
}
