using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript instance;

    public Animator transition;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transition = GetComponentInChildren<Animator>();
    }

    public void Load(Scenes sceneIndex)
    {
        StartCoroutine(LoadTransition((int)sceneIndex));
    }

    //Coroutine for the scene transition
    IEnumerator LoadTransition(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}

//Scene enum with index numbers
public enum Scenes
{
    MainMenu = 0,

    Game = 1,
}
