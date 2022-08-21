using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinScript : MonoBehaviour
{
    public GameObject player;
    private float minDist = 0.5f;
    public DialogueObject dialogue;
    private AudioManager audioManager;
    private bool interactionFlag;
    public Sprite interactionImage;
    public Sprite nonInteractionImage;
    public Sprite finalImage;
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
                if (!lifeFlag)
                {
                    FindObjectOfType<DialogueUI>().ShowDialogue(dialogue);
                    audioManager.PlayAudio(1, 0.5f);
                }
                lifeFlag = true;

            }
        }
        else
        {
            interactionFlag = false;
        }
        interactionImg(interactionFlag);
        doSomething(lifeFlag);
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
            GetComponent<SpriteRenderer>().sprite = finalImage;
        }
    }
}
