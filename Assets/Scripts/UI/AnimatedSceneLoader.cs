using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimatedSceneLoader : MonoBehaviour {
    private static GameObject _instance = null;

    private void Start() {
        Application.targetFrameRate = 120;
        if (_instance is null) {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
    }

    private void LoadSceneSingleton(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(string sceneName) {
        _instance.GetComponent<AnimatedSceneLoader>().LoadSceneSingleton(sceneName);
    }

    static public void StaticLoadScene(string sceneName) {
        _instance.GetComponent<AnimatedSceneLoader>().LoadSceneSingleton(sceneName);
    }
}
