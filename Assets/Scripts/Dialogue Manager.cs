using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Image characterImage;
    [SerializeField] ArabicFixerTMPRO arabicDialogueText;
    [SerializeField] Sprite father;
    [SerializeField] Sprite Son;
    [SerializeField] TextMeshProUGUI dialogueText1;
    // [SerializeField] TextMeshProUGUI dialogueText2;
    [SerializeField] Button mainButton;
    [SerializeField] GameObject buttonsPanel;
    // [SerializeField] Button button1;
    // [SerializeField] Button button2;
    int indexOfDisplyedDialogue = 0;


    string[] dialogueTexts =
    {
        "يا ولدي، لم تعد لدي القدرة على إكمال المسير، أريد أن أستريح قليلاً...",
        "طمني عنك يا أبي، هل أنت على ما يرام، ماذا تشعر!?",
        "أنا بخير يا ولدي اطمئن، مجرد تعب بسيط...",
        "أنا قلق جدا عليك يا أبتي، هل أحضر لك الطبيب؟!",
        "لا يا ولدي، لكني أود أن أوصيك بأن تكمل المسير، وتصل قريتنا العزيزة...",
        " أبي أنا خائف عليك جداً دعني أحضر لك الطبيب، يا ناس!! أبي مريض نادوا الطبيب … نادوا الطبيب!!",
        "مهجة قلبي أحمد، اطمئن، أظن أن المنية قد حانت، دعني ألمس وجهك..." + "\n" +"أوصيك بإكمال المسير...",
        "أبي .. سيحضر الطبيب حالاً. لا تتركني يا أبي، أنا نا بحاجة إليك جداً، وغداً سنكمل المسير معاً!!",
        "أحبك يا ولدي، أشهد أن لا إله إلا الله وأشهد أن محمداً رسول الله...",
        "أبي!! أبي!!! أبي !!!!",
    };

    // string istamer = "أوصيك بإكمال المسير من بعدي.";

    void Start()
    {
        ViewNextDialogue();
    }

    public void ViewNextDialogue()
    {
        if (indexOfDisplyedDialogue >= dialogueTexts.Length)
        {
            mainButton.gameObject.SetActive(false);
            buttonsPanel.gameObject.SetActive(true);

            return;
        }

        if (indexOfDisplyedDialogue % 2 == 0)
        {
            characterImage.sprite = father;
        }
        else
        {
            characterImage.sprite = Son;

        }
        // dialogueText1.text = dialogueTexts[indexOfDisplyedDialogue++];
        arabicDialogueText.fixedText = dialogueTexts[indexOfDisplyedDialogue++];
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
