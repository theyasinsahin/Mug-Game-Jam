using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesacmakapama : MonoBehaviour
{


    public AudioSource theme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusic(bool isMusic)
    {
        theme.mute = !isMusic;
    }
}
