using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BezierSystem : MonoBehaviour
{
    public GameObject[] arrayObject;
    public GameObject[] sphereObject;
    public string[] pointNames;
    public string[] sliderNames;
    public GameObject[] sliderObject;
    Vector3 p1Vector;
    Vector3 p2Vector;
    Vector3 p3Vector;
    Vector3 p4Vector;
    Vector3 newVector;
    public int degree;
    public float[] rad;
    public float[] addRad;
    // Start is called before the first frame update
    void Start()
    {
        pointNames = new string[4];
        sliderNames = new string[4];
        arrayObject = new GameObject[4];
        sliderObject = new GameObject[4];
        sphereObject = new GameObject[4];
        rad = new float[5];
        addRad = new float[5];
        for (int i = 0; i < 4; i++)
        {
            pointNames[i] = "V" + (i + 1);
            sliderNames[i] = "Slider" + (i + 1);
            /*Debug.Log(pointNames[i]);
            Debug.Log(sliderNames[i]);*/
        }


        for (int i = 0; i < 4; i++)
        {
            arrayObject[i] = new GameObject(pointNames[i]);
            //sliderObject[i] = GameObject.Find("Canvas/" + sliderNames[i]);
            sphereObject[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereObject[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            arrayObject[i].AddComponent<Test>();
        }
        //LineRenderer lineRenderer1 = gameObject.AddComponent<LineRenderer>();
        /*LineRenderer lineRenderer2 = gameObject.AddComponent<LineRenderer>();
        LineRenderer lineRenderer3 = gameObject.AddComponent<LineRenderer>();
        LineRenderer lineRenderer4 = gameObject.AddComponent<LineRenderer>();*/
        //lineRenderer1.SetWidth(0.1F, 0.1F);
        /*lineRenderer2.SetWidth(0.1F, 0.1F);
        lineRenderer3.SetWidth(0.1F, 0.1F);
        lineRenderer4.SetWidth(0.1F, 0.1F);*/
        //lineRenderer1.SetVertexCount(2); 
        /*lineRenderer2.SetVertexCount(2); 
        lineRenderer3.SetVertexCount(2); 
        lineRenderer4.SetVertexCount(2); */
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {    
        for (int a = 0;a <30; a++)
        {
            //LineRenderer lineRenderer1 = GetComponent<LineRenderer>();
            //LineRenderer lineRenderer2 = GetComponent<LineRenderer>();
            //Vector3[] points1 = new Vector3[2];
            /*Vector3[] points2 = new Vector3[2];
            Vector3[] points3 = new Vector3[2];
            Vector3[] points4 = new Vector3[2];*/
           // points1[1] = new Vector3(0, 0, -1.5f);
            /*points2[1] = new Vector3(0, 0, 1.5f);
            points3[1] = new Vector3(0, 0, 1.5f);
            points4[1] = new Vector3(0, 0, 1.5f);*/
            float degree = 135;
            float radian;
            float radian2 = 225 * Mathf.Deg2Rad;
            for (int i = 1; i < 5; i++)
            {
                radian = degree * Mathf.Deg2Rad;
                rad[i] = Random.Range(4.0f, 5.0f);
                rad[i] += addRad[i];
                p1Vector.z = rad[i] * Mathf.Cos(radian);
                p1Vector.x = rad[i] * Mathf.Sin(radian);
                p2Vector.z = 1.2f * rad[i] * Mathf.Cos(radian);
                p2Vector.x = 1.2f * rad[i] * Mathf.Sin(radian);
                arrayObject[i-1].GetComponent<Test>().P1 = p1Vector;
                arrayObject[i-1].GetComponent<Test>().P2 = p2Vector;
                degree += 90;
            }
            for (int i = 1; i < 4; i++)
            {
                arrayObject[i-1].GetComponent<Test>().P3 = arrayObject[i].GetComponent<Test>().P2;
                arrayObject[i-1].GetComponent<Test>().P4 = arrayObject[i].GetComponent<Test>().P1;
                sphereObject[i-1].transform.position = arrayObject[i].GetComponent<Test>().P1;
            }
            //points1[0] = arrayObject[1].GetComponent<Test>().P1;
            /*points2[0] = arrayObject[2].GetComponent<Test>().P1;
            points3[0] = arrayObject[3].GetComponent<Test>().P1;*/

            arrayObject[3].GetComponent<Test>().P3 = arrayObject[0].GetComponent<Test>().P2;
            arrayObject[3].GetComponent<Test>().P4 = arrayObject[0].GetComponent<Test>().P1;
            sphereObject[3].transform.position = arrayObject[0].GetComponent<Test>().P1;
            //points4[0] = arrayObject[0].GetComponent<Test>().P1;
            //lineRenderer1.SetPositions(points1);    
            /*lineRenderer2.SetPositions(points2);
            lineRenderer3.SetPositions(points3);
            lineRenderer4.SetPositions(points4);*/

            /*rad[1] = Random.Range(4.0f, 5.0f);
            rad[1] += addRad[1];
            rad[2] = Random.Range(4.0f, 5.0f);
            rad[2] += addRad[2];*/

            /*arrayObject[0].GetComponent<Test>().P1 = p1Vector;
            arrayObject[0].GetComponent<Test>().P2 = p2Vector;*/
            /*arrayObject[0].GetComponent<Test>().P3 = p3Vector;
            arrayObject[0].GetComponent<Test>().P4 = p4Vector;*/
            /*sphereObject[0].transform.position = p4Vector;

            degree = 225;
            for (int i = 1; i < 4; i++)
            {
                degree += 90;
                radian = degree * Mathf.Deg2Rad;
                rad[i] = Random.Range(4.0f, 5.0f);
                rad[i] += addRad[i+1];

                newVector.z = 1.2f * rad[i] * Mathf.Cos(radian);
                newVector.x = 1.2f * rad[i] * Mathf.Sin(radian);

                arrayObject[i].GetComponent<Test>().P1 = arrayObject[i - 1].GetComponent<Test>().P4;
                arrayObject[i].GetComponent<Test>().P2 = arrayObject[i - 1].GetComponent<Test>().P3;
                arrayObject[i].GetComponent<Test>().P3 = newVector;

                newVector.z = rad[i] * Mathf.Cos(radian);
                newVector.x = rad[i] * Mathf.Sin(radian);
                arrayObject[i].GetComponent<Test>().P4 = newVector;
                sphereObject[i].transform.position = newVector;
            }
            arrayObject[3].GetComponent<Test>().P4 = arrayObject[0].GetComponent<Test>().P1;
            sphereObject[3].transform.position = arrayObject[0].GetComponent<Test>().P1;*/
            yield return new WaitForSeconds(1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
