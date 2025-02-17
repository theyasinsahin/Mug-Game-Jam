using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
