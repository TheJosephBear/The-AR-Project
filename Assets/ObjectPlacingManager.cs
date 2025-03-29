using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectPlacingManager : MonoBehaviour {

    public TextMeshProUGUI uiText;
    public GameObject prefab;
    TrackedImagesManager _trackedImagesManager;

    List<GameObject> spawnedCubes = new List<GameObject>();
    Dictionary<string, GameObject> _spawnedPrefabs = new Dictionary<string, GameObject>();

    void Awake() {
        _trackedImagesManager = FindAnyObjectByType<TrackedImagesManager>();
    }

    void Update() {
        PlaceCubesOnCards();
    }

    void PlaceCubesOnCards() {
        Dictionary<string, ARTrackedImage> trackedImages = _trackedImagesManager.GetTrackedImages();

        foreach (var kvp in trackedImages) {
            string imageName = kvp.Key;
            ARTrackedImage trackedImage = kvp.Value;

            if (!_spawnedPrefabs.ContainsKey(imageName)) {
                GameObject newPrefab = Instantiate(prefab, trackedImage.transform.position, trackedImage.transform.rotation);
                _spawnedPrefabs[imageName] = newPrefab;
            } else {
                GameObject existingPrefab = _spawnedPrefabs[imageName];
                existingPrefab.transform.position = trackedImage.transform.position;
                existingPrefab.transform.rotation = trackedImage.transform.rotation;
             //   existingPrefab.SetActive(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking);
            }

        }
        string textus = "";
        foreach (var kvp in trackedImages) {
            textus += kvp.Value.name + "\n";
        }
        uiText.text = textus;

    }
}
