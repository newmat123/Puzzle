using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{

    public float slowDoenFactor = 0.5f;
    public float slowdownLength = 5f;

    private float timeTo;

    private bool slowMo = false;

    private void Update()
    {

        if (slowMo)
        {

            timeTo += Time.deltaTime;

            if(timeTo > FindObjectOfType<Shop>().SlowmoTime) 
            {

                Time.timeScale += (1f / slowdownLength) * Time.deltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

                if(Time.timeScale == 1)
                {
                    timeTo = 0;
                    slowMo = false;
                }

            }
            
        }
        
    }

    public void DoSlowmotion()
    {
        if(slowMo == false)
        {
            Time.timeScale = slowDoenFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            slowMo = true;
        }

    }
    
}
