#if UNITY_EDITOR

using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Assets.scripts.Helpers
{
    [InitializeOnLoad]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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