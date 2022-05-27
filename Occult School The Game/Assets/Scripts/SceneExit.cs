using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string exitName;
    public Animator animator;
    public LevelChanger levelChanger;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("LastExitName", exitName);
        levelChanger.LevelToLoad = sceneToLoad;
        animator.SetTrigger("FadeOut");
    }

}
