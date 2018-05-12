using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
namespace Assets.Scripts
{
    public interface Detecteur
    {
        Direction? DetectDirection();
    }
    public enum Direction
    {
        Gauche, Droite, Haut, Bas
    }
}
