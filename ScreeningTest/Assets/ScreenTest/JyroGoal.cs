using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JyroGoal : MonoBehaviour
{
    public ScreenTestController stc;    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
            stc.JyroEnd();
    }
}
