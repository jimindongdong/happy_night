using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordGuessGame : MonoBehaviour
{
    // 정답 단어 리스트
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

    // 정답 단어 길이를 나타내는 텍스트
    [SerializeField] private Text answerText;
    // 유저 입력을 받는 인풋 필드
    [SerializeField] private InputField guessInput;
    // 제출 버튼
    [SerializeField] private Button guessButton;
    // 결과를 표시하는 텍스트
    [SerializeField] private Text resultText;
    //스코어 표시 텍스트
    [SerializeField] private Text ScoreText;

    private int score = 0;
    private int scorecnt = 0;
    private float plusescore;

    // 현재 정답 단어
    private string answer;

    void Start()
    {
        // 제출 버튼 클릭 시 OnGuessButtonClicked() 메서드 호출
        guessButton.onClick.AddListener(OnGuessButtonClicked);
        // 새 게임 시작
        NewGame();
    }

    // 새 게임 시작
    private void NewGame()
    {
        // 정답 단어 중 랜덤으로 선택
        answer = words[Random.Range(0, words.Count)];
        // 정답 단어 길이 표시
        answerText.text = "Answer length: " + answer.Length;
        // 인풋 필드 초기화
        guessInput.text = "";
        // 결과 텍스트 초기화
        resultText.text = "";
    }

    // 제출 버튼 클릭 시 호출됨
    private void OnGuessButtonClicked()
    {
        // 인풋 필드에서 유저가 입력한 문자열
        string guess = guessInput.text;

        // 유저가 아무것도 입력하지 않았다면 에러 메시지 출력 후 종료
        if (string.IsNullOrEmpty(guess))
        {
            resultText.text = "Please enter a guess.";
            return;
        }

        // 유저가 추측한 문자열과 정답 문자열을 짝지어 비교하고
        // 맞춘 문자의 개수와 위치를 계산
        var result = guess.Zip(answer, (g, a) => g == a ? 1 : 0);

        // 맞춘 문자의 개수
        int correctCount = result.Sum();

        // 정답을 맞추었다면 게임 종료
        if (correctCount == answer.Length)
        {
            resultText.text = "맞췄어!";
            guessButton.interactable = true;
            scorecnt++;
            plusescore = (((Mathf.Pow(1.07f,10))-(Mathf.Pow(1.07f,10+scorecnt))/(1-1.07f)));
            score += (int)plusescore;
            ScoreText.text =score.ToString();
            NewGame();
        }
        else
        {
            resultText.text = "틀렸어!";
            NewGame();
        }

        // 유저가 추측한 문자열과 맞춘 문자의 개수를 표시
        resultText.text = string.Format("Guess: {0}, Correct: {1}", guess, correctCount);

        // 입력 필드 비우기
        guessInput.text = "";
    }

}
