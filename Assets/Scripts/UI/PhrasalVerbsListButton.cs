using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhrasalVerbsListButton : MonoBehaviour {
    [SerializeField] private Text _buttonText;

    private PhrasalVerbInfoItem _phrasalVerb;

    public PhrasalVerbInfoItem PhrasalVerb {
        get { return _phrasalVerb; }
        set { _phrasalVerb = value; }
    }

    private void Start() {
        _buttonText.text = _phrasalVerb.Verb;
    }

    public void ViewPhrasalVerb() {
        var phrasalVerbsDB = PhrasalVerbsDB.GetInstanceComponent();

        phrasalVerbsDB.ChosenPhrasalVerbItem = _phrasalVerb;
        AnimatedSceneLoader.StaticLoadScene("PhrasalVerbViewer");
    }
}
