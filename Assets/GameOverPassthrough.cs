using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameOverPassthrough : MonoBehaviour
{
    public GameBehaviour game;

    public abstract void EndGame();
}
