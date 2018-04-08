using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{

    public void LoadMainScene(int difficult)
    {
        GlobalGameState.ChangeDifficult(difficult);

        SceneManager.LoadScene("OpenWorld", LoadSceneMode.Single);
    }

}
