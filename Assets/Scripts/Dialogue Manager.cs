using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] DialogueData dialogueData;
    [SerializeField] DialogueAdditionalResources dialogueAdditionalResources;

    [Space]
    [Header("Arabic Support")]
    [SerializeField] ArabicFixerTMPRO arabicDialogueText;

    [Space]
    [Header("UI Elements")]
    [SerializeField] Image characterImage;
    [SerializeField] Button mainButton;
    [SerializeField] GameObject buttonsPanel;

    [Space]
    [Header("Settings")]
    [SerializeField] float typeWriteSpeed = 0.02f;
    AudioSource audioSource;
    bool isTyping = true;
    string text, dialogeText;
    Coroutine typeWriteCoroutine;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dialogueAdditionalResources.DialogueSFX;
    }
    void Start()
    {
        dialogueData.DialogueIndex = 0;
        ViewNextDialogue();
        if (dialogueAdditionalResources.DialogueSFX == null)
        {
            Debug.Log("No AudioSource!!!!!");
        }
    }

    void Update()
    {
        arabicDialogueText.fixedText = dialogeText;
    }

    public void ViewNextDialogue()
    {

        if (dialogueData.DialogueIndex >= dialogueData.Length)
        {
            mainButton.gameObject.SetActive(false);
            buttonsPanel.gameObject.SetActive(true);

            return;
        }
        PlayDialogueSoundEffect();

        if (dialogueData.DialogueIndex % 2 == 0)
        {
            characterImage.sprite = dialogueAdditionalResources.Father;
        }
        else
        {
            characterImage.sprite = dialogueAdditionalResources.Son;

        }
        text = dialogueData.GetNextDialogueLine();

        if (typeWriteCoroutine != null)
        {
            StopCoroutine(typeWriteCoroutine);
        }

        typeWriteCoroutine = StartCoroutine(TypeWrite());
    }

    void PlayDialogueSoundEffect()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    IEnumerator TypeWrite()
    {
        dialogeText = "";
        isTyping = true;
        foreach (char letter in text)
        {
            dialogeText += letter;
            yield return new WaitForSeconds(typeWriteSpeed);
        }

        isTyping = false;
    }

    public void LoadTheGame()
    {
        SceneManager.LoadScene(0);

    }
    public void QuitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
