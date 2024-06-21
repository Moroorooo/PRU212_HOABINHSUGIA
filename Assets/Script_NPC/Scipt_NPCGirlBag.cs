using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scipt_NPCGirlBag : MonoBehaviour
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
        string question = @"Tại sao việc đọc sách lại quan trọng đối với sự phát triển của trẻ em? 
A. Vì đọc sách giúp trẻ em giải trí và không buồn chán.
B. Vì đọc sách giúp trẻ em phát triển ngôn ngữ, trí tưởng tượng và khả năng tư duy.
C. Vì đọc sách là một hoạt động mà tất cả trẻ em đều phải làm theo quy định của nhà trường.";

        string[] answers = {
        "Vì đọc sách giúp trẻ em giải trí và không buồn chán.",
        "Vì đọc sách giúp trẻ em phát triển ngôn ngữ, trí tưởng tượng và khả năng tư duy.",
        "Vì đọc sách là một hoạt động mà tất cả trẻ em đều phải làm theo quy định của nhà trường."
    };

        correctAnswer = answers[1]; // Chỉ định câu trả lời đúng ở đây

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
            dialogueText.text = "Mặc dù không hoàn toàn đúng nhưng vẫn có thể chấp nhận được.";
        }

        contButton.SetActive(true); // Hiển thị nút "Tiếp tục" sau khi kiểm tra câu trả lời
        HideButtons();
    }

}
