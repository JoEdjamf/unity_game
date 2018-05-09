using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDirection : MonoBehaviour, Detecteur
{
    public Direction? DetectDirection()
    {

        if (Input.GetKeyUp(KeyCode.UpArrow))
            return Direction.Haut;
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            return Direction.Bas;
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            return Direction.Droite;
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            return Direction.Gauche;
        else
            return null;

    }
}

