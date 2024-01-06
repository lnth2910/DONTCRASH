using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(GetGame);
    }

    // Update is called once per frame
    void GetGame()
    {
        SceneManager.LoadScene("Level_1");
    }
}
