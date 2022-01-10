using System;
using System.Collections;
using Interfaces;
using UnityEngine.SceneManagement;

namespace BaseCode
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if(SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var loadScene = SceneManager.LoadSceneAsync(sceneName);
            while (!loadScene.isDone)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}
