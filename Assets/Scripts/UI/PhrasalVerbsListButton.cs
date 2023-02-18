using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhrasalVerbsListButton : MonoBehaviour {
    [SerializeField] private GameObject _phrasalVerbPrefab;
    [SerializeField] private string _phrasalVerbName;
    [SerializeField] private Text _buttonText;

    public GameObject PhrasalVerbPrefab {
        get { return _phrasalVerbPrefab; }
        set { _phrasalVerbPrefab = value; }
    }
    public string PhrasalVerbName {
        get { return _phrasalVerbName; }
        set { _phrasalVerbName = value; }
    }

    private void Start() {
        Init(_phrasalVerbPrefab, _phrasalVerbName);
    }

    public void Init(GameObject _phrasalVerbPrefab, string _phrasalVerbName) {
        PhrasalVerbPrefab = _phrasalVerbPrefab;
        PhrasalVerbName = _phrasalVerbName;
        _buttonText.text = PhrasalVerbName;
    }

    public void ViewPhrasalVerb() {
        var phrasalVerbsDB = PhrasalVerbsDB.GetInstanceComponent();
        phrasalVerbsDB.ChosenPhrasalVerbPrefab = _phrasalVerbPrefab;
        phrasalVerbsDB.ChosenphrasalVerbName = _phrasalVerbName;
        AnimatedSceneLoader.StaticLoadScene("PhrasalVerbViewer");
    }
}
