using System;
using System.Collections;
using UdonSharp;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TpLab.UdonSharpRestorer.Editor
{
    public class Restorer
    {
        static readonly string IsDirtyKey = "TpLab.UdonSharpConfigRestorer.IsDirty";

        [InitializeOnLoadMethod]
        static void OnLoad()
        {
            var isDirty = PlayerPrefs.GetInt(IsDirtyKey);
            if (isDirty > 0)
            {
                PlayerPrefs.DeleteKey(IsDirtyKey);
                EditorCoroutine.Start(ReopenScene());
            }
            EditorApplicationUtility.projectWasLoaded += () =>
            {
                var scene = EditorSceneManager.GetActiveScene();
                if (string.IsNullOrEmpty(scene.path)) return;
                var isSourceDirty = UdonSharpProgramAsset.IsAnyProgramAssetSourceDirty();
                if (isSourceDirty)
                {
                    Log("Restoring...");
                }
                PlayerPrefs.SetInt(IsDirtyKey, Convert.ToInt32(isSourceDirty));
            };
        }

        static IEnumerator ReopenScene()
        {
            yield return new WaitForSeconds(1f);

            var scene = EditorSceneManager.GetActiveScene();
            const int retryCount = 3;
            for (var i = 0; i < retryCount; i++)
            {
                try
                {
                    EditorSceneManager.OpenScene(scene.path);
                    Log("Restored.");
                    yield break;
                }
                catch (Exception)
                {
                }
                yield return new WaitForSeconds(1f);
            }
            LogError("Failed to restore.");
        }

        static void Log(string message)
        {
            Debug.Log($"[<color=#4EC9B0>Restorer</color>] {message}");
        }
        
        static void LogError(string message)
        {
            Debug.LogError($"[<color=#4EC9B0>Restorer</color>] {message}");
        }
    }
}
