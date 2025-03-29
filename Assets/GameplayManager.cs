using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public MapPlacementManager mapPlacementManager;

    public void StartGame() {
        Debug.Log("Game Phase Started: Place Map");
        mapPlacementManager.EnablePlacementMode();
    }
}
