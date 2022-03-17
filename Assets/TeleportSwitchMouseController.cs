using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitchMouseController : MonoBehaviour
{

    public enum controlScheme { Mouse, Controller };
    public controlScheme controlSchemeType;

    public GameObject PointerStraigthMouse;
    public GameObject PointerStraigthController;
    public GameObject PointerGrabMouse;
    public GameObject PointerGrabController;
    public GameObject PointerCurvedMouse;
    public GameObject PointerCurvedController;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlSchemeType == controlScheme.Mouse && Input.GetKeyDown(KeyCode.Space))
        {
            PointerStraigthMouse.SetActive(false);
            PointerGrabMouse.SetActive(false);
            PointerCurvedMouse.SetActive(true);
        } 
        else if(controlSchemeType == controlScheme.Mouse && Input.GetKeyUp(KeyCode.Space)) 
        {
            PointerStraigthMouse.SetActive(true);
            PointerGrabMouse.SetActive(true);
            PointerCurvedMouse.SetActive(false);
        }
        else if (controlSchemeType == controlScheme.Controller && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            PointerStraigthController.SetActive(false);
            PointerGrabController.SetActive(false);
            PointerCurvedController.SetActive(true);
        }
        else if (controlSchemeType == controlScheme.Controller && Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            PointerStraigthController.SetActive(true);
            PointerGrabController.SetActive(true);
            PointerCurvedController.SetActive(false);
        }
    }
}
