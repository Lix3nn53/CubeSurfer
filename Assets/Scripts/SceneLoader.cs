using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void Load(int sceneIndex)
  {
    StartCoroutine(LoadAsynchronously(sceneIndex));
  }

  IEnumerator LoadAsynchronously(int sceneIndex)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    while (!operation.isDone)
    {
      float progress = Mathf.Clamp01(operation.progress / 0.9f);
      Debug.Log(progress);
      yield return null;
    }
  }
}
