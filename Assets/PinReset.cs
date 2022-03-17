using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinReset : MonoBehaviour   
{
    private Pin[] pins;
    private Vector3[] positions;
    private Quaternion[] rotations;

    protected void Awake()
    {
        pins = GetComponentsInChildren<Pin>();
        SavePositions();
    }

    public void SavePositions()
    {
        positions = new Vector3[pins.Length];
        rotations = new Quaternion[pins.Length];
        for (int i=0; i<pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
            rotations[i] = pins[i].transform.rotation;
        }
    }

    public void ResetPositions()
    {
        for(int i=0; i<pins.Length; i++)
        {
            pins[i].transform.position = positions[i];
            pins[i].transform.rotation = rotations[i];
            pins[i].CancelToppleCheck();
            Rigidbody pinRigidbody = pins[i].GetComponent<Rigidbody>();
            pinRigidbody.velocity = Vector3.zero;
            pinRigidbody.angularVelocity = Vector3.zero;
            pins[i].gameObject.SetActive(true);
        }
    }
}
