using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private float slowMotionTimeScale = 0.1f;
    private float _startTimeScale;
    private float _startFixedDeltaTime;
    

    void Start()
    {
        _startTimeScale = Time.timeScale;
        _startFixedDeltaTime = Time.fixedDeltaTime;
        
    }

    
    void Update()
    {
      SlowMotionInput();
    }

    public void SlowMotionInput()
    {
        if(Input.GetKey(KeyCode.R))
        {
            StartSlowMotion();
        }
        else
        {
            StopSlowMotion();
        }
    }
    
    public void StartSlowMotion()
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime * slowMotionTimeScale;
    }
    public void StopSlowMotion()
    {
        Time.timeScale =_startTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime;
        
    }
}
