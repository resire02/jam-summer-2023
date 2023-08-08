using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{   
    public void ResetComponent()
    {
        Reset();
    }

    public virtual void Reset() {}
}
