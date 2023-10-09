using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrans : MonoBehaviour
{
    GameObject gb;
    Client client;
    //float trans = 0;
    // Start is called before the first frame update
    void Start()
    {
        gb = GameObject.Find("Client");
        client = gb.GetComponent<Client>();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.forward * trans;
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        // pos.z = client.num[0] / 10000;
        pos.z = 0.1f;
        myTransform.position = pos;
    }
    private void Stop()
    {

    }
}
