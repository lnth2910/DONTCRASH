using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHanlder : MonoBehaviour
{
   [SerializeField] float levelLoadDelay = 1f;
   [SerializeField] ParticleSystem crashParticals;
   [SerializeField] ParticleSystem successParticals;

   bool isTransition = false;
   bool isCollision = false;
   bool isDie = false;


   void Update()
   {
    if(Input.GetKeyDown(KeyCode.L))
    {
        LoadNextLevel();
    }
    else if(Input.GetKeyDown(KeyCode.C))
    {
        isCollision = !isCollision; //Toggle Collision
    }

   }

   void OnCollisionEnter(Collision other)
   {
    if (isTransition || isCollision ) { return; }
    switch (other.gameObject.tag)
    {
        case "Friendly":
        
            Debug.Log("This thing is friendly");
            break;
        
        case "Finish":
        
            StarFinishSequence();
            break;
        
        case "Fuel":
       
            Debug.Log("You got Fuel");
            break;
        
        default:
            StarCrashSequence();
            break;
    }
   }

   public void StarCrashSequence()
   {
    isTransition = true;
    GetComponent<Movement>().enabled=false;
    if(!isDie)
    {
        crashParticals.Play();
        isDie = true;
    }
    Invoke("ReloadLevel",levelLoadDelay);
   }

   void StarFinishSequence()
   {
    isTransition=true;
    GetComponent<Movement>().enabled=false;
    successParticals.Play();
    Invoke("LoadNextLevel",levelLoadDelay);
   }

   void LoadNextLevel()
   {
    int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
    int nextLevelIndex = currentScenceIndex + 1;
      Debug.LogError(nextLevelIndex + " "+ SceneManager.sceneCountInBuildSettings.ToString());
    if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
    {
        nextLevelIndex=0;
      
    }
    SceneManager.LoadScene(nextLevelIndex); 
   }

   void ReloadLevel()
   {
    int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentScenceIndex); 
   }
}
