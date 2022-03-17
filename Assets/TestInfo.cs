using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestInfo : MonoBehaviour
{
    private bool testRunning = false;

    public float startTime = 0.0f;
    public float currentTime = 0.0f;

    public int errors = 0;

    public TextMeshPro timeScreen;
    public TextMeshPro errorScreen;
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (testRunning)
        {
            timeScreen.text = string.Format("{0:#.00}", currentTime - startTime);
            errorScreen.text = errors.ToString();
        }
    }

    public void StartTest() {
        startTime = Time.time;
        errors = 0;

        lights.transform.GetChild(0).gameObject.SetActive(false);
        lights.transform.GetChild(1).gameObject.SetActive(false);
        lights.transform.GetChild(2).gameObject.SetActive(false);

        testRunning = true;
    }

    public void StopTest() {
        testRunning = false;
    }

    public void AddError()
    {
        errors++;
    }

}
