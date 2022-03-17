using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class FreeMovement : MonoBehaviour
{

    public FloatAction XAxisMovement;
    public FloatAction YAxisMovement;
    public FloatAction YAxisRotation;
    public float movementSpeed = 1.5f; //Movement Speed multiplier. Defaults to 1.5 because 1 is very slow.
    public float rotationSpeed = 100; //Rotation in angles within a second.
    private float gravity = 9.81f;

    private float yVelocity = 0;
    public enum controlScheme { MotionControl, Mouse, Controller };
    public controlScheme controlSchemeType;
    public enum vrType { Stationary, RoomScale};
    public vrType vrTypeType;
    public bool teleport = false; //Are we using teleport controls?
    public bool writing = false; //Are we writing with keyboard?

    public CharacterController playerController;
    public GameObject player;
    public GameObject playerHMD;
    private Transform playerLocation;
    private Transform playerHMDLocation;
    public bool teleporting = false;
    private Quaternion tempRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = player.GetComponent<Transform>();
        playerHMDLocation = playerHMD.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,0,0);

        //If we are using teleporter movement or are writing with the keyboard we'll ingore movement commands.
        if (!teleport && !writing) {

            //Movement using analogstick
            if ((XAxisMovement.Value != 0 || YAxisMovement.Value != 0) && controlSchemeType != controlScheme.Mouse)
            {
                //Vector3 heading = new Vector3(XAxisMovement.Value, 0, YAxisMovement.Value);
                if (vrTypeType == vrType.RoomScale)
                    //direction = (new Vector3(playerHMDLocation.right.x, 0, playerHMDLocation.right.z) * XAxisMovement.Value + new Vector3(playerHMDLocation.forward.x, 0, playerHMDLocation.forward.z) * YAxisMovement.Value) * movementSpeed;
                    direction = (playerHMDLocation.right * XAxisMovement.Value + playerHMDLocation.forward * YAxisMovement.Value) * movementSpeed;
                if (vrTypeType == vrType.Stationary)
                    direction = (playerLocation.right * XAxisMovement.Value + playerLocation.forward * YAxisMovement.Value) * movementSpeed;
                //playerController.Move(direction * movementSpeed * Time.deltaTime);
            }

            //Rotation with Motion Controllers
            if (Mathf.Abs(YAxisRotation.Value) > 0.05f && controlSchemeType == controlScheme.MotionControl)
            {
                Vector3 heading = new Vector3(0, YAxisRotation.Value, 0);
                //Vector3 direction = heading.normalized;

                playerLocation.RotateAround(new Vector3(playerHMDLocation.position.x, 0, playerHMDLocation.position.z), Vector3.up, YAxisRotation.Value * rotationSpeed * Time.deltaTime);
            }
            //Movement with keyboard
            if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 ) && (controlSchemeType == controlScheme.Mouse /*|| controlSchemeType == controlScheme.Controller*/))
            {
                //Vector3 heading = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                //direction = (playerLocation.right * Input.GetAxisRaw("Horizontal") + playerLocation.forward * Input.GetAxisRaw("Vertical")) * movementSpeed;
                //playerController.Move(direction * movementSpeed * Time.deltaTime);
                if (vrTypeType == vrType.RoomScale)
                    direction = (playerHMDLocation.right * Input.GetAxisRaw("Horizontal") + playerHMDLocation.forward * Input.GetAxisRaw("Vertical")) * movementSpeed;
                if (vrTypeType == vrType.Stationary)
                    direction = (playerLocation.right * Input.GetAxisRaw("Horizontal") + playerLocation.forward * Input.GetAxisRaw("Vertical")) * movementSpeed;
            }

            //Left Rotation with Keyboard and Standard controller
            if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.JoystickButton4)) && controlSchemeType != controlScheme.MotionControl)
            {
                Vector3 heading = new Vector3(0, -1, 0);

                //playerLocation.Rotate(heading * rotationSpeed * Time.deltaTime);
                playerLocation.RotateAround(new Vector3(playerHMDLocation.position.x, 0, playerHMDLocation.position.z), Vector3.up, -1 * rotationSpeed * Time.deltaTime);
            }

            //Right Rotation with Keyboard and Standard controller
            if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.JoystickButton5)) && controlSchemeType != controlScheme.MotionControl)
            {
                Vector3 heading = new Vector3(0, 1, 0);

                //playerLocation.Rotate(heading * rotationSpeed * Time.deltaTime);
                playerLocation.RotateAround(new Vector3(playerHMDLocation.position.x, 0, playerHMDLocation.position.z), Vector3.up, 1 * rotationSpeed * Time.deltaTime);
            } 
        }
        //This check isn't currently needed, but if there is need for the commented out movement handling code below, it is needed to not cause issues with teleporting code.
        if (!teleporting)
        {
            /*if (playerController.isGrounded)
            {
                yVelocity = 0;
                direction.y = yVelocity;
            }
            else
            {
                yVelocity -= gravity * Time.deltaTime;
                direction.y = yVelocity;
            }*/
            //playerController.Move(direction * Time.deltaTime);
            playerLocation.position += direction * Time.deltaTime;
            //Vector3 playerPosition = playerController.GetComponent<Transform>().position;
            /*if (vrTypeType == vrType.Stationary)
                playerPosition.y += playerController.height / 2;
            if (vrTypeType == vrType.RoomScale)
                playerPosition.y -= playerController.height / 2;*/
            //playerLocation.position = new Vector3(playerHMDLocation.position.x, playerLocation.position.y, playerHMDLocation.position.x);
        }
    }

    public void Teleporting()
    {
        teleporting = true;
        //playerController.GetComponent<Transform>().position = playerLocation.position;
        tempRotation = playerLocation.rotation;
    }

    public void Teleported()
    {
        Vector3 teleportPoint = playerLocation.position;
        teleportPoint.y += playerController.height / 2;
        playerController.GetComponent<Transform>().position = teleportPoint;
        playerLocation.rotation = tempRotation;

        IEnumerator coroutine = Wait(0.1f);
        StartCoroutine(coroutine);
    }

    private IEnumerator Wait(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            teleporting = false;
    }

    public void SetSpeed15()
    {
        movementSpeed = 1.5f;
    }

    public void SetSpeed30()
    {
        movementSpeed = 3.0f;
    }

    public void SetSpeed45()
    {
        movementSpeed = 4.5f;
    }
}
