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

        //�T�[�o�ɑ��M�������f�[�^���Ԃ�����
        data = "1234567";
        //num = 1234;

        //�T�[�o�[��IP�A�h���X�ƃ|�[�g�ԍ�
        string ipOrHost = "localhost";
        int port = 12345;

        //TcpClient���쐬���A�T�[�o�[�Ɛڑ�
        tcp = new System.Net.Sockets.TcpClient(ipOrHost, port);
        Debug.Log("�T�[�o�[({0}:{1})�Ɛڑ����܂����B" +
            ((System.Net.IPEndPoint)tcp.Client.RemoteEndPoint).Address + "," +
            ((System.Net.IPEndPoint)tcp.Client.RemoteEndPoint).Port + "," +
            ((System.Net.IPEndPoint)tcp.Client.LocalEndPoint).Address + "," +
            ((System.Net.IPEndPoint)tcp.Client.LocalEndPoint).Port);

        //NetworkStream���擾
        ns = tcp.GetStream();
    }
    // Update is called once per frame
    void Update()
    {
        //����C++�ɑ���f�[�^���Ԃ�����
        //����͌o�ߎ���


        //Debug.Log(goldfish0.moterflag.ToString());
        //data = "1.0000";
        //data = Time.time.ToString();

        //�^�C���A�E�g�ݒ�
        //ns.ReadTimeout = 10000;
        //ns.WriteTimeout = 10000;

        //�T�[�o�[�Ƀf�[�^�𑗐M
        //�������Byte�^�z��ɕϊ�
        System.Text.Encoding enc = System.Text.Encoding.UTF8;
        byte[] sendBytes = enc.GetBytes(data + '\n');
        //�f�[�^�𑗐M����
        //ns.Write(sendBytes, 0, sendBytes.Length);
        //Debug.Log(data);


        //�T�[�o�[���瑗��ꂽ�f�[�^����M����
        //����͈�������̎��Ԃ������Ă���B
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        byte[] resBytes = new byte[256];
        int resSize = 256;

        //�f�[�^����M
        resSize = ns.Read(resBytes, 0, resBytes.Length);
        //��M�����f�[�^��~��
        ms.Write(resBytes, 0, resSize);
        //��M�����f�[�^�𕶎���ɕϊ�
        resMsg = enc.GetString(ms.GetBuffer(), 0, (int)ms.Length);
        ms.Close();
        //������\n���폜
        resMsg = resMsg.TrimEnd('\n');
        //Debug.Log(resMsg);

        //�f�[�^���Z���T�̐���������
        string[] str = resMsg.Split(' ');

        for (int i = 0; i < str.Length; i++)
        {
            //int�^�ɕϊ�
            num[i] = int.Parse(str[i]);
            //Debug.Log(num[i]);
        }


        //�������݂��s���Z���T�[�l���擾
        /*
        SenserVal[SenserCount] = num[1];
        Debug.Log(SenserVal[SenserCount]);
        SenserCount += 1;
        */

        //rb.MoveRotation(Quaternion.AngleAxis(45f, Vector3.forward))Debug.Log(num);

        //�X�y�[�X�����ƕ���
        if (Input.GetKey(KeyCode.Space))
        {
            //�Z���T�[�l��CSV�`���ŃG�N�X�|�[�g
            //logSave(SenserVal, "Test");

            ns.Close();
            tcp.Close();
            Debug.Log("�ؒf���܂����B");


        }
    }

}