using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroSensor : MonoBehaviour
{
    public Text ew;
    public Text sn;
    public float speed = 1.0f;
    int cnt = 0;
    Rigidbody2D rigi;
    public bool keyboard = false;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();

    }
    private void OnDestroy()
    {
        Input.gyro.enabled = false;
    }

    // Update is called once per frame
    void Update()
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
            ew.text = dire.x.ToString();
            sn.text = dire.y.ToString();
            cnt = 0;
        }
    }
}

