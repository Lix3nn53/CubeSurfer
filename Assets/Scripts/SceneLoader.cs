using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
  [SerializeField] private GameObject loadingScreen;
  [SerializeField] private Slider slider;
  [SerializeField] private TMP_Text percentText;

  public void Load(int sceneIndex)
  {
    StartCoroutine(LoadAsynchronously(sceneIndex));
  }

  IEnumerator LoadAsynchronously(int sceneIndex)
  {
    if (loadingScreen != null)
    {
      loadingScreen.SetActive(true);
    }

    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    while (!operation.isDone)
    {
      // Loading = 0 - 0.9
      // Activation = 0.9 - 1.0
      float progress = Mathf.Clamp01(operation.progress / 0.9f);

      if (slider != null)
      {
        slider.value = progress;
      }
      if (percentText != null)
      {
        percentText.text = progress * 100f + "%";
      }

      float percent = Mathf.Lerp(0, 100, progress);

      Debug.Log(progress);
      Debug.Log(percent);
      yield return null;
    }
  }
}
