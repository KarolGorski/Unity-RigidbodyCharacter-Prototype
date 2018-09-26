using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    [SerializeField]
    Text playerStateText;

    public void SetPlayerStateText(string playerState)
    {
        playerStateText.text = playerState;
    }
}
