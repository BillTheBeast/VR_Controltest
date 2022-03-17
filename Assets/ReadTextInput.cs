using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ReadTextInput : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public GameObject inputField;
    public GameObject placeholder;
    public TMP_InputField inputText;
    public FreeMovement freeMovement;

    public bool isEnabled = false;

    public TextCheck textCheck;

    public TestInfo testInfo;

    private int correct = 0;

    public AudioClip correctDing;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        textField.text = inputText.text;
        if (textField.text.Length > 0) placeholder.SetActive(false);
        else placeholder.SetActive(true);

        if (isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (textCheck.CheckText(textField.text))
                {
                    audioSource.PlayOneShot(correctDing, 0.5F);
                    textField.text = "";
                    inputText.text = "";
                    correct++;
                    if (correct >= 3)
                    {
                        testInfo.StopTest();
                    }
                    else
                    {
                        StartCoroutine(Wait());
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) testInfo.AddError();
        }
    }

    public void Enable()
    {
        if (!isEnabled) {
            isEnabled = true;
            correct = 0;
            inputText.text = textField.text;
            //transform.GetChild(0).gameObject.SetActive(true);
            freeMovement.writing = true;
            IEnumerator coroutine = Wait();
            StartCoroutine(coroutine);
            testInfo.StartTest();
        }
    }

    public void Disable()
    {
        if (isEnabled)
        {
            isEnabled = false;
            //transform.GetChild(0).gameObject.SetActive(false);
            IEnumerator coroutine = Wait2();
            StartCoroutine(coroutine);
            freeMovement.writing = false;
            testInfo.StopTest();
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(inputField);
        inputText.text = textField.text;
    }
    private IEnumerator Wait2()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(null);
    }
}
