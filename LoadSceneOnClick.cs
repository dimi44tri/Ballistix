using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {

    public float plifePoints = 10f;
    public float clifePoints = 10f;
    public Slider pValue;
    public Slider cValue;
    public DestroyLife dLife1;
    public DestroyLife dLife2;
    public DestroyLife dLife3;
    public DestroyLife dLife4;

    public void LoadByIndex (int sceneIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            //reassign custom life point values for Player 1/AI 4 upon scene reload
            dLife1.AssignPlayerLives(dLife1.SavePlayer());
            dLife1.AssignCPULives(dLife1.SaveCPU());

            //reassign custom life point values for Player 2/AI 1 upon scene reload
            dLife2.AssignPlayerLives(dLife2.SavePlayer());
            dLife2.AssignCPULives(dLife2.SaveCPU());

            //reassign custom life point values for Player 3/AI 2 upon scene reload
            dLife3.AssignPlayerLives(dLife3.SavePlayer());
            dLife3.AssignCPULives(dLife3.SaveCPU());

            //reassign custom life point values for Player 4/AI 3 upon scene reload
            dLife4.AssignPlayerLives(dLife4.SavePlayer());
            dLife4.AssignCPULives(dLife4.SaveCPU());
        }

        SceneManager.LoadScene(sceneIndex);

        //resume time
        if (Time.timeScale != 1) { Time.timeScale = 1; }     
    }

    //store custom player lives settings
    public void StorePlayerValue()
    {
        pValue.value = dLife1.SavePlayer();
    }

    //store custom CPU lives settings
    public void StoreCPUValue()
    {
        cValue.value = dLife1.SaveCPU();
    }
    
}


