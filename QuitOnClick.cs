using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

	public void Quit()
    {
#if UNITY_EDITOR
            //if Quiting from Unity Editor Play mode, exit play mode; else close application build (not compiled since currently in editor)
            UnityEditor.EditorApplication.isPlaying = false;
#else 
            Application.Quit();
#endif


    }
}
