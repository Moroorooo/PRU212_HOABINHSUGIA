using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChildGirl : MonoBehaviour
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
            if (dialoguePanel != null && dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                if (dialoguePanel != null)
                {
                    dialoguePanel.SetActive(true);
                }
                StartCoroutine(Typing());
                ShowButtons();
                ShowQuestion();
            }
        }
    }

    public void zeroText()
    {
        if (dialogueText != null)
        {
            dialogueText.text = "";
        }
        index = 0;
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
        HideButtons();
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            if (dialogueText != null)
            {
                dialogueText.text += letter;
            }
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (contButton != null)
        {
            contButton.SetActive(false);
        }
        if (index < dialogue.Length - 1)
        {
            index++;
            if (dialogueText != null)
            {
                dialogueText.text = "";
            }
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
        if (button1 != null)
        {
            button1.SetActive(true);
        }
        if (button2 != null)
        {
            button2.SetActive(true);
        }
        if (button3 != null)
        {
            button3.SetActive(true);
        }
    }

    private void HideButtons()
    {
        if (button1 != null)
        {
            button1.SetActive(false);
        }
        if (button2 != null)
        {
            button2.SetActive(false);
        }
        if (button3 != null)
        {
            button3.SetActive(false);
        }
    }

    private void ShowQuestion()
    {
        string question = @"Xin chào! Bạn có thể giúp mình với một bài toán không? Nếu mình có 3 quả táo và bạn của mình tặng thêm cho mình 2 quả táo nữa, thì mình sẽ có bao nhiêu quả táo tất cả?
A. 4 quả táo
B. 5 quả táo
C. 6 quả táo";

        string[] answers = {
            "4 quả táo",
            "5 quả táo",
            "6 quả táo"
        };

        correctAnswer = answers[1]; // Đáp án đúng là "5 quả táo"

        if (dialogueText != null)
        {
            dialogueText.text = question;
        }

        if (button1Text != null)
        {
            button1Text.text = answers[0];
        }
        if (button2Text != null)
        {
            button2Text.text = answers[1];
        }
        if (button3Text != null)
        {
            button3Text.text = answers[2];
        }
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (dialogueText != null)
        {
            if (selectedAnswer == correctAnswer)
            {
                dialogueText.text = "Đúng rồi! Vì 3 quả táo ban đầu cộng thêm 2 quả táo nữa sẽ bằng 5 quả táo.";
            }
            else
            {
                dialogueText.text = "Mặc dù không đúng lắm nhưng cảm ơn bạn.";
            }
        }

        if (contButton != null)
        {
            contButton.SetActive(true);
        }
        HideButtons();
    }
}
