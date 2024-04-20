using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialoguemanager : MonoBehaviour
{
    
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public GameObject gameVideoUI;
    public GameObject gamedoithoaiUI;
    Message[] currenmessages;
    Actor[] currenActors;
    int activeMessage = 0;
   /* public static bool isActive = false;*/
    public void OpenDialogue(Message[] messages,Actor[] actors)
    {
        currenmessages = messages;
        currenActors = actors;
        activeMessage = 0;
        Debug.Log("đã bắt đầu cuộc chuyện! đã tải tin nhắn: " + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currenmessages[activeMessage];
        messageText.text = messageToDisplay.message;
        Actor actorToDisplay = currenActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
    }
    public void NextMessage()
    {
        activeMessage ++;
        if(activeMessage<currenmessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation eneded!");
            /*isActive = false;*/
            /*  ScenesController.instance.LoadGame();*/
            gamedoithoaiUI.SetActive(false);
            gameVideoUI.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            NextMessage();
        }
    }

}
