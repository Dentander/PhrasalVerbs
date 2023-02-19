using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimatedSceneLoader : MonoBehaviour {
    [SerializeField] private float _animationSeconds;

    private static GameObject _instance = null;
    private Animator _animator;

    private void Start() {
        Application.targetFrameRate = 120;
        if (_instance == null) {
            DontDestroyOnLoad(gameObject);
            _animator = GetComponent<Animator>();
            _instance = gameObject;
        }
    }

    IEnumerator LoadSceneIn(string sceneName) {
        yield return new WaitForSeconds(_animationSeconds);
        SceneManager.LoadScene(sceneName);
    }

    private void LoadSceneSingleton(string sceneName) {
        _animator.SetTrigger("fade");
        StartCoroutine(LoadSceneIn(sceneName));
    }

    public void LoadScene(string sceneName) {
        _instance.GetComponent<AnimatedSceneLoader>().LoadSceneSingleton(sceneName);
    }

    static public void StaticLoadScene(string sceneName) {
        _instance.GetComponent<AnimatedSceneLoader>().LoadSceneSingleton(sceneName);
    }
}
