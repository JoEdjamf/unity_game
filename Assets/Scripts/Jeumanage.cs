using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeumanage : MonoBehaviour {

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }


    private static Jeumanage instance;
    public static Jeumanage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Jeumanage();
            }
            return instance;
        }
    }

    protected Jeumanage()
    {
        Etatjeu = Etatjeu.Debut;
        peutbalayer = false;
    }

    public Etatjeu Etatjeu { get; set; }

    public bool peutbalayer { get; set; }

    public void Meurt()
    {
        Manage.Instance.SetStatus(Constantes.tappepourdebStatusmort);
        this.Etatjeu = Etatjeu.Mort;
    }
}
