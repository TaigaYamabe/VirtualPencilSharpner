using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Rigidbody rb;
    GameObject gb;
    Client client;

    float mag_x;
    float mag_y;
    //float mag_z;

    float mag_ang;

    float now_ang1 = 0;
    float now_ang2 = 0;
    float t;
    public Vector3 kero = new Vector3(1, 1, 1);
    int old_num;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gb = GameObject.Find("Client");
        client = gb.GetComponent<Client>();
        

    }

    // Update is called once per frame
    void Update()
    {
        int k = 0;
        if(client.num[0] > -900)
        {
            k = client.num[0];
        }
        else
        {
            k = -900;
        }
        now_ang1 = -81 * k/3500;
        now_ang2 = -81 * client.num[1] / 3500;

        if (client.num[0] < -900 && client.num[1] > old_num)
        {
            t += (client.num[1] - old_num)*0.000005f;
        }
        old_num = client.num[1];
        kero.z = 1.00f - t;

        //    Vector3 pos = this.gameObject.transform.position;
        //    this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.001f * now_ang1);

        //   rb.MoveRotation(Quaternion.AngleAxis(now_ang1, Vector3.up));
        var pos = this.transform.position;
        var target = new Vector3(pos.x, pos.y, (now_ang1/100)+ t * 0.1548f);
        rb.transform.position = Vector3.Lerp(pos, target, 0.5f);

        gameObject.transform.localScale = kero;
        rb.MoveRotation(Quaternion.AngleAxis(now_ang2, Vector3.forward));

    }

    private void Stop()
    {
        
    }
}
