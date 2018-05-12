using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    //endroits ou les pts vont apparaitre :)
    public Transform[] points;
    //bonus
    public GameObject[] Bonus;
    //obstacles
    public GameObject[] Obstacles;

    public bool xalea = false;
    public float xmin = -2f, xmax = 2f;

    // Use this for initialization
    void Start()
    {
        //decidons si nous allons placer l'obstacle
        //Attention , Random.Range exclusive pour int, inclusive pour floats
        
        bool placedeobstacle = Random.Range(0, 2) == 0; //50% chances
        int Indexdeobstacle = -1;
        if (placedeobstacle)
        {
            //apparation aléatoire d'un point
            //nous ne voulons pas d'obstacle là
            Indexdeobstacle = Random.Range(1, points.Length);

            Creationobjet(points[Indexdeobstacle].position, Obstacles[Random.Range(0, Obstacles.Length)]);
        }


        for (int i = 0; i < points.Length; i++)
        {
            //don't instantiate if there's an obstacle
            if (i == Indexdeobstacle) continue;
            if (Random.Range(0, 3) == 0) //33% chances to create candy
            {
                Creationobjet(points[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
        }


    }

    void Creationobjet(Vector3 position, GameObject fab)
    {
        if (xalea) //true on the wide path, false on the rotated ones
            position += new Vector3(Random.Range(xmin, xmax), 0, 0);

        Instantiate(fab, position, Quaternion.identity);
    }
}
