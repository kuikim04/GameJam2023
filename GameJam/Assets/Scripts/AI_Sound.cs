using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sound : MonoBehaviour
{
    float curTime = 0;
    float startingTime = 8;
    private void Start()

    {
        curTime = startingTime;
    }
    // Update is called once per frame
    void Update()
    {
        curTime -= 1 * Time.deltaTime;

        
            if (curTime <= 0)
            {
                SoundManager.Instance.PlayAISound("AI_SOUND");
                curTime = 8;

            }
        
    }
   
    

}
