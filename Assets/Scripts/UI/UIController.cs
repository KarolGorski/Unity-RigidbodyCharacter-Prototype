using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField]
    private GameView GameView;
    public GameView gameView { get { return GameView; } }
}
