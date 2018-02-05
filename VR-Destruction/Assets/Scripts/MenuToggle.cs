using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public GameObject Menu;

    bool MenuState = false;

    private void OnEnable()
    {
        
        controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
        
    }
    private void OnDisable()
    {

    

        controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;

    }

    private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        MenuState = !MenuState;
        Menu.SetActive(MenuState);
    }

    
}
