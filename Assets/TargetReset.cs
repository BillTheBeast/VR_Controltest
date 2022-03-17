using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReset : MonoBehaviour
{
    private Hit[] targets;
    private Vector3[] positions;
    private Quaternion[] rotations;
    public GeneralLogic gameController;

    // Start is called before the first frame update
    protected void Awake()
    {
        targets = GetComponentsInChildren<Hit>();
        SavePositions();
    }

    public void SavePositions()
    {
        positions = new Vector3[targets.Length];
        rotations = new Quaternion[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            positions[i] = targets[i].transform.parent.position;
            rotations[i] = targets[i].transform.parent.rotation;
        }
    }

    public void ResetPositions()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].transform.parent.position = positions[i];
            targets[i].transform.parent.rotation = rotations[i];
            targets[i].gameObject.SetActive(true);
            targets[i].ResetHealth();
        }
        gameController.TargetReset();
    }
}
