using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlying : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        Time.timeScale = 0f;
        canvas.enabled = true;

    }



    public void StartFlyingNow()
    {
        Time.timeScale = 1f;
        canvas.enabled = false;
    }
}
