using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionNpc : MonoBehaviour
{
   [SerializeField] private Mision _myMision;
    [SerializeField] private Dialogue _currentMisionDialogue;
   [SerializeField] private Dialogue _misionDialogue;
   [SerializeField] private Dialogue _misionIncomplete;
   [SerializeField] private Dialogue _misionComplete;
    private bool _speakMision;

    [SerializeField] private GameObject _diaglogueView;
    private PlayerMediator _player;
    private bool _isMisionAdd;

  
    private void Start()
    {
        _currentMisionDialogue = _misionDialogue;
        DialogueManager.Instance.StartDialogue(_currentMisionDialogue);
        _diaglogueView.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        DialogueManager.Instance.StartDialogue(_currentMisionDialogue);
        _player = collision.GetComponent<PlayerMediator>();
        _speakMision = true;
        _diaglogueView.SetActive(true);
  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _diaglogueView.SetActive(false);
        _player = null;
        _speakMision = false;
    }

    private void Update()
    {

        if (!Input.GetButtonDown("Jump") || !_speakMision)
        {
            return;
        }
        EndMision();
        Talk(_currentMisionDialogue);


    }

    private void Talk(Dialogue _Dialogue)
    {
        if (DialogueManager.Instance.CanNextLine())
        {
            _player.SetPause(true);
            DialogueManager.Instance.ShowLine();
            return;
        }

        _player.SetPause(false);
        DialogueManager.Instance.Hidde();
        DialogueManager.Instance.StartDialogue(_Dialogue);

        if (!_isMisionAdd)
        {
            AddMision();
        }


    }


    private void AddMision()
    {
        MisionInstaller.Instance.AddMision(_myMision);
        _currentMisionDialogue = _misionIncomplete;
        DialogueManager.Instance.StartDialogue(_currentMisionDialogue);
        _isMisionAdd = true;
    }

    private void EndMision()
    {
        
        if (MisionInstaller.Instance.ComprobateMisionComplete())
        {
            _currentMisionDialogue = _misionComplete;
            MisionInstaller.Instance.CompleteMision();
            DialogueManager.Instance.StartDialogue(_currentMisionDialogue);
        }
    }

}
