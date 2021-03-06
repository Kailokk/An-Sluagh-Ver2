using UnityEngine;

public class GL_Parser : MonoBehaviour
{
    private static GL_Parser _instance;
    public static GL_Parser Instance { get { return _instance; } }
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
    private AS_DictionaryScript dictionary;


    public void ParseUserInput(string input)
    {
        string[] inputArray = input.ToLower().Split(' ');

        if (inputArray.Length >= 2)
        {
            if (FindInteractionInObjects(inputArray))
            {
                return;
            }

            if (FindInteractionInEntrances(inputArray))
            {
                Debug.Log("Interaction Found In Entrance");
                return;
            }
        }
        foreach (AS_ActionsScript action in dictionary.Dictionary)
        {
            foreach (string actionWord in action.actionWords)
            {
                if (inputArray[0] == actionWord.ToLower())
                {
                    action.Interaction();
                    return;
                }
            }
        }
        ///error,input not recognised
        Debug.LogWarning("No Action Found In Dictionary");
        V_AddTextEntry.Instance.LogError("No action or keyword found currently");
    }


    //function to check if any objects have interactions that match the input

    private bool FindInteractionInObjects(string[] input)
    {
        //Cycles over every object in the room 
        foreach (AS_ObjectScript objects in GL_GameController.Instance.objectsInRoom)
        {
            //checks to see if the first or second entry matches any words ascribed to that object
            foreach (string objectName in objects.keywords)
            {
                if (objectName.ToLower() == input[1])
                {
                    //checks if any interactions in the object matches
                    foreach (AS_InteractionScript interaction in objects.Interactions)
                    {
                        foreach (string actionWord in interaction.actionWords)
                        {
                            if (actionWord.ToLower() == input[0].ToLower())
                            {
                                interaction.Interaction(objects);
                                return true;
                            }
                        }
                    }
                    V_AddTextEntry.Instance.LogError("No keyword found");
                    return true;
                }
            }
        }
        return false;
    }


    private bool FindInteractionInEntrances(string[] input)
    {
        foreach (AS_EntranceScript entrance in GL_GameController.Instance.entrancesInRoom)
        {
            foreach (string entranceName in entrance.keywords)
            {
                if (entranceName.ToLower() == input[1].ToLower())
                {
                    foreach (AS_InteractionScript interaction in entrance.interactions)
                    {
                        foreach (string actionWord in interaction.actionWords)
                        {
                            if (input[0].ToLower() == actionWord.ToLower())
                            {
                                interaction.Interaction(entrance);
                                return true;
                            }
                        }
                    }
                    V_AddTextEntry.Instance.LogError("No keyword found");
                    return true;
                }
            }
        }
        return false;
    }







}
