using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class cam1script : MonoBehaviour
{
    MeshRenderer mr;
    Texture2D tex;

    void Start()
    {
        mr = GameObject.Find("cam1").GetComponent<MeshRenderer>();
        tex = new Texture2D(100, 100, TextureFormat.RGBA32, false);
    }
    int start = 0;
    private void OnMouseDown()
    {
        start += 1;
    }
    void FixedUpdate()
    {
        
        if (start%2==1)
        {
            SetImage();
        }
        
        else 
        {
            Texture2D tex = Resources.Load("Images/cam1") as Texture2D;
            //Texture2D tex = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            mr.material.mainTexture = tex as Texture;
            tex = null;
        }
        
    }
    /*IEnumerator DownloadImage()
    {
        *//*// 클래스 만들어 놓기, massagepack 깔아놓기.
        // UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/default/data/operator/exec",);
        yield return www.Send();
        byte[] image = www.downloadHandler.data;
        // obj a = unpack(www.downloadHandler.data);
        //tex.LoadImage(a.image.data); 
        tex.LoadImage(image);
        mr.material.mainTexture = tex as Texture;*//*
    }*/
    public void SetImage()
    {
        //StartCoroutine(DownloadImage());
    }
}
