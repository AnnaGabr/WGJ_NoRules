using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hurting : MonoBehaviour
{
    public GameObject player;
    private float minDist = 0.5f;
    public DialogueObject dialogue;
    private AudioManager audioManager;
    private bool interactionFlag;
    public Sprite interactionImage;
    public Sprite nonInteractionImage;
    private bool lifeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.x - player.transform.position.x) < minDist && Math.Abs(transform.position.y - player.transform.position.y) < minDist)
        {
            interactionFlag = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<DialogueUI>().ShowDialogue(dialogue);
                audioManager.PlayAudio(2, 0.5f);
                lifeFlag = !lifeFlag;
                doSomething(lifeFlag);
            }
        }
        else
        {
            interactionFlag = false;
        }
        interactionImg(interactionFlag);
    }

    private void interactionImg(bool activ)
    {
        if (activ)
        {
            GetComponent<SpriteRenderer>().sprite = interactionImage;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = nonInteractionImage;
        }
    }

    private void doSomething(bool flag)
    {
        if (flag)
        {
            FindObjectOfType<PlayerController>().TakeDamage(1);
        }
    }
}
