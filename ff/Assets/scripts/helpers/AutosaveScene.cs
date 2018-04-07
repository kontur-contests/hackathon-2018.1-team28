#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;

namespace Assets.scripts.helpers
{
    [InitializeOnLoad]
    public class AutosaveScene
    {
        static AutosaveScene()
        {
            EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
        }

        private static void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
                EditorSceneManager.SaveOpenScenes();
        }
    }
}

#endif