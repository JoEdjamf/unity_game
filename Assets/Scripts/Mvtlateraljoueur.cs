using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mvtlateraljoueur : MonoBehaviour {


    private Vector3 moventDirection = Vector3.zero;
    public float gravite = 20f;
    private CharacterController control;
    private Animator anime;

    private bool changervoie= false;
    private Vector3 poschangervoie;
    //distance change lateralement
    private Vector3 changervoietDistance = Vector3.right * 2f;

    public float changervoievitesse = 5.0f;

    public float vitessesaut = 8.0f;
    public float vitesse = 6.0f;
    //Max gameobject
    public Transform JoueurGO;

    Detecteur detecteur = null;

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
        detecteur = GetComponent<Detecteur>();
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
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

                //apply gravity
                moventDirection.y -= gravite * Time.deltaTime;

                if (changervoie)
                {
                    if (Mathf.Abs(transform.position.x - poschangervoie.x) < 0.1f)
                    {
                        changervoie = false;
                        moventDirection.x = 0;
                    }
                }

                //move the player
                control.Move(moventDirection * Time.deltaTime);

                break;
            case Etatjeu.Mort:
                anime.SetBool(Constantes.DebutAnimation, false);
                if (Input.GetMouseButtonUp(0))
                {
                    //restart
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
        var insertDirection = detecteur.DetectDirection();
        if (control.isGrounded && insertDirection.HasValue && insertDirection == Direction.Haut
            && !changervoie)
        {
            moventDirection.y = vitessesaut;
            anime.SetBool(Constantes.Animationsaut, true);
        }
        else
        {
            anime.SetBool(Constantes.Animationsaut, false);
        }


        if (control.isGrounded && insertDirection.HasValue && !changervoie)
        {
            changervoie = true;

            if (insertDirection == Direction.Bas)
            {
                poschangervoie = transform.position - changervoietDistance;
                moventDirection.x = -changervoievitesse;
            }
            else if (insertDirection == Direction.Droite)
            {
                poschangervoie = transform.position + changervoietDistance;
                moventDirection.x = changervoievitesse;
            }
        }


    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if we hit the left or right border
        if (hit.gameObject.tag == Constantes.etiquettebordurechemin)
        {
            changervoie = false;
            moventDirection.x = 0;
        }
    }

}
