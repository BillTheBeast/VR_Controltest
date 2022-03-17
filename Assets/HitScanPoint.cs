using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;
using VRKeys;

public class HitScanPoint : MonoBehaviour
{
    public GameObject followSource;
    public BooleanAction ActivationAction;

    public bool useLayerMask = false;
    public int layerMaskValue = 0;
    public bool invertLayerMask = false;
    public float range = Mathf.Infinity; 
    public GeneralLogic gunLogic;


    private Transform follow;

    public bool isPressing = false;

    // Start is called before the first frame update
    void Start()
    {
        follow = followSource.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (12) to get a bit mask
        int layerMask = 1 << layerMaskValue;

        //If we want to ignore a layer then we have to invert he bit mask
        if (invertLayerMask) layerMask = ~layerMask;

        RaycastHit hit;

        if (useLayerMask)
        {
            if (gunLogic != null) {
                if (Physics.Raycast(follow.position, follow.TransformDirection(Vector3.forward), out hit, range, layerMask))
                {
                    if (ActivationAction.Value && !isPressing)
                    {
                        Debug.Log("Did Hit");
                        isPressing = true;
                        gunLogic.ShotTaken();
                        if (hit.collider.tag == "Targets")
                        {
                            Debug.Log("Did Hit");
                            if (hit.collider.GetComponent<Hit>() != null)
                            {
                                hit.collider.GetComponent<Hit>().TargetHit(hit.collider);
                            }
                        }
                    }
                    else if (!ActivationAction.Value && isPressing)
                    {
                        isPressing = false;
                    }
                }
            }
            //Currently used to check if we pressed a button on a VRKeyboard
            else
            {
                if (Physics.Raycast(follow.position, follow.TransformDirection(Vector3.forward), out hit, range, layerMask))
                {
                    if (ActivationAction.Value && !isPressing)
                    {

                        Debug.Log("Did Hit");
                        isPressing = true;
                        if (hit.collider.GetComponent<Key>() != null)
                        {
                            hit.collider.GetComponent<Key>().OnPressKey(hit.collider);
                        }
                    }
                    else if (!ActivationAction.Value && isPressing)
                    {
                        isPressing = false;
                    }
                }
            }
        }
        //Currently not used.
        else
        {
            if (Physics.Raycast(follow.position, follow.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (ActivationAction.Value && !isPressing)
                {
                    Debug.Log("Shot");
                    Debug.Log(hit.point);
                    Debug.Log(hit.collider.tag);
                    isPressing = true;
                    if (hit.collider.tag == "Targets")
                    {
                        Debug.Log("Did Hit");
                        if (hit.collider.GetComponent<Hit>() != null)
                        {
                            hit.collider.GetComponent<Hit>().TargetHit(hit.collider);
                        }
                    }
                }
                else if (!ActivationAction.Value && isPressing)
                {
                    isPressing = false;
                }
            }
        }
    }
}
