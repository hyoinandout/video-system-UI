using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sliderScript : MonoBehaviour
{
    public Text message;
    public Text result;
    public Slider slider;
    public Button button;
    public GameObject point;

    private int min = 0;
    private int max = 100;


    void Start()
    {
        SetFunction_UI();
        Debug.Log(this.name[6]);
    }

    //CodeFinder
    //From https://codefinder.janndk.com/
    private void SetFunction_UI()
    {
        //Reset
        ResetFunction_UI();

        //button.onClick.AddListener(Function_Button);
        slider.onValueChanged.AddListener(Function_Slider);
    }

    private void Function_Button()
    {
        result.text = slider.value.ToString();
        Debug.LogError("Slider Result!\n" + slider.value);
    }
    private void Function_Slider(float _value)
    {
        result.text = slider.value.ToString();
        int a=0;
        int.TryParse(""+this.name[6],out a);
        GameObject.Find("GameObject").GetComponent<BezierSystem>().addRad[a] = slider.value/101;
        //Debug.Log(GameObject.Find("GameObject").GetComponent<BezierSystem>().rad[a-1]);
        //message.text = _value.ToString();
        //Debug.Log("Slider Dragging!\n" + _value);
    }

    private void ResetFunction_UI()
    {
        button.onClick.RemoveAllListeners();
        slider.onValueChanged.RemoveAllListeners();
        slider.maxValue = max;
        slider.minValue = min;
        slider.wholeNumbers = true;
    }
}
