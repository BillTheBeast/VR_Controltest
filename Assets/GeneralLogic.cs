using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// I probably should split this script into two by putting the shooting test code into its own script and just keep the return to menu code here. 

public class GeneralLogic : MonoBehaviour
{
    public int targets = 10;
    private int currentTargets = 10;
    public float startTime = 0.0f;
    public float currentTime = 0.0f;
    public bool timeRunning = false;
    public int shots = 0;
    public TextMeshPro timeScreen;
    public TextMeshPro shotsScreen;
    [Space(15)]
    public GameObject moveTarget1;
    public GameObject moveTarget2;
    public GameObject moveTarget3;
    public GameObject moveTarget4;
    public GameObject moveTarget5;
    public GameObject moveTarget6;

    private int t1Dir = 0;
    private int t2Dir = 0;
    private int t3Dir = 0;
    private int t4Dir = 0;
    private int t5Dir = 0;
    private int t6aDir = 0;
    private int t6bDir = 0;
    [Space(15)]
    public float target1Speed = 2.6f;
    public float target2Speed = 0.6f;
    public float target3Speed = 1.2f;
    public float target4Speed = 2.6f;
    public float target5Speed = 6;
    public float target6SpeedVertical = 3;
    public float target6SpeedHorizontal = 4;

    // Start is called before the first frame update
    void Start()
    {
        currentTargets = targets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(LoadYourAsyncScene());
        }


        currentTime = Time.time;
        if (timeRunning)
        {
            timeScreen.text = string.Format("{0:#.00}",currentTime-startTime);
            shotsScreen.text = shots.ToString();
        }
        Target1Move();
        Target2Move();
        Target3Move();
        Target4Move();
        Target5Move();
        Target6Move();

    }

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main Menu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    public void TargetHit()
    {
        if (!timeRunning && currentTargets > 0)
        {
            startTime = Time.time;
            timeRunning = true;
            shots = 1;
        }
    }

    public void TargetDestroy(Collider collider) 
    {
        collider.gameObject.SetActive(false);
        currentTargets--;
        if (!timeRunning && currentTargets > 0)
        {
            startTime = Time.time;
            timeRunning = true;
            shots = 1;
        }

        if (timeRunning && currentTargets == 0)
        {
            timeRunning = false;
            shotsScreen.text = shots.ToString();
        }

    }

    public void TargetReset()
    {
        currentTargets = targets;
        timeRunning = false;
        startTime = 0.0f;
        shots = 0;
        t1Dir = 0;
        t2Dir = 0;
        t3Dir = 0;
        t4Dir = 0;
        t5Dir = 0;
        t6aDir = 0;
        t6bDir = 0;
    }

    public void ShotTaken()
    {
        if (timeRunning)
            shots++;
    }

    private void Target1Move() 
    {
        if(t1Dir == 0)
        {
            moveTarget1.transform.position += Vector3.left * Time.deltaTime * target1Speed;
        }
        else
        {
            moveTarget1.transform.position += Vector3.right * Time.deltaTime * target1Speed;
        }
        if (moveTarget1.transform.localPosition.x <= -3) t1Dir = 1;
        else if (moveTarget1.transform.localPosition.x >= 3) t1Dir = 0;
    }

    private void Target2Move()
    {
        if (t2Dir == 0)
        {
            moveTarget2.transform.position += Vector3.left * Time.deltaTime * target2Speed;
        }
        else
        {
            moveTarget2.transform.position += Vector3.right * Time.deltaTime * target2Speed;
        }
        if (moveTarget2.transform.localPosition.x <= 0.8f) t2Dir = 1;
        else if (moveTarget2.transform.localPosition.x >= 2) t2Dir = 0;
    }

    private void Target3Move()
    {
        if (t3Dir == 0)
        {
            moveTarget3.transform.position += Vector3.down * Time.deltaTime * target3Speed;
        }
        else
        {
            moveTarget3.transform.position += Vector3.up * Time.deltaTime * target3Speed;
        }
        if (moveTarget3.transform.localPosition.y <= 0.8f) t3Dir = 1;
        else if (moveTarget3.transform.localPosition.y >= 2.2f) t3Dir = 0;
    }

    private void Target4Move()
    {
        if (t4Dir == 0)
        {
            moveTarget4.transform.position += Vector3.up * Time.deltaTime * target4Speed;
        }
        else if (t4Dir == 1)
        {
            moveTarget4.transform.position += Vector3.right * Time.deltaTime * target4Speed;
        }
        else if (t4Dir == 2)
        {
            moveTarget4.transform.position += Vector3.down * Time.deltaTime * target4Speed;
        }
        else if (t4Dir == 3)
        {
            moveTarget4.transform.position += Vector3.left * Time.deltaTime * target4Speed;
        }
        if (moveTarget4.transform.localPosition.y >= 4 && moveTarget4.transform.localPosition.x <= -3.5f) t4Dir = 1;
        else if (moveTarget4.transform.localPosition.y >= 4 && moveTarget4.transform.localPosition.x >= -2.2f) t4Dir = 2;
        else if (moveTarget4.transform.localPosition.y <= 2 && moveTarget4.transform.localPosition.x >= -2.2f) t4Dir = 3;
        else if (moveTarget4.transform.localPosition.y <= 2 && moveTarget4.transform.localPosition.x <= -3.5f) t4Dir = 0;
    }
    private void Target5Move()
    {
        if (t5Dir == 0)
        {
            moveTarget5.transform.position += Vector3.up * Time.deltaTime * target5Speed;
        }
        else if (t5Dir == 1)
        {
            moveTarget5.transform.position += Vector3.left * Time.deltaTime * target5Speed;
        }
        else if (t5Dir == 2)
        {
            moveTarget5.transform.position += Vector3.down * Time.deltaTime * target5Speed;
        }
        else if (t5Dir == 3)
        {
            moveTarget5.transform.position += Vector3.right * Time.deltaTime * target5Speed;
        }
        if (moveTarget5.transform.localPosition.y >= 4 && moveTarget5.transform.localPosition.x >= -1) t5Dir = 1;
        else if (moveTarget5.transform.localPosition.y >= 4 && moveTarget5.transform.localPosition.x <= -9) t5Dir = 2;
        else if (moveTarget5.transform.localPosition.y <= 0.5f && moveTarget5.transform.localPosition.x <= -9) t5Dir = 3;
        else if (moveTarget5.transform.localPosition.y <= 0.5f && moveTarget5.transform.localPosition.x >= -1) t5Dir = 0;
    }
    private void Target6Move()
    {
        if (t6aDir == 0)
        {
            moveTarget6.transform.position += Vector3.up * Time.deltaTime * target6SpeedVertical;
        }
        else if (t6aDir == 1)
        {
            moveTarget6.transform.position += Vector3.down * Time.deltaTime * target6SpeedVertical;
        }
        if (t6bDir == 0)
        {
            moveTarget6.transform.position += Vector3.right * Time.deltaTime * target6SpeedHorizontal;
        }
        else if (t6bDir == 1)
        {
            moveTarget6.transform.position += Vector3.left * Time.deltaTime * target6SpeedHorizontal;
        }
        if (moveTarget6.transform.localPosition.y >= 4) t6aDir = 1;
        else if (moveTarget6.transform.localPosition.y <= 0.5f) t6aDir = 0;
        else if (moveTarget6.transform.localPosition.x >= -1) t6bDir = 1;
        else if (moveTarget6.transform.localPosition.x <= -9) t6bDir = 0;
    }
}
