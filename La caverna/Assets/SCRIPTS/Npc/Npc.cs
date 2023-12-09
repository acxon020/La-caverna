    
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class Npc : MonoBehaviour
{
    [SerializeField] private GameObject marcadedialogo;
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TMP_Text dialoguetext; 
    [SerializeField, TextArea(4, 6)] private string[] dialoguelines;

    private bool isPlayerInRanger;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
   
    

    
    void Update()
    {
        if (isPlayerInRanger && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                Startdialogue();
            }
            else if (dialoguetext.text == dialoguelines[lineIndex]) 
            {
                Nextdialogueline();
            }
            else
            {
                StopAllCoroutines();
                dialoguetext.text = dialoguelines[lineIndex];
            }

        }
        

    }
    private void Startdialogue()
    {
        didDialogueStart = true;
        dialoguepanel.SetActive(true);
        marcadedialogo.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(Showline());
        
    }
    private void Nextdialogueline()
    {
        lineIndex++;
        if(lineIndex < dialoguelines.Length)
        {
            StartCoroutine(Showline());
        }
        else
        {
            didDialogueStart=false;
            dialoguepanel.SetActive(false);
            marcadedialogo.SetActive(!true);
            Time.timeScale=1f;
        }
    }
    private IEnumerator Showline()
    {
        dialoguetext.text = string.Empty;

        foreach (char ch in dialoguelines[lineIndex]) 
        {
            dialoguetext.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        isPlayerInRanger = true;
        marcadedialogo.SetActive(true);
        Debug.Log("si se puede interacuar");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        isPlayerInRanger = false;
        marcadedialogo.SetActive(false);
        Debug.Log("no se puede interacuar");
    }
}

