using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{

    public void LoadMainScene(int difficult)
    {
        SceneManager.LoadScene("OpenWorld", LoadSceneMode.Single);
    }

}
