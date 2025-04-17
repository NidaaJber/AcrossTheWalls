using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DialogueAdditionalResources", menuName = "Nidaa/DialogueAdditionalResources", order = 1)]
public class DialogueAdditionalResources : ScriptableObject
{
    [SerializeField] Sprite father;
    [SerializeField] Sprite son;
    [SerializeField] AudioClip dialogueSFX;

    public Sprite Father
    {
        get
        {
            return father;
        }
    }
    public Sprite Son
    {
        get
        {
            return son;
        }
    }
    public AudioClip DialogueSFX
    {
        get
        {
            return dialogueSFX;
        }
    }


}
