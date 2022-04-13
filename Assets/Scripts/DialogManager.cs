using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogBox;
    public TMP_Text dialogText;

    public string[] dialogLines;

    public int currentLine;

    private bool justStarted;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                    }
                    else
                    {
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else { justStarted = false; }

            }
        }

    }

    public void ShowDialog(string[] newLines)
    {
        dialogLines = newLines;
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
    }

}