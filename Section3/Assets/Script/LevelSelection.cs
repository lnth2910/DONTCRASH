using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Image levelImage; // Reference to the Image component that displays the level.
    public Sprite[] levelSprites; // Array of level sprites.
    private int currentLevelIndex = 0; // Current level index.

    // Start is called before the first frame update
    void Start()
    {
        levelImage.sprite = levelSprites[currentLevelIndex];
    }

    void Update()
    {
    
    }

    // Update is called once per frame
    public void NextLevel()
    {
        currentLevelIndex++;
        if(currentLevelIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            currentLevelIndex=0;
        }
        levelImage.sprite = levelSprites[currentLevelIndex];
        Debug.LogError(currentLevelIndex);
    }

    public void PreviousLevel()
    {
        // Change to the previous level.
        currentLevelIndex--;
        if(currentLevelIndex < 0)
        {
            currentLevelIndex = SceneManager.sceneCountInBuildSettings-2;
        }
        levelImage.sprite = levelSprites[currentLevelIndex];
        Debug.Log(currentLevelIndex);
    }

    public void GetScene()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }
}
