using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

    public Text scale; 

    //slider logic for Lives counter text
    public void SliderLives(float newText)
    {
        scale.text = newText.ToString();
    }

    //slider logic for AI difficulty text
    public void SliderDifficulty(float newText)
    {
        if (newText == 0) { scale.text = "Mode: Easy"; }

        else if (newText == 1) { scale.text = "Mode: Normal"; }

        else if (newText == 2) { scale.text = "Mode: Hard"; }

        else if (newText == 3) { scale.text = "Mode: Extreme"; }

        else { scale.text = "Mode: Savage"; }
    }

    //slider logic for Ball speed text
    public void SliderSpeed(float newText)
    {
        scale.text = "Ball Speed: x" + newText.ToString();
    }

    //slider logic for Ball firing rate text
    public void SliderFireRate(float newText)
    {
        scale.text = "Firing Rate: x" + newText.ToString();
    }
}
