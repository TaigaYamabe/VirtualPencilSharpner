using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColParticle : MonoBehaviour
{
    // Start is called before the first frame update

    //変数の定義
    private ParticleSystem particle;
    public Rigidbody rb;
    GameObject gb;
    Client client;

    float mag_x;
    float mag_y;
    //float mag_z;

    float mag_ang;

    int old_num;

    void Start()
    {
        //Particleシステムの取得（子オブジェクトから）
        particle = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        gb = GameObject.Find("Client");
        client = gb.GetComponent<Client>();

    }

    // Update is called once per frame
    void Update()
    {
        if (client.num[0] < -900 && client.num[1] - old_num > 5)
        {
            //transform.position += transform.forward * -0.01f;
            particle.Play();
        }
        old_num = client.num[1];
    }
    private void Stop()
    {

    }
    //衝突が発生した場合に実行される
    /*void OnCollisionEnter(Collision collision)
    {
        //衝突対象がPlayer(Ethan)の場合にparticleをPlayする
        if (collision.gameObject.tag == "Player")
            particle.Play();
    }*/
}