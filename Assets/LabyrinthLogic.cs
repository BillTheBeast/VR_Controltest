using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthLogic : MonoBehaviour
{
    public GameObject arrows;
    public GameObject arrows2;
    public GameObject arrows3;

    public GameObject door;
    public GameObject door2;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    public bool buttonPressed1 = false;
    public bool buttonPressed2 = false;
    public bool buttonPressed3 = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed1) 
        {
            if (buttonPressed2)
            {
                if (buttonPressed3)
                {
                    door.SetActive(false);
                    door2.SetActive(false);
                }
                else
                {
                    arrows.SetActive(false);
                    arrows2.SetActive(false);
                    arrows3.SetActive(true);
                }
            }
            else
            {
                arrows.SetActive(false);
                arrows2.SetActive(true);
                arrows3.SetActive(false);
            }
        }
        else
        {
            arrows.SetActive(true);
            arrows2.SetActive(false);
            arrows3.SetActive(false);
        }
    }

    public void pressButton1()
    {
        buttonPressed1= true;
        light1.SetActive(true);
    }
    public void pressButton2()
    {
        buttonPressed2 = true;
        light2.SetActive(true);
    }
    public void pressButton3()
    {
        buttonPressed3 = true;
        light3.SetActive(true);
    }
}
