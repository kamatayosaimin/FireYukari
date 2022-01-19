using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadScene(string sceneName)
    {
        AsyncOperation load = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        gameObject.SetActive(true);

        StartCoroutine(LoadState(load));
    }

    IEnumerator LoadState(AsyncOperation load)
    {
        while (true)
        {
            _slider.value = load.progress;

            yield return null;
        }
    }
}
