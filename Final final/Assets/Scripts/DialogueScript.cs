using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    public TextMeshPro textComponent;
    public GameObject UIHabilidad;
    public string[] lines;
    public float textSpeed;
    private int index;
    private int dialogueNum;
    static public bool canSkill;

    
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && teclaEScript.dialogo == true )
        {
            dialogueNum ++;
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (dialogueNum >= 8)
        {
            canSkill = true;
        }

        if (canSkill == true)
        {
            UIHabilidad.SetActive(true);
        }
        else
        {
            UIHabilidad.SetActive(false);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
