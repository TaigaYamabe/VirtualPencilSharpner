using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Client : MonoBehaviour
{
    public static string data;
    public static string resMsg;

    public static int SenserCount = 0;
    public static int[] SenserVal = new int[1024];

    public static int SenserNum = 4;
    public int[] num = new int[SenserNum];

    System.Net.Sockets.NetworkStream ns;
    System.Net.Sockets.TcpClient tcp;

    // Use this for initialization
    void Start()
    {

        //サーバに送信したいデータをぶち込む
        data = "1234567";
        //num = 1234;

        //サーバーのIPアドレスとポート番号
        string ipOrHost = "localhost";
        int port = 12345;

        //TcpClientを作成し、サーバーと接続
        tcp = new System.Net.Sockets.TcpClient(ipOrHost, port);
        Debug.Log("サーバー({0}:{1})と接続しました。" +
            ((System.Net.IPEndPoint)tcp.Client.RemoteEndPoint).Address + "," +
            ((System.Net.IPEndPoint)tcp.Client.RemoteEndPoint).Port + "," +
            ((System.Net.IPEndPoint)tcp.Client.LocalEndPoint).Address + "," +
            ((System.Net.IPEndPoint)tcp.Client.LocalEndPoint).Port);

        //NetworkStreamを取得
        ns = tcp.GetStream();
    }
    // Update is called once per frame
    void Update()
    {
        //↓にC++に送るデータをぶち込む
        //今回は経過時間


        //Debug.Log(goldfish0.moterflag.ToString());
        //data = "1.0000";
        //data = Time.time.ToString();

        //タイムアウト設定
        //ns.ReadTimeout = 10000;
        //ns.WriteTimeout = 10000;

        //サーバーにデータを送信
        //文字列をByte型配列に変換
        System.Text.Encoding enc = System.Text.Encoding.UTF8;
        byte[] sendBytes = enc.GetBytes(data + '\n');
        //データを送信する
        //ns.Write(sendBytes, 0, sendBytes.Length);
        //Debug.Log(data);


        //サーバーから送られたデータを受信する
        //今回は一周期分の時間が送られてくる。
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        byte[] resBytes = new byte[256];
        int resSize = 256;

        //データを受信
        resSize = ns.Read(resBytes, 0, resBytes.Length);
        //受信したデータを蓄積
        ms.Write(resBytes, 0, resSize);
        //受信したデータを文字列に変換
        resMsg = enc.GetString(ms.GetBuffer(), 0, (int)ms.Length);
        ms.Close();
        //末尾の\nを削除
        resMsg = resMsg.TrimEnd('\n');
        //Debug.Log(resMsg);

        //データをセンサの数だけ分割
        string[] str = resMsg.Split(' ');

        for (int i = 0; i < str.Length; i++)
        {
            //int型に変換
            num[i] = int.Parse(str[i]);
            //Debug.Log(num[i]);
        }


        //書き込みを行うセンサー値を取得
        /*
        SenserVal[SenserCount] = num[1];
        Debug.Log(SenserVal[SenserCount]);
        SenserCount += 1;
        */

        //rb.MoveRotation(Quaternion.AngleAxis(45f, Vector3.forward))Debug.Log(num);

        //スペース押すと閉じる
        if (Input.GetKey(KeyCode.Space))
        {
            //センサー値をCSV形式でエクスポート
            //logSave(SenserVal, "Test");

            ns.Close();
            tcp.Close();
            Debug.Log("切断しました。");


        }
    }

}