using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
            SceneManager.LoadScene("MainMenu");
    }
}