using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

    public Text scale; 

    public void SliderText(float newText)
    {
        scale.text = newText.ToString();
    }
}
