using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;
using Tilia.Interactions.Interactables.Interactables;

public class BallHandling : MonoBehaviour
{


    public BooleanAction ActivationAction;
    public bool isGrabbed = false;

    public GameObject target;
    public GameObject origin;
    public GameObject pointerRight;
    public GameObject pointerLeft;
    private InteractableFacade facade;

    public float power = 1f;

    // Start is called before the first frame update
    void Start()
    {
        facade = target.GetComponent<InteractableFacade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivationAction.Value && isGrabbed)
        {
            Vector3 heading = origin.GetComponent<Transform>().forward;
            Vector3 direction = heading.normalized;
            facade.Ungrab();
            target.GetComponent<Rigidbody>().velocity = direction*power;
        }
    }

    public void GrabBall()
    {
        isGrabbed = true;
        //pointerRight.SetActive(false);
    }

    public void DropBall()
    {
        isGrabbed = false;
        //pointerRight.SetActive(true);
        //if(pointerLeft != null)
        //pointerLeft.SetActive(true);
    }
}
