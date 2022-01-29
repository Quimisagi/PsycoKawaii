using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    private Dialogue _currentDiaglogue;

    private int _indexSentence;

    [SerializeField] private GameObject _diaglogueBox;
    [SerializeField] private Text _textBox;
    [SerializeField] private Text _nameBox;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Instance = this;
        _diaglogueBox.SetActive(false);
    }

    public void StartDialogue(Dialogue diaglogue)
    {
        _currentDiaglogue = diaglogue;
        _indexSentence = 0;
        _textBox.text = _currentDiaglogue.DialogueText[_indexSentence];
        _nameBox.text = _currentDiaglogue.Name;
    }

    public bool CanNextLine()
    {

        if (_currentDiaglogue.DialogueText.Length <= _indexSentence)
        {
            return false;
        }

        return true;

    }

    public void ShowLine()
    {
        _diaglogueBox.SetActive(true);

        _textBox.text = _currentDiaglogue.DialogueText[_indexSentence];
        _indexSentence++;
    }

    public void Hidde()
    {
        _diaglogueBox.SetActive(false);
        Debug.Log("EsconderDialogo");
    }

}
