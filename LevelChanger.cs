using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    public string LevelToLoad
    {
        get { return levelToLoad; }
        set
        {
            levelToLoad = value;
        }
    }

    [SerializeField] private string levelToLoad;



    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}  
