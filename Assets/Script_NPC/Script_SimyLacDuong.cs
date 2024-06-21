using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Script_SimyLacDuong : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject contButton;

    // Thêm các biến cho 3 nút bấm
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    private string correctAnswer;

    void Start()
    {
        HideButtons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                ShowButtons();
                ShowQuestion();
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        HideButtons();
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

    private void ShowButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    private void HideButtons()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }

    private void ShowQuestion()
    {
        string question = "When you get lost in the forest, what should you do to easily find your way out? \n A.Follow the stream.\n B.Go deeper into the forest. \n C.Follow animal tracks.";
        string[] answers = { "Follow the stream.", "Go deeper into the forest.", "Follow animal tracks" };
        correctAnswer = "Follow the stream.";

        dialogueText.text = question;

        button1Text.text = answers[0];
        button2Text.text = answers[1];
        button3Text.text = answers[2];
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            dialogueText.text = "Exactly, Have a nice day.";
        }
        else
        {
            dialogueText.text = "Wrong, please choose again";
        }

        HideButtons();
    }
}
