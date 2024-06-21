using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_NonLa : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject contButton;

    // Thêm các bi?n cho 3 nút b?m
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
        string question = @"Anh nông dân có một ruộng hình chữ nhật có chiều dài là 20 mét và chiều rộng là 15 mét. Diện tích của ruộng là bao nhiêu mét vuông? 
A. 200 mét vuông
B. 300 mét vuông
C. 400 mét vuông";

        string[] answers = {
        "200 mét vuông",
        "300 mét vuông",
        "400 mét vuông"
    };

        correctAnswer = answers[2]; 

        dialogueText.text = question;

        button1Text.text = answers[0];
        button2Text.text = answers[1];
        button3Text.text = answers[2];
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            dialogueText.text = "Đúng rồi! Cảm ơn bạn rất nhiều!";
        }
        else
        {
            dialogueText.text = "Mặc dù không đúng lắm nhưng cảm ơn bạn.";
        }

        contButton.SetActive(true);
        HideButtons();
    }


}
