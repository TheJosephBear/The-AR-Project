using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomConsole : MonoBehaviour {
    public static CustomConsole Instance;
    public TextMeshProUGUI consoleText;
    private string log = "";

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void Print(string message) {
        log += message + "\n";
        consoleText.text = log;
        Debug.Log(message); // Also prints to Unity console
    }
}
