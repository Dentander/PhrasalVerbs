using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlaneMarker : MonoBehaviour {
    [SerializeField] private GameObject _planeMarker;

    private ARRaycastManager _ARRaycastManager;
    private bool _markerEnabled = true;

    public bool MarkerEnabled {
        set { _markerEnabled = value; }
        get { return _markerEnabled; }
    }
    public Vector3 MarkerPosition {
        get { return _planeMarker.transform.position; }
    }

    private void Start() {
        _ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    private Vector2 GetScreenCenter() {
        return new Vector2(Screen.width, Screen.height) * 0.5f;
    }

    private List<ARRaycastHit> GetHitObjects() {
        List<ARRaycastHit> hitObjects = new List<ARRaycastHit>();
        _ARRaycastManager.Raycast(GetScreenCenter(), hitObjects, TrackableType.Planes);
        return hitObjects;
    }

    private void UpdateMarker() {
        _planeMarker.SetActive(_markerEnabled);

        var hitObjects = GetHitObjects();
        if (hitObjects.Count > 0) {
            _planeMarker.transform.position = hitObjects[0].pose.position;
            _planeMarker.transform.position += new Vector3(0, -0.2f, 0);
        }
    }

    private void Update() {
        UpdateMarker();
    }
}
