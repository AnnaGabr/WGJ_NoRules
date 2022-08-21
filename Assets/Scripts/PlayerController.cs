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


    // Start is called before the first frame update
    void Start()
    {
        life = vidas.Length;
        foreach (var vida in vidas)
        {
            vida.sprite = corazonLleno;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector2.up * Time.deltaTime * verticalInput * speed);

        if (dead)
        {
            // dead code
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
        vidas[life].sprite = corazonLleno;
        life += d;
    }
}
