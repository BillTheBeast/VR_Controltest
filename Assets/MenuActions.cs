using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuActions : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;

    public GameObject controlSystemArea;
    public GameObject hmdLockArea;
    public GameObject movementStyleArea;
    public GameObject cameraLockArea;

    public void startTest(){
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    IEnumerator openOptionsMenu()
    {
        yield return new WaitForSeconds(0.2f);
        menu.SetActive(false);
        options.SetActive(true);
        updateSettings();
    }

    public void optionsMenu()
    {
        //StartCoroutine(openOptionsMenu());
        menu.SetActive(false);
        options.SetActive(true);
        updateSettings();
    }

    public void closeOptionsMenu()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }


    //***********************************
    public void incrementCS()
    {
        if (SettingOptions.controlSystem < 2)
        {
            SettingOptions.controlSystem++;
            updateSettings();
        }
    }

    public void decrementCS()
    {
        if (SettingOptions.controlSystem > 0)
        {
            SettingOptions.controlSystem--;
            updateSettings();
        }
    }

    public void incrementHL()
    {
        if (SettingOptions.hmdLock < 1)
        {
            SettingOptions.hmdLock++;
            updateSettings();
        }
    }

    public void decrementHL()
    {
        if (SettingOptions.hmdLock > 0)
        {
            SettingOptions.hmdLock--;
            updateSettings();
        }
    }

    public void incrementMS()
    {
        if (SettingOptions.movementStyle < 2)
        {
            SettingOptions.movementStyle++;
            updateSettings();
        }
    }

    public void decrementMS()
    {
        if (SettingOptions.movementStyle > 0)
        {
            SettingOptions.movementStyle--;
            updateSettings();
        }

    }

    public void incrementCL()
    {
        if (SettingOptions.cameraLock < 2)
        {
            SettingOptions.cameraLock++;
            updateSettings();
        }

    }

    public void decrementCL()
    {
        if (SettingOptions.cameraLock > 0)
        {
            SettingOptions.cameraLock--;
            updateSettings();
        }

    }

    public void updateSettings()
    {
        switch (SettingOptions.controlSystem)
        {
            case 0:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Motion Controls";
                break;
            case 1:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Controller";
                break;
            case 2:
                controlSystemArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Keyboard + Mouse";
                break;
        }
        switch (SettingOptions.hmdLock)
        {
            case 0:
                hmdLockArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Room Scale";
                break;
            case 1:
                hmdLockArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Stationary";
                break;
        }
        switch (SettingOptions.movementStyle)
        {
            case 0:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Teleport + Free Movement";
                break;
            case 1:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Teleport";
                break;
            case 2:
                movementStyleArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Free Movement";
                break;
        }
        switch (SettingOptions.cameraLock)
        {
            case 0:
                cameraLockArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Camera Direction";
                break;
            case 1:
                cameraLockArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Player Direction";
                break;
            case 2:
                cameraLockArea.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Camera Lock";
                break;
        }
    }
}
