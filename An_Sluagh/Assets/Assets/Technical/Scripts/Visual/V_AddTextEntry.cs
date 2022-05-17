using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class V_AddTextEntry : MonoBehaviour
{
    private static V_AddTextEntry _instance;
    public static V_AddTextEntry Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }




    private bool shouldShutDown = false;
    private void ShutdownProcedure()
    {
        shouldShutDown = true;
    }


    private bool shouldSpeedUp()
    {

        if (coroutineQueue.Count > 0)
        {
            return true;
        }
        else
            return false;

    }


    [SerializeField]
    private float typingSpeed = 0.1f;

    private float getScrollSpeed()
    {
        if (shouldSpeedUp())
        {
            //fast speed: 0.01
            return 0.01f;
        }
        else
        {
            //slow speed: 
            return typingSpeed;
        }
    }


    [SerializeField]
    private GameObject textEntryPrefab;

    [SerializeField]
    private GameObject view;
    [SerializeField]
    private ScrollRect scroll;

    public void CreateTextEntry(string text = "\n")
    {
        if (runningCoroutine == null)
        {
            runningCoroutine = WriteText(text);
            StartCoroutine(runningCoroutine);
        }
        else
        {
            coroutineQueue.Enqueue(WriteText(text));
        }
    }

    public void LogError(string text)
    {
        string errorMessage = "Error:\n" + text;

        if (runningCoroutine == null)
        {
            runningCoroutine = WriteText(errorMessage);
            StartCoroutine(runningCoroutine);
        }
        else
        {
            coroutineQueue.Enqueue(WriteText(errorMessage));
        }
    }


    IEnumerator runningCoroutine = null;
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();



    IEnumerator WriteText(string text)
    {

        // Creates a new text entry and places it within the scroll view
        GameObject entry = Instantiate(textEntryPrefab, view.transform);
        // Gets the Text Component and sets the text to blank, to ensure the object is the correct size
        TextMeshProUGUI textBox = entry.GetComponent<TextMeshProUGUI>();
        textBox.text = "<color=#00000000>" + text + "</color>";

        // Resets the scroll view to the bottom for the new text
        ScrollToBottomRect();

        //Loops over each character, adding in colour tags to slowly display the text letter by letter
        for (int i = 0; i < text.Length + 1; i++)
        {
            ScrollToBottomRect();
            if (i != text.Length)
            {
                string outputTextWithStartTag = text.Insert(i, "<color=#00000000>");
                string outputText = outputTextWithStartTag.Insert(outputTextWithStartTag.Length, "</color>");
                yield return new WaitForSeconds(getScrollSpeed());
                A_Terminal_Manager.Instance.PlayTextTyping();
                textBox.text = outputText;
                if (shouldShutDown)
                {
                    yield break;
                }
            }
            else
            {
                yield return new WaitForSeconds(getScrollSpeed());
                textBox.text = text;
            }
        }
        //Starts the next coroutine
        StartNewEntry();
        yield return null;
    }










    //Starts the next coroutine if one is queued
    private void StartNewEntry()
    {
        runningCoroutine = null;
        if (coroutineQueue.Count > 0)
        {
            runningCoroutine = coroutineQueue.Dequeue();
            StartCoroutine(runningCoroutine);
        }
    }

    //resets the scroll view to the bottom when called
    private void ScrollToBottomRect()
    {
        scroll.verticalNormalizedPosition = 0;
    }












    //print sample text if box is ticked in editor

    [TextArea]
    [SerializeField]
    private string ipsum;
    [SerializeField]
    private bool printIpsum;
    private void Start()
    {
        GL_Event_Manager.Instance.onTerminalShutdown += ShutdownProcedure;
        if (printIpsum)
        {
            for (int i = 0; i < 100; i++)
            {
                CreateTextEntry(i + ipsum);
            }
        }
    }






}
