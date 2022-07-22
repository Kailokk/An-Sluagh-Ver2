using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GL_SaveData
{
    //Inventory
    public List<string> inventory = new List<string>();

    //Interactions
    public List<string> objectInteractionList = new List<string>();
    public List<string> usedItemList = new List<string>();
    public List<string> EntranceInteractionList = new List<string>();
    

    //Current Room
  public  string currentRoom;


}
