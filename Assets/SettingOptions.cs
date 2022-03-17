using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingOptions
{

    public static int controlSystem { get; set; } = 0;
    public static int hmdLock { get; set; } = 0;
    public static int movementStyle { get; set; } = 0;
    public static int cameraLock { get; set; } = 0;

    //public GameObject controlSystemArea;
    //public GameObject hmdLockArea;
    //public GameObject movementStyleArea;


    /*public void incrementCS()
    {
        if (controlSystem < 2) 
        {
            controlSystem++;
            updateSettings();
        }
    }

    public void decrementCS()
    {
        if (controlSystem > 0) 
        {
            controlSystem--;
            updateSettings();
        }
    }

    public void incrementHL()
    {
        if (hmdLock < 1) 
        { 
            hmdLock++;
            updateSettings();
        }
    }

    public void decrementHL()
    {
        if (hmdLock > 0) 
        {
            hmdLock--;
            updateSettings();
        }
    }

    public void incrementMS()
    {
        if (movementStyle < 2) 
        {
            movementStyle++;
            updateSettings();
        }
    }

    public void decrementMS()
    {
        if (movementStyle > 0)
        {
            movementStyle--;
            updateSettings();
        }

    }

    public void updateSettings() 
    {
        switch (controlSystem)
        {
            case 0:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Motion Controls";
                break;
            case 1:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Controller";
                break;
            case 2:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Keyboard + Mouse";
                break;
        }
        switch (hmdLock)
        {
            case 0:
                hmdLockArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Room Scale";
                break;
            case 1:
                hmdLockArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Stationary";
                break;
        }
        switch (movementStyle)
        {
            case 0:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Teleport + Free Movement";
                break;
            case 1:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Teleport";
                break;
            case 2:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.getComponent<TextMeshPro>().text = "Free Movement";
                break;
        }
    }*/
}
