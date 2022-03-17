using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCheck : MonoBehaviour
{
    public SettingLoad settings;
    public GameObject pointerMCStraigthLeft;
    public GameObject pointerMCStraigthRight;
    public GameObject pointerMCCurvedLeft;
    public GameObject pointerMCCurvedRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (settings.controlSchemeType == SettingLoad.controlScheme.MotionControl)
        {

        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Mouse)
        {

        }
        else if (settings.controlSchemeType == SettingLoad.controlScheme.Controller)
        {

        }

    }

    public void DisableMCStraigthRight() {
        pointerMCStraigthRight.SetActive(false);
    }
    public void DisableMCStraigthLeft() {
        pointerMCStraigthLeft.SetActive(false);
    }
    public void EnableMCStraigthRight()
    {
        pointerMCStraigthRight.SetActive(true);
    }
    public void EnableMCStraigthLeft()
    {
        pointerMCStraigthLeft.SetActive(true);
    }
}
