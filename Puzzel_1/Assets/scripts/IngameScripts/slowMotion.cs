using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{

    public float slowDoenFactor = 1f;
    public float slowdownLength = 2f;

    public void DoSlowmotion()
    {

        Time.timeScale = slowDoenFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

    }
    
}
