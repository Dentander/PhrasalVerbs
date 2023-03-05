using UnityEngine;


public class VerbInstanceButton : MonoBehaviour {
    private PlaneMarker _planeMarker;
    private GameObject _lastPhaselVerb;
    private PhrasalVerbsDB _db;

    private void Start() {
        _planeMarker = FindObjectOfType<PlaneMarker>();
        _db = PhrasalVerbsDB.GetInstanceComponent();
    }

    private void InstanceVerb() {
        _lastPhaselVerb = Instantiate(_db.ChosenPhrasalVerbModel, _planeMarker.MarkerPosition, _db.ChosenPhrasalVerbModel.transform.rotation);
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
