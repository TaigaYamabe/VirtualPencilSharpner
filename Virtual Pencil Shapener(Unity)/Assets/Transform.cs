using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour
{
    GameObject gb;
    Client client;
    float trans = 0;
    // Start is called before the first frame update
    void Start()
    {
        gb = GameObject.Find("Client");
        client = gb.GetComponent<Client>();
    }
    // Update is called once per frame
    void Update()
    {
        trans = 81 * client.num[0] / 3500;
        //transform.position = transform.forward * trans;
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.z = trans;
        myTransform.position = pos;
    }
    private void Stop()
    {

    }
}
