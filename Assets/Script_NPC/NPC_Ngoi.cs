using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Ngoi : MonoBehaviour
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
        string question = "Chào Hoa Bình! Anh đang học cách đọc và viết, nhưng anh không có sách. Hoa Bình biết anh nên làm gì không? \n A.Đưa tiền cho người khác để họ giúp anh học.\n B.Tìm sách cũ hoặc tài liệu để tự học. \n C.Bỏ qua việc học vì nó quá khó.";
        string[] answers = { "Đưa tiền cho người khác để họ giúp anh học.", "Tìm sách cũ hoặc tài liệu để tự học.", "Bỏ qua việc học vì nó quá khó." };
        correctAnswer = "Tìm sách cũ hoặc tài liệu để tự học.";

        dialogueText.text = question;

        button1Text.text = answers[0];
        button2Text.text = answers[1];
        button3Text.text = answers[2];
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            dialogueText.text = "Đúng rồi! Nếu bạn có sách hoặc biết nơi nào có sách cũ, điều đó sẽ giúp anh rất nhiều. Cảm ơn bạn rất nhiều!";
        }
        else
        {
            dialogueText.text = "Anh hiểu việc học có thể khó, nhưng không nên từ bỏ. Anh vẫn hy vọng sẽ tìm được cách để học.";
        }

        HideButtons();
    }
}
