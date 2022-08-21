using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Healing : MonoBehaviour
{
    public GameObject player;
    private float minDist = 0.5f;
    public DialogueObject dialogue;
    private AudioManager audioManager;
    private bool interactionFlag;
    public Sprite interactionImage;
    public Sprite nonInteractionImage;

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
                audioManager.PlayAudio(1, 0.5f);

                FindObjectOfType<PlayerController>().Heal(1);
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
}
