using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class cam3script : MonoBehaviour
{
    MeshRenderer mr;
    Texture2D tex;

    void Start()
    {
        mr = GameObject.Find("cam3").GetComponent<MeshRenderer>();
        tex = new Texture2D(100, 100, TextureFormat.RGBA32, false);
    }
    int start = 0;
    private void OnMouseDown()
    {
        start += 1;
    }
    void FixedUpdate()
    {

        if (start % 2 == 1)
        {
            SetImage();
        }

        else
        {
            Texture2D tex = Resources.Load("Images/cam3") as Texture2D;
            //Texture2D tex = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            mr.material.mainTexture = tex as Texture;
            tex = null;
        }

    }
    IEnumerator DownloadImage()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/cam3");
        yield return www.Send();
        byte[] image = www.downloadHandler.data;
        tex.LoadImage(image);
        mr.material.mainTexture = tex as Texture;
    }
    public void SetImage()
    {
        StartCoroutine(DownloadImage());
    }
}
