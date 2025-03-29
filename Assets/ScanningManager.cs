using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ScanningManager : MonoBehaviour {
    public static ScanningManager Instance;
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;
    public GameObject scanningUI;
    private bool isScanning = false;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void StartScanning() {
        isScanning = true;
        scanningUI.SetActive(true);
        Debug.Log("Scanning started...");
    }

    public void StopScanning() {
        isScanning = false;
        scanningUI.SetActive(false);
        Debug.Log("Scanning complete!");
    }

    private void Update() {
        if (!isScanning) return;

        // Check if we have detected enough planes or feature points
        if (planeManager.trackables.count > 0 || pointCloudManager.trackables.count > 50) {
            //   StopScanning();
        }
    }

    public string GetScanningData() {
        return $"planeManager trackables: {planeManager.trackables.count} \n" +
            $"pointCloudManager trackables: {pointCloudManager.trackables.count}";
    }
}
