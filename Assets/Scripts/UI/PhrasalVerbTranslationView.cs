using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhrasalVerbTranslationView : MonoBehaviour {
    private void Start() {
        PhrasalVerbsDB phrasalVerbsDB = PhrasalVerbsDB.GetInstanceComponent();
        GetComponent<Text>().text = phrasalVerbsDB.ChosenPhrasalVerbTranslation;
    }
}
