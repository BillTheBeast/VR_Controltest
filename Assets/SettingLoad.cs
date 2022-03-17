using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Tilia.CameraRigs.UnityXR;

public class SettingLoad : MonoBehaviour
{

    public GameObject MotionContollerLeft;
    public GameObject MotionContollerLeftControls;
    public GameObject MotionContollerLeftPointer;
    public GameObject MotionContollerLeftCurvePointer;
    public GameObject MotionContollerRight;
    public GameObject MotionContollerRightControls;
    public GameObject MotionContollerRightPointer;
    public GameObject MotionContollerRightCurvePointer;
    [Space(15)]
    public GameObject Pointer;
    public GameObject GrabPointer;
    public GameObject PointerMouse;
    public GameObject GrabPointerMouse;
    public GameObject PointerController;
    public GameObject GrabPointerController;
    public GameObject PointerControl;
    public GameObject KBMControl;
    public GameObject ControllerControl;
    [Space(15)]
    public GameObject Teleporter;
    public FreeMovement freeMovement;
    public GameObject MovementSwitch;
    public GameObject MovementSwitchMouseController;
    [Space(15)]
    public UnityXRConfigurator HMDType;
    [Space(15)]
    public GameObject MCLeftHSPointer;
    public GameObject MCRightHSPointer;
    public GameObject KBMHSPointer;
    public GameObject ControllerHSPointer;
    [Space(15)]
    public GameObject ballHandling;
    public GameObject ballHandlingMouse;
    public GameObject ballHandlingController;


    public enum controlScheme { MotionControl, Mouse, Controller };
    [Space(15)]
    public controlScheme controlSchemeType;
    public enum vrType { Stationary, RoomScale };
    public vrType vrTypeType;
    public enum movementStyle { Teleport, FreeMovement, TPFM};
    public movementStyle movementStyleType;
    public enum cameraLock { Player, Camera, CameraLock };
    public cameraLock cameraLockType;

    [Space(15)]
    public bool debug = false;

    void Awake()
    {
        if (!debug)
        {
            if (SettingOptions.controlSystem == 0)
            {
                controlSchemeType = controlScheme.MotionControl;
            }
            else if (SettingOptions.controlSystem == 1)
            {
                controlSchemeType = controlScheme.Controller;
            }
            else if (SettingOptions.controlSystem == 2)
            {
                controlSchemeType = controlScheme.Mouse;
            }
            if (SettingOptions.hmdLock == 0)
            {
                vrTypeType = vrType.RoomScale;
            }
            else if (SettingOptions.hmdLock == 1)
            {
                vrTypeType = vrType.Stationary;
            }
            if (SettingOptions.movementStyle == 0)
            {
                movementStyleType = movementStyle.TPFM;
            }
            else if (SettingOptions.movementStyle == 1)
            {
                movementStyleType = movementStyle.Teleport;
            }
            else if (SettingOptions.movementStyle == 2)
            {
                movementStyleType = movementStyle.FreeMovement;
            }
            if (SettingOptions.cameraLock == 0)
            {
                cameraLockType = cameraLock.Camera;
            }
            else if (SettingOptions.cameraLock == 1)
            {
                cameraLockType = cameraLock.Player;
            }
            else if (SettingOptions.cameraLock == 2)
            {
                cameraLockType = cameraLock.CameraLock;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (controlSchemeType == controlScheme.MotionControl)
        {
            MotionContollerLeft.SetActive(true);
            MotionContollerLeftControls.SetActive(true);
            MotionContollerLeftPointer.SetActive(true);
            MotionContollerLeftCurvePointer.SetActive(true);
            MotionContollerRight.SetActive(true);
            MotionContollerRightControls.SetActive(true);
            MotionContollerRightPointer.SetActive(true);
            MotionContollerRightCurvePointer.SetActive(true);

            Pointer.SetActive(false);
            GrabPointer.SetActive(false);
            PointerControl.SetActive(false);
            KBMControl.SetActive(false);
            ControllerControl.SetActive(false);
            freeMovement.controlSchemeType = FreeMovement.controlScheme.MotionControl;

            ballHandling.SetActive(true);
            ballHandlingMouse.SetActive(false);
            ballHandlingController.SetActive(false);
        }
        else
        {
            MotionContollerLeft.SetActive(false);
            MotionContollerLeftControls.SetActive(false);
            MotionContollerLeftPointer.SetActive(false);
            MotionContollerLeftCurvePointer.SetActive(false);
            MotionContollerRight.SetActive(false);
            MotionContollerRightControls.SetActive(false);
            MotionContollerRightPointer.SetActive(false);
            MotionContollerRightCurvePointer.SetActive(false);
            MCLeftHSPointer.SetActive(false);
            MCRightHSPointer.SetActive(false);

            Pointer.SetActive(true);
            GrabPointer.SetActive(true);
            PointerControl.SetActive(true);
            if (controlSchemeType == controlScheme.Mouse)
            {
                KBMHSPointer.SetActive(true);
                ControllerHSPointer.SetActive(false);
                PointerMouse.SetActive(true);
                GrabPointerMouse.SetActive(true);
                PointerController.SetActive(false);
                GrabPointerController.SetActive(false);
                KBMControl.SetActive(true);
                ControllerControl.SetActive(false);
                freeMovement.controlSchemeType = FreeMovement.controlScheme.Mouse;
                PointerControl.GetComponent<MousePointer>().controlSchemeType = MousePointer.controlScheme.Mouse;
                ballHandlingMouse.SetActive(true);
                ballHandlingController.SetActive(false);
            }
            else
            {
                KBMHSPointer.SetActive(false);
                ControllerHSPointer.SetActive(true);
                PointerMouse.SetActive(false);
                GrabPointerMouse.SetActive(false);
                PointerController.SetActive(true);
                GrabPointerController.SetActive(true);
                KBMControl.SetActive(false);
                ControllerControl.SetActive(true);
                freeMovement.controlSchemeType = FreeMovement.controlScheme.Controller;
                PointerControl.GetComponent<MousePointer>().controlSchemeType = MousePointer.controlScheme.Controller;
                ballHandlingMouse.SetActive(false);
                ballHandlingController.SetActive(true);
                MotionContollerLeftControls.SetActive(true);
                MotionContollerRightControls.SetActive(true);
            }

            ballHandling.SetActive(false);
        }

        if (vrTypeType == vrType.Stationary)
        {
            freeMovement.vrTypeType = FreeMovement.vrType.Stationary;
            HMDType.SetTrackingSpaceType(0);
        }
        else { 
            freeMovement.vrTypeType = FreeMovement.vrType.RoomScale;
            HMDType.SetTrackingSpaceType(1);
        }

        if (movementStyleType == movementStyle.Teleport)
        {
            Teleporter.SetActive(true);
            freeMovement.teleport = true;
            MovementSwitch.SetActive(false);

            if(controlSchemeType != controlScheme.MotionControl)
            {
                MovementSwitchMouseController.SetActive(true);
                TeleportSwitchMouseController tsmc = MovementSwitchMouseController.GetComponent<TeleportSwitchMouseController>();
                if(controlSchemeType == controlScheme.Mouse)
                    tsmc.controlSchemeType = TeleportSwitchMouseController.controlScheme.Mouse;
                else
                    tsmc.controlSchemeType = TeleportSwitchMouseController.controlScheme.Controller;
            }
}
        else if (movementStyleType == movementStyle.FreeMovement)
        {
            Teleporter.SetActive(false);
            freeMovement.teleport = false;
            MovementSwitch.SetActive(false);
            MotionContollerRightCurvePointer.SetActive(false);
            MotionContollerLeftCurvePointer.SetActive(false);
        }
        else
        {
            Teleporter.SetActive(false);
            freeMovement.teleport = false;
            if (controlSchemeType == controlScheme.MotionControl)
            {
                MovementSwitch.SetActive(true);
                MotionContollerRightCurvePointer.SetActive(false);
                MotionContollerLeftCurvePointer.SetActive(false);
            }
            else
            {
                Teleporter.SetActive(true);
                MovementSwitchMouseController.SetActive(true);
                TeleportSwitchMouseController tsmc = MovementSwitchMouseController.GetComponent<TeleportSwitchMouseController>();
                if (controlSchemeType == controlScheme.Mouse)
                    tsmc.controlSchemeType = TeleportSwitchMouseController.controlScheme.Mouse;
                else
                    tsmc.controlSchemeType = TeleportSwitchMouseController.controlScheme.Controller;
            }
        }

        if (cameraLockType == cameraLock.Player)
        {
            PointerControl.GetComponent<MousePointer>().controlDirectionType = MousePointer.controlDirection.Player;
        }
        else if (cameraLockType == cameraLock.Camera)
        {
            PointerControl.GetComponent<MousePointer>().controlDirectionType = MousePointer.controlDirection.Camera;
        }
        else
        {
            PointerControl.GetComponent<MousePointer>().controlDirectionType = MousePointer.controlDirection.CameraLock;
            if (controlSchemeType == controlScheme.MotionControl)
            {

            }
        }
    }
}
