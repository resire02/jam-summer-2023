using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    private AudioHandler request;
    
    private void Start()
    {
        //  prevent animator from freezing
        Time.timeScale = 1f;

        request = GetComponent<AudioHandler>();
        
        request.PlaySound("Menu", true);
    }

    
}
