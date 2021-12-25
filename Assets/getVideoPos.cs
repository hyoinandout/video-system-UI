using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getVideoPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, GameObject.Find("V"+this.name[12]).GetComponent<Test>().P1);
    }
}
