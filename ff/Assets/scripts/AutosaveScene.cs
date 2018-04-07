#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class AutosaveScene
{
    static AutosaveScene()
    {
        EditorApplication.playmodeStateChanged = () =>
        {

            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                EditorSceneManager.SaveOpenScenes();
            }
        };
    }
}

#endif