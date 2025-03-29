using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImagesManager : MonoBehaviour {
    private ARTrackedImageManager _trackedImagesManager;
    private Dictionary<string, ARTrackedImage> _trackedImages = new Dictionary<string, ARTrackedImage>();

    void Awake() {
        _trackedImagesManager = FindAnyObjectByType<ARTrackedImageManager>();
    }

    private void OnEnable() {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable() {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        foreach (var trackedImage in eventArgs.added) {
            _trackedImages[trackedImage.referenceImage.name] = trackedImage;
        }

        foreach (var trackedImage in eventArgs.updated) {
            _trackedImages[trackedImage.referenceImage.name] = trackedImage;
        }

        foreach (var trackedImage in eventArgs.removed) {
            _trackedImages.Remove(trackedImage.referenceImage.name);
        }
    }

    public Dictionary<string, ARTrackedImage> GetTrackedImages() {
        return _trackedImages;
    }
}
