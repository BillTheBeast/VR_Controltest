using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    #region Control Objects
    public GameObject origin;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject blocker;
    public GameObject grab;
    #endregion

    #region Location Data
    private Transform playerLocation;
    private Transform cameraLocation;
    private Transform blockerLocation;
    private Transform grabLocation;
    private Transform originLocation;
    #endregion

    private Vector3 mouse;
    public Vector3 direction;
    public Vector3 controllerPointer;

    public enum controlScheme {Mouse, Controller};
    public controlScheme controlSchemeType;
    public enum controlDirection {Player, Camera, CameraLock};
    public controlDirection controlDirectionType;
    public int movementSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = player.GetComponent<Transform>();
        cameraLocation = playerCamera.GetComponent<Transform>();
        blockerLocation = blocker.GetComponent<Transform>();
        originLocation = origin.GetComponent<Transform>();
        grabLocation = grab.GetComponent<Transform>();
        controllerPointer = new Vector3(Screen.width/2, Screen.height/2, 0);
    }

    // Update is called once per frame
    void Update()
    {

        switch (controlSchemeType) {
            case controlScheme.Controller:
            {
                if (controlDirectionType == controlDirection.Player)
                {
                    if (controllerPointer.x > 0 || controllerPointer.y > 0 || controllerPointer.x < Screen.width || controllerPointer.y < Screen.height)
                    {
                            if (Mathf.Abs(Input.GetAxisRaw("RightStickX")) > 0.05f || Mathf.Abs(Input.GetAxisRaw("RightStickY")) > 0.05f)
                            {
                                controllerPointer.x = controllerPointer.x + Input.GetAxisRaw("RightStickX") * movementSpeed * Time.deltaTime;
                                controllerPointer.y = controllerPointer.y + Input.GetAxisRaw("RightStickY") * movementSpeed * Time.deltaTime;
                                if (controllerPointer.x < 0) controllerPointer.x = 0;
                                if (controllerPointer.y < 0) controllerPointer.y = 0;
                                if (controllerPointer.x > Screen.width) controllerPointer.x = Screen.width;
                                if (controllerPointer.y > Screen.height) controllerPointer.y = Screen.height;
                            }

                        Vector3 tempMouse = new Vector3(((controllerPointer.x / Screen.width) * 2) - 1, (((controllerPointer.y + ((Screen.width - Screen.height) / 2)) / Screen.width) * 2) - 1, 1);
                        tempMouse = tempMouse.normalized;
                        Vector3 lookDir = playerLocation.forward;

                        direction = new Vector3(tempMouse.x * lookDir.z + tempMouse.z * lookDir.x, tempMouse.y, tempMouse.x * -lookDir.x + tempMouse.z * lookDir.z);

                        originLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        grabLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        blockerLocation.rotation = Quaternion.LookRotation(lookDir, playerLocation.up);
                        originLocation.position = cameraLocation.position;
                        grabLocation.position = cameraLocation.position;
                    }

                }
                else if (controlDirectionType == controlDirection.Camera)
                {
                    if (controllerPointer.x > 0 || controllerPointer.y > 0 || controllerPointer.x < Screen.width || controllerPointer.y < Screen.height)
                    {
                            if (Mathf.Abs(Input.GetAxisRaw("RightStickX")) > 0.05f || Mathf.Abs(Input.GetAxisRaw("RightStickY")) > 0.05f)
                            {
                                controllerPointer.x = controllerPointer.x + Input.GetAxisRaw("RightStickX") * movementSpeed * Time.deltaTime;
                                controllerPointer.y = controllerPointer.y + Input.GetAxisRaw("RightStickY") * movementSpeed * Time.deltaTime;
                                if (controllerPointer.x < 0) controllerPointer.x = 0;
                                if (controllerPointer.y < 0) controllerPointer.y = 0;
                                if (controllerPointer.x > Screen.width) controllerPointer.x = Screen.width;
                                if (controllerPointer.y > Screen.height) controllerPointer.y = Screen.height;
                            }


                        Vector3 tempMouse = new Vector3(((controllerPointer.x / Screen.width) * 2) - 1, (((controllerPointer.y + ((Screen.width - Screen.height) / 2)) / Screen.width) * 2) - 1, 1);
                        tempMouse = tempMouse.normalized;
                        Vector3 lookDir = cameraLocation.forward;

                        /*direction = new Vector3(tempMouse.x * lookDir.z + tempMouse.z * lookDir.x,
                            lookDir.y + tempMouse.y  * Mathf.Sqrt(Mathf.Pow(lookDir.z, 2) + Mathf.Pow(lookDir.x, 2)),
                            tempMouse.x * -lookDir.x + tempMouse.z * lookDir.z);*/

                        //originLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        //grabLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        originLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up) * Quaternion.LookRotation(tempMouse, cameraLocation.up);
                        grabLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up) * Quaternion.LookRotation(tempMouse, cameraLocation.up);
                        blockerLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                        originLocation.position = cameraLocation.position;
                        grabLocation.position = cameraLocation.position;
                    }
                }
                else if (controlDirectionType == controlDirection.CameraLock)
                {
                    Vector3 lookDir = cameraLocation.forward;

                    originLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    grabLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    blockerLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    originLocation.position = cameraLocation.position;
                    grabLocation.position = cameraLocation.position;
                }
                break;
            }
            case controlScheme.Mouse:
            {
                mouse = Input.mousePosition;
                if (controlDirectionType == controlDirection.Player) {
                    if (!(mouse.x < 0 || mouse.y < 0 || mouse.x > Screen.width || mouse.y > Screen.height))
                    {
                        Vector3 tempMouse = new Vector3(((mouse.x / Screen.width) * 2) - 1, (((mouse.y + ((Screen.width - Screen.height) / 2)) / Screen.width) * 2) - 1, 1);
                        Vector3 lookDir = playerLocation.forward;

                        direction = new Vector3(tempMouse.x * lookDir.z + tempMouse.z * lookDir.x, tempMouse.y, tempMouse.x * -lookDir.x + tempMouse.z * lookDir.z);

                        originLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        grabLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        blockerLocation.rotation = Quaternion.LookRotation(lookDir, playerLocation.up);
                        originLocation.position = cameraLocation.position;
                        grabLocation.position = cameraLocation.position;
                    }
                }
                else if (controlDirectionType == controlDirection.Camera) {
                    if (!(mouse.x < 0 || mouse.y < 0 || mouse.x > Screen.width || mouse.y > Screen.height))
                    {
                        Vector3 tempMouse = new Vector3(((mouse.x / Screen.width) * 2) - 1, (((mouse.y + ((Screen.width - Screen.height) / 2)) / Screen.width) * 2) - 1,1);
                        tempMouse = tempMouse.normalized;
                        Vector3 lookDir = cameraLocation.forward;

                        /*direction = new Vector3(tempMouse.x * lookDir.z + tempMouse.z * lookDir.x,
                            lookDir.y + tempMouse.y  * Mathf.Sqrt(Mathf.Pow(lookDir.z, 2) + Mathf.Pow(lookDir.x, 2)),
                            tempMouse.x * -lookDir.x + tempMouse.z * lookDir.z);*/

                        //originLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        //grabLocation.rotation = Quaternion.LookRotation(direction, playerLocation.up);
                        originLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up) * Quaternion.LookRotation(tempMouse, cameraLocation.up);
                        grabLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up) * Quaternion.LookRotation(tempMouse, cameraLocation.up);
                        blockerLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                        originLocation.position = cameraLocation.position;
                        grabLocation.position = cameraLocation.position;
                    } 
                }
                else if (controlDirectionType == controlDirection.CameraLock)
                {
                    Vector3 lookDir = cameraLocation.forward;

                    originLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    grabLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    blockerLocation.rotation = Quaternion.LookRotation(lookDir, cameraLocation.up);
                    originLocation.position = cameraLocation.position;
                    grabLocation.position = cameraLocation.position;
                }

                break;
            } 
        }
    }
}
