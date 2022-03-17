using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class MovementSwitch : MonoBehaviour
{
    public BooleanAction ActivationAction;

    public GameObject freeMovement;
    public GameObject teleport;
    public GameObject curveright;
    public GameObject curveleft;
    public bool isTeleport = false;
    public bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivationAction.Value && isTeleport && !waiting)
        {
            isTeleport = false;
            freeMovement.GetComponent<FreeMovement>().teleport = false;
            teleport.SetActive(false);
            curveright.SetActive(false);
            curveleft.SetActive(false);
            waiting = true;
            StartCoroutine(Wait());
        }
        else if (ActivationAction.Value && !isTeleport && !waiting)
        {
            isTeleport = true;
            freeMovement.GetComponent<FreeMovement>().teleport = true;
            teleport.SetActive(true);
            curveright.SetActive(true);
            curveleft.SetActive(true);
            waiting = true;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
            yield return new WaitForSeconds(0.3f);
            waiting = !waiting;
    }
}
