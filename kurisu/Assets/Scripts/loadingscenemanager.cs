using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public float loadDuration = 3f; // finish in 3 seconds
    public string nextSceneName = "MainMenu"; // target scene name

    private void Start()
    {
        StartCoroutine(FakeLoad());
    }

    IEnumerator FakeLoad()
    {
        float elapsed = 0f;

        while (elapsed < loadDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / loadDuration);

            // Ease-out curve for smooth filling
            float progress = Mathf.SmoothStep(0f, 1f, t);

            // Update UI
            progressBar.value = progress;
            progressText.text = "Loading... " + (progress * 100f).ToString("F0") + "%";

            yield return null;
        }

        // Ensure 100% at the end
        progressBar.value = 1f;
        progressText.text = "100%";

        Debug.Log("Loading complete");

        // Load next scene
        SceneManager.LoadScene(nextSceneName);
    }
}

