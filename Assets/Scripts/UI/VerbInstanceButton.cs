using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VerbInstanceButton : MonoBehaviour {
    [SerializeField] private GameObject _phrasalVerb=null;
    [SerializeField] private Button _button;

    private PlaneMarker _planeMarker;
    private GameObject _lastPhaselVerb;

    private void Start() {
        _planeMarker = FindObjectOfType<PlaneMarker>();
    }

    private void InstanceVerb() {
        if (_phrasalVerb == null) {
            GameObject prasalVerb = PhrasalVerbsDB.GetInstanceComponent().ChosenPhrasalVerbPrefab;
            _lastPhaselVerb = Instantiate(prasalVerb, _planeMarker.MarkerPosition, prasalVerb.transform.rotation);
        } else {
            _lastPhaselVerb = Instantiate(_phrasalVerb, _planeMarker.MarkerPosition, _phrasalVerb.transform.rotation);
        }
        _planeMarker.MarkerEnabled = false;
    }

    private void ResetPosition() {
        Destroy(_lastPhaselVerb);
        _planeMarker.MarkerEnabled = true;
    }

    public void InstanceVerbOrResetPosition() {
        if (_planeMarker.MarkerEnabled) {
            InstanceVerb();
        } else {
            ResetPosition();
        }
    }
}
