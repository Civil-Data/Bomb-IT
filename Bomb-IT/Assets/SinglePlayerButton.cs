using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerButton : MonoBehaviour
{
    public Button singlePlayerButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = singlePlayerButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
