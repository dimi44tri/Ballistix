using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

        //Check if scrolling the menu vertically via keyboard or gamepad instead of mouse
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }

        //Check if scrolling the menu horizontally via keyboard or gamepad instead of mouse
        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    //when selecting another button the previous button is deselected
    private void OnDisable () { buttonSelected = false; }
	
}
