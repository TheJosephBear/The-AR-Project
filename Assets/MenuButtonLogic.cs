using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuButtonLogic : MonoBehaviour {

    public TextMeshProUGUI scanningInfoText;

    public void OnStartScan() {
        GameManager.Instance.SetGamePhase(GamePhase.Scanning);
    }

    public void OnPlaceMap() {
        GameManager.Instance.SetGamePhase(GamePhase.Scanning);
    }

    void Update() {
        if (GameManager.Instance.GetGamePhase() == GamePhase.Scanning) {
            scanningInfoText.text = ScanningManager.Instance.GetScanningData();
        }
    }
}
