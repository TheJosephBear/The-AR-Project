using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GamePhase CurrentPhase { get; private set; }

    public ScanningManager scanningManager;
    public GameplayManager gameplayManager;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        SetGamePhase(GamePhase.Menu);
    }

    public void SetGamePhase(GamePhase newPhase) {
        CurrentPhase = newPhase;

        switch (newPhase) {
            case GamePhase.Menu:
                Debug.Log("Game in Menu phase.");
                break;

            case GamePhase.Scanning:
                Debug.Log("Starting Scanning phase.");
                ScanningManager.Instance.StartScanning();
                break;

            case GamePhase.RunningGame:
                Debug.Log("Starting Game phase.");
                scanningManager.StopScanning();
                gameplayManager.StartGame();
                break;
        }
    }

    public GamePhase GetGamePhase() {
        return CurrentPhase;
    }
}
public enum GamePhase { Menu, Scanning, RunningGame }
