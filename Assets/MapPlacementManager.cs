using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MapPlacementManager : MonoBehaviour
{
    public GameObject mapPrefab;
    public ARRaycastManager raycastManager;
    private GameObject placedMap;
    private bool mapPlaced = false;
    private bool placementMode = false;

    void Awake() {
        raycastManager = FindAnyObjectByType<ARRaycastManager>();
    }

    public void EnablePlacementMode() {
        placementMode = true;
        Debug.Log("Placement mode enabled.");
    }

    private void Update() {
        if (!placementMode || mapPlaced || !Input.GetMouseButtonDown(0)) return;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(Input.mousePosition, hits, TrackableType.Planes)) {
            Pose placementPose = hits[0].pose;
            PlaceMap(placementPose.position, placementPose.rotation);
        }
    }

    public void PlaceMap(Vector3 position, Quaternion rotation) {
        if (placedMap == null) {
            placedMap = Instantiate(mapPrefab, position, rotation);
            mapPlaced = true;
            placementMode = false;
            Debug.Log("Map placed at: " + position);
        }
    }
}
