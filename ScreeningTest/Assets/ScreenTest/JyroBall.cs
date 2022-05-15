using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JyroBall : MonoBehaviour
{
    public float speed = 1.0f;
    int cnt = 0;
    Rigidbody2D rigi;
    public bool keyboard = false;
    public bool isPlaying = false;
    Vector3 oriPos = new Vector3(-665, 275, 0);
    
    // Start is called before the first frame update
    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    /*
    private void OnDestroy()
    {
        Input.gyro.enabled = false;
    }    */

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            var dire = Vector3.zero;

            dire.x = Input.acceleration.x;
            dire.y = Input.acceleration.y;
            if (keyboard)
            {
                dire.x = Input.GetAxisRaw("Horizontal");
                dire.y = Input.GetAxisRaw("Vertical");
            }


            dire *= Time.deltaTime;
            if (dire == Vector3.zero)
                rigi.velocity = Vector3.zero;
            else
                rigi.AddForce(dire * speed);
            cnt++;
            if (cnt > 100)
            {
                cnt = 0;
            }
        }
    }
    public void ResetPos()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = Vector3.zero;
        this.transform.localPosition = oriPos;
    }
}

