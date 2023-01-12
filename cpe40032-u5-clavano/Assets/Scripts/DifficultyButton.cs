using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For our difficulty buttons 

public class DifficultyButton : MonoBehaviour
{
    private Button button; // reference for our difficulty buttons

    private GameManager gameManager; // gameManager reference..

    public float difficulty; // To set our preferred difficulty for each difficulty choice in the game..

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); // Gets our button components..
        button.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
        Debug.Log(button.gameObject.name + " was clicked" + " Good Luck!");
    }
}
