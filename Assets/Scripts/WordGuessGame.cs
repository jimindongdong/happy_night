using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordGuessGame : MonoBehaviour
{
    public InputField guessInput;
    public Button guessButton;
    public Text feedbackText;

    private const int MAX_GUESSES = 10;

    private string[] words = { "apple", "banana", "cherry", "grape", "orange", "pear", "pineapple", "strawberry" };
    private string wordToGuess;
    private List<char> lettersInWord;
    private int numGuesses;

    void Start()
    {
        StartNewGame();
    }

    public void CheckGuess()
    {
        string guess = guessInput.text.ToLower();
        Debug.Log(guess);
        if (guess.Length != wordToGuess.Length)
        {
            feedbackText.text = "The word you entered does not have the same length as the target word.";
            return;
        }

        List<char> guessedLetters = guess.ToCharArray().ToList();
        int numCorrectLetters = lettersInWord.Intersect(guessedLetters).Count();
        int numCorrectPositions = lettersInWord.Where((letter, index) => guess[index] == letter).Count();

        numGuesses++;

        if (numCorrectPositions == wordToGuess.Length)
        {
            feedbackText.text = "You won!";
            guessInput.interactable = false;
            guessButton.interactable = false;
        }
        else if (numGuesses == MAX_GUESSES)
        {
            feedbackText.text = $"You lost! The word was {wordToGuess}.";
            guessInput.interactable = false;
            guessButton.interactable = false;
        }
        else
        {
            feedbackText.text = $"You guessed {numCorrectLetters} letters correctly, and {numCorrectPositions} letters in the correct position. You have {MAX_GUESSES - numGuesses} guesses left.";
            guessInput.text = "";
            guessInput.ActivateInputField();
        }
    }

    public void StartNewGame()
    {
        numGuesses = 0;
        guessInput.interactable = true;
        guessButton.interactable = true;

        wordToGuess = words[Random.Range(0, words.Length)].ToLower();
        lettersInWord = wordToGuess.Distinct().ToList();
        feedbackText.text = "Guess the word!";

        Debug.Log($"The word to guess is {wordToGuess}");
    }
}
