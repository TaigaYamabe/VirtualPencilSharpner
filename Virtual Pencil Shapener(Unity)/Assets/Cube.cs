using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
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
    int s = 0;
    float t = 0;
    float m = 0;
    

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
        if (client.num[0] > -900)
        {
            k = client.num[0];
        }
        else
        {
            k = -900;
        }
        now_ang1 = -81 * k / 3500;
        now_ang2 = -81 * client.num[1] / 3500;

        if(client.num[0] < -900 && client.num[1] > s)
        {
            t -= 0.0003f;
        }


        m = (now_ang1 / 100) - 0.63f - t;

        s = client.num[1];
        //    Vector3 pos = this.gameObject.transform.position;
        //    this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.001f * now_ang1);

        //   rb.MoveRotation(Quaternion.AngleAxis(now_ang1, Vector3.up));
        var pos = this.transform.position;
        var target = new Vector3(pos.x, pos.y, m);
        rb.transform.position = Vector3.Lerp(pos, target, 0.5f);

        rb.MoveRotation(Quaternion.AngleAxis(now_ang2, Vector3.forward));

    }

    private void Stop()
    {

    }
}
