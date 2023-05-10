using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordGuessGame : MonoBehaviour
{
    // ���� �ܾ� ����Ʈ
    [SerializeField]
    private List<string> words = new List<string>()
    {
        "apple",
        "banana",
        "cherry",
        "orange",
        "pear",
        "pineapple",
        "watermelon"
    };

    // ���� �ܾ� ���̸� ��Ÿ���� �ؽ�Ʈ
    [SerializeField] private Text answerText;
    // ���� �Է��� �޴� ��ǲ �ʵ�
    [SerializeField] private InputField guessInput;
    // ���� ��ư
    [SerializeField] private Button guessButton;
    // ����� ǥ���ϴ� �ؽ�Ʈ
    [SerializeField] private Text resultText;
    //���ھ� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text ScoreText;

    private int score = 0;
    private int scorecnt = 0;
    private float plusescore;

    // ���� ���� �ܾ�
    private string answer;

    void Start()
    {
        // ���� ��ư Ŭ�� �� OnGuessButtonClicked() �޼��� ȣ��
        guessButton.onClick.AddListener(OnGuessButtonClicked);
        // �� ���� ����
        NewGame();
    }

    // �� ���� ����
    private void NewGame()
    {
        // ���� �ܾ� �� �������� ����
        answer = words[Random.Range(0, words.Count)];
        // ���� �ܾ� ���� ǥ��
        answerText.text = "Answer length: " + answer.Length;
        // ��ǲ �ʵ� �ʱ�ȭ
        guessInput.text = "";
        // ��� �ؽ�Ʈ �ʱ�ȭ
        resultText.text = "";
    }

    // ���� ��ư Ŭ�� �� ȣ���
    private void OnGuessButtonClicked()
    {
        // ��ǲ �ʵ忡�� ������ �Է��� ���ڿ�
        string guess = guessInput.text;

        // ������ �ƹ��͵� �Է����� �ʾҴٸ� ���� �޽��� ��� �� ����
        if (string.IsNullOrEmpty(guess))
        {
            resultText.text = "Please enter a guess.";
            return;
        }

        // ������ ������ ���ڿ��� ���� ���ڿ��� ¦���� ���ϰ�
        // ���� ������ ������ ��ġ�� ���
        var result = guess.Zip(answer, (g, a) => g == a ? 1 : 0);

        // ���� ������ ����
        int correctCount = result.Sum();

        // ������ ���߾��ٸ� ���� ����
        if (correctCount == answer.Length)
        {
            resultText.text = "�����!";
            guessButton.interactable = true;
            scorecnt++;
            plusescore = (((Mathf.Pow(1.07f,10))-(Mathf.Pow(1.07f,10+scorecnt))/(1-1.07f)));
            score += (int)plusescore;
            ScoreText.text =score.ToString();
            NewGame();
        }
        else
        {
            resultText.text = "Ʋ�Ⱦ�!";
            NewGame();
        }

        // ������ ������ ���ڿ��� ���� ������ ������ ǥ��
        resultText.text = string.Format("Guess: {0}, Correct: {1}", guess, correctCount);

        // �Է� �ʵ� ����
        guessInput.text = "";
    }

}
