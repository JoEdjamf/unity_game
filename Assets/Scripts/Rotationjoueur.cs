using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationjoueur : MonoBehaviour {

    private Vector3 moventDirection = Vector3.zero;
    public float gravite = 20f;
    private CharacterController control;
    private Animator anime;

    public float vitessesaut = 8.0f;
    public float vitesse = 6.0f;
    public Transform JoueurGO;

    bool surterrainglissant;


    Detecteur insertDetecteur = null;

    // Use this for initialization
    void Start()
    {
        moventDirection = transform.forward;
        moventDirection = transform.TransformDirection(moventDirection);
        moventDirection *= vitesse;

        Manage.Instance.Scoreazero();
        Manage.Instance.SetStatus(Constantes.tappepourdebStatus);

        Jeumanage.Instance.Etatjeu = Etatjeu.Debut;

        anime = JoueurGO.GetComponent<Animator>();
        insertDetecteur = GetComponent<Detecteur>();
        control = GetComponent<CharacterController>();
    }

    // lamise à jour est appelée une fois par image
    void Update()
    {
        switch (Jeumanage.Instance.Etatjeu)
        {
            case Etatjeu.Debut:
                if (Input.GetMouseButtonUp(0))
                {
                    anime.SetBool(Constantes.DebutAnimation, true);
                    var instance = Jeumanage.Instance;
                    instance.Etatjeu = Etatjeu.Joue;

                    Manage.Instance.SetStatus(string.Empty);
                }
                break;
            case Etatjeu.Joue:
                Manage.Instance.ajourScore(0.001f);

                CheckHeight();

                Detectsautoubalayegauchedroite();

                //application de la gravité
                moventDirection.y -= gravite * Time.deltaTime;
                //deplace le joueur
                control.Move(moventDirection * Time.deltaTime);

                break;
            case Etatjeu.Mort:
                anime.SetBool(Constantes.DebutAnimation, false);
                if (Input.GetMouseButtonUp(0))
                {
                    //recommence
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            default:
                break;
        }

    }

    private void CheckHeight()
    {
        if (transform.position.y < -10)
        {
            Jeumanage.Instance.Meurt();
        }
    }

    private void Detectsautoubalayegauchedroite()
    {
        var insertDirection = insertDetecteur.DetectDirection();
        if (control.isGrounded && insertDirection.HasValue && insertDirection == Direction.Haut)
        {
            moventDirection.y = vitessesaut;
            anime.SetBool(Constantes.Animationsaut, true);
        }
        else
        {
            anime.SetBool(Constantes.Animationsaut, false);
        }


        if (Jeumanage.Instance.peutbalayer && insertDirection.HasValue &&
         control.isGrounded && insertDirection == Direction.Droite)
        {
            transform.Rotate(0, 90, 0);
            moventDirection = Quaternion.AngleAxis(90, Vector3.up) * moventDirection;
            //allow the user to swipe once per swipe location
            Jeumanage.Instance.peutbalayer = false;
        }
        else if (Jeumanage.Instance.peutbalayer && insertDirection.HasValue &&
         control.isGrounded && insertDirection == Direction.Gauche)
        {
            transform.Rotate(0, -90, 0);
            moventDirection = Quaternion.AngleAxis(-90, Vector3.up) * moventDirection;
            Jeumanage.Instance.peutbalayer = false;
        }


    }


}
