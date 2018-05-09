using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Etat
{
    finbalaye,
    debutbalaye
}
public class Detectebalayage : MonoBehaviour,Detecteur

{

    private Etat etat = Etat.finbalaye;
    private Vector2 Pointdebut;
    private DateTime Tpsdebutbalaye;
    private TimeSpan Dureemaxbalaye = TimeSpan.FromSeconds(1);
    private TimeSpan Dureeminbalaye = TimeSpan.FromMilliseconds(100);

    public Direction? DetectDirection()
    {
        if (etat == Etat.finbalaye)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Tpsdebutbalaye = DateTime.Now;
                etat = Etat.debutbalaye;
                Pointdebut = Input.mousePosition;
            }
        }
        else if (etat == Etat.debutbalaye)
        {
            if (Input.GetMouseButtonUp(0))
            {
                TimeSpan Differencetps = DateTime.Now - Tpsdebutbalaye;
                if (Differencetps <= Dureemaxbalaye && Differencetps >= Dureeminbalaye)
                {
                    Vector2 Positionsouris = Input.mousePosition;
                    Vector2 vecteurdedifference = Positionsouris - Pointdebut;
                    float angle = Vector2.Angle(vecteurdedifference, Vector2.right);
                    Vector3 croix = Vector3.Cross (vecteurdedifference, Vector2.right);

                    if (croix.z > 0)
                        angle = 360 - angle;

                    etat = Etat.finbalaye;

                    if ((angle >= 315 && angle < 360) || (angle >= 0 && angle <= 45))
                        return Direction.Droite;
                    else if (angle > 45 && angle <= 135)
                        return Direction.Haut;
                    else if (angle > 135 && angle <= 225)
                        return Direction.Gauche;
                    else
                        return Direction.Bas;
                }
            }
        }
        return null;
    }

}
