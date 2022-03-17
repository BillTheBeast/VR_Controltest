using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCheck : MonoBehaviour
{

    public string Text1 = "Saippuakivikauppias";
    public string Text2 = "Irish potato is the toptato.";
    public string Text3 = "According to all known laws of aviation...";

    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckText(string text)
    {
        if(text == Text1)
        {
            lights.transform.GetChild(0).gameObject.SetActive(true);
            return true;
        }
        else if (text == Text2)
        {
            lights.transform.GetChild(1).gameObject.SetActive(true);
            return true;
        }
        else if (text == Text3)
        {
            lights.transform.GetChild(2).gameObject.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}
