using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Interactables.Interactables;

public class GunGrab : MonoBehaviour
{
    public SettingLoad settings;
    public bool isGrabbed = false;
    public GameObject mouse;
    public GameObject controller;
    public GameObject motionControlLeft;
    public GameObject motionControlRight;
    public GameObject pointer;
    public GameObject blocker;
    public GameObject pointerMouse;
    public InteractableFacade facade;
    [Space(15)]
    public GameObject motionControllerLeft;
    public GameObject motionControllerRight;

    private enum controlScheme { MotionControl, Mouse, Controller };
    [Space(15)]
    private controlScheme controlSchemeType;

    public void Grab()
    {
        isGrabbed = true;
        facade = mouse.transform.parent.parent.parent.gameObject.GetComponent<InteractableFacade>();

        if (settings.controlSchemeType == SettingLoad.controlScheme.MotionControl)
        {
            if(GameObject.ReferenceEquals(facade.GrabbingInteractors[0].gameObject, motionControllerRight))
            motionControlRight.SetActive(true);
            if (GameObject.ReferenceEquals(facade.GrabbingInteractors[0].gameObject, motionControllerLeft))
                motionControlLeft.SetActive(true);
        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Mouse)
        {
            mouse.SetActive(true);
            pointerMouse.SetActive(false);
            pointer.transform.localPosition += new Vector3 (0,0.2f,0);
            mouse.transform.localPosition += new Vector3(0, 0.2f, 0);
        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Controller)
        {
            controller.SetActive(true);
            pointerMouse.SetActive(false);
            pointer.transform.localPosition += new Vector3(0, 0.2f, 0);
            controller.transform.localPosition += new Vector3(0, 0.2f, 0);
        }

        pointer.SetActive(true);
        //blocker.SetActive(false);
    }

    public void Ungrab()
    {
        isGrabbed = false;
        mouse.SetActive(false);
        controller.SetActive(false);
        motionControlRight.SetActive(false);
        motionControlLeft.SetActive(false);
        pointer.SetActive(false);
        //blocker.SetActive(true);

        if (settings.controlSchemeType == SettingLoad.controlScheme.MotionControl)
        {

        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Mouse)
        {
            pointer.transform.localPosition -= new Vector3(0, 0.2f, 0);
            mouse.transform.localPosition -= new Vector3(0, 0.2f, 0);
            pointerMouse.SetActive(true);
        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Controller)
        {
            pointer.transform.localPosition -= new Vector3(0, 0.2f, 0);
            controller.transform.localPosition -= new Vector3(0, 0.2f, 0);
            pointerMouse.SetActive(true);
        }
    }
}
