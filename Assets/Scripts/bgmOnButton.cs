using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmOnButton : MonoBehaviour
{   
    public AudioSource BackGroundMusic;
    
    void Start()
    {
        BackGroundMusic = GetComponent<AudioSource>();
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!BackGroundMusic.isPlaying)
            {
                BackGroundMusic.Play();
            } else
            
            if (BackGroundMusic.isPlaying)
            {
                BackGroundMusic.Stop();
            }
           
            
        } 
    }

    
}
