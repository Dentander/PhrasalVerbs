using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhrasalVerbsList : MonoBehaviour {
    [SerializeField] private GameObject _button;
    [SerializeField] private Transform _container;

    private PhrasalVerbsDB _db;

    void Start() {
        _db = PhrasalVerbsDB.GetInstanceComponent();

        foreach (var item in _db.PhrasalVerbInfoItems) {
            GameObject button = Instantiate(_button);
            button.transform.SetParent(_container);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.GetComponent<PhrasalVerbsListButton>().PhrasalVerb = item;
        }
    }
}
