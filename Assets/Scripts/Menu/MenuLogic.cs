using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{   
    private void Start()
    {
        //  prevent animator from freezing
        Time.timeScale = 1f;

        AudioHandler.Player.PlayMusic("Menu");
    }

    
}
