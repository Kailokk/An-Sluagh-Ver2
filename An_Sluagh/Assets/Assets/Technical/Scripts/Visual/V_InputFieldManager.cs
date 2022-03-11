using UnityEngine;
using TMPro;


public class V_InputFieldManager : MonoBehaviour
{
    private static V_InputFieldManager _instance;
    public static V_InputFieldManager Instance { get { return _instance; } }
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

    [SerializeField]
    private TMP_InputField inputField;



    private void Start()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void onEndEdit()
    {
        if (inputField.text == "" || inputField.text == null)
        {
            inputField.Select();
            inputField.ActivateInputField();
            return;
        }

        V_AddTextEntry.Instance.CreateTextEntry(" \n \n");

        Debug.Log(inputField.text);
        RepeatUserCommand();

        //send to parser
        GL_Parser.Instance.ParseUserInput(inputField.text);

        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }






    private void RepeatUserCommand()
    {
        //Checks if the user typed something, and returns if they didnt

        A_Terminal_Manager.Instance.PlayActionConfirmation();

        //test function
        testTerminalShutdown(inputField.text);
        //Takes Their Text, Spits it back out and then clears the field
        string inputText = inputField.text.ToLower();



        inputText = "> " + inputText;
        V_AddTextEntry.Instance.CreateTextEntry(inputText);
    }

    //shuts down the terminal if user types end
    private void testTerminalShutdown(string inputText)
    {
        Debug.Log("Test Terminal Called");
        if (inputText == "end")
        {
            Debug.Log("Shutting Down");
            GL_Event_Manager.Instance.TerminalShutdown();
        }
    }






}
