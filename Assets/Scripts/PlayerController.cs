using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Movimiento
    public float horizontalInput;
    public float verticalInput;
    public float speed = 2.0f;

    // Vida
    private int life;
    private bool dead = false;
    public Sprite corazonLleno;
    public Sprite corazonVacio;
    public Image[] vidas;
    public DialogueObject loseDialogue;
    private AudioManager audioManager;

    // Animación
    private Animator playerAnimator;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        life = vidas.Length;
        foreach (var vida in vidas)
        {
            vida.sprite = corazonLleno;
        }
        playerAnimator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector2.up * Time.deltaTime * verticalInput * speed);

        movement = new Vector2(horizontalInput, verticalInput).normalized;

        playerAnimator.SetFloat("Horizontal", horizontalInput);
        playerAnimator.SetFloat("Vertical", verticalInput);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if (dead)
        {
            FindObjectOfType<DialogueUI>().ShowDialogue(loseDialogue);
            audioManager.PlayAudio(3, 0.5f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var vida in vidas)
                {
                    vida.sprite = corazonLleno;
                }
                life = vidas.Length;
                if (Input.GetKeyDown(KeyCode.Space)) ;
            }
            dead = false;
        }
        
    }

    public void TakeDamage(int d)
    {
        life -= d;
        vidas[life].sprite = corazonVacio;
        if (life < 1)
        {
            dead = true;
        }

    } 

    public void Heal(int d)
    {
        if (life < 3)
        {
            vidas[life].sprite = corazonLleno;
            life += d;
        }

    }
}
