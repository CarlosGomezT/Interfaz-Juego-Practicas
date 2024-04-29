using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public AudioSource Audio;
    public AudioClip[] ClipsToPlay;
    public string[] lines;
    public float DialogueSpeed;
    private int index;

    private

    void Start()
    {
        TextBox.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            if(TextBox.text == lines[index])
            {
                Audio.Stop();
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextBox.text = lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        StopAllCoroutines();
        Audio.Stop();
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        TextBox.text = lines[index];
        Audio.PlayOneShot(ClipsToPlay[index]);
        yield return new WaitForSeconds(DialogueSpeed);
        NextLine();

    }

    void NextLine()
    {
        if (index < lines.Length-1) 
        {
            index++;
            TextBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
