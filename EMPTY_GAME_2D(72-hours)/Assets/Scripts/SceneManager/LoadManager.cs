using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 0.5f;

    public static LoadManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitGame();
        }
    }
    public void LoadNextLevelGame()
    {
        StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }


    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }


    IEnumerator LoadTransition(int p_levelIndex)
    {
        _transition.SetTrigger("StartTransition");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(p_levelIndex);
    }
}
