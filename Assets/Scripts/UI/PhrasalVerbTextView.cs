using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhrasalVerbTextView : MonoBehaviour {
    private void Start() {
        PhrasalVerbsDB phrasalVerbsDB = PhrasalVerbsDB.GetInstanceComponent();
        GetComponent<Text>().text = phrasalVerbsDB.ChosenphrasalVerbName;
    }
}
