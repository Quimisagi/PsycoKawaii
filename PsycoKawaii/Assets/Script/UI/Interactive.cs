using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Dialogue _diaglogue;
    [SerializeField] private GameObject _diaglogueView;
    private bool _canSpeak;
    private PlayerMediator _player;

    private void Awake()
    {
        _diaglogueView.transform.localScale = Vector3.zero;
        _diaglogueView.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.Instance.StartDialogue(_diaglogue);
            _player = collision.GetComponent<PlayerMediator>();
            _canSpeak = true;
            _diaglogueView.SetActive(true);
            LeanTween.scale(_diaglogueView, Vector3.one, 0.5f).setEaseOutBounce();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //_diaglogueView.SetActive(false);
        LeanTween.scale(_diaglogueView, Vector3.zero, 0.2f).setEaseInBounce().setOnComplete(() => { _diaglogueView.SetActive(false); });

        
        _player = null;
        _canSpeak = false;
    }


    private void Update()
    {

        if (!Input.GetButtonDown("Jump") || !_canSpeak)
        {
            return;
        }


        if (DialogueManager.Instance.CanNextLine())
        {
            _player.SetPause(true);
            DialogueManager.Instance.ShowLine();
            return;
        }

        _player.SetPause(false);
        DialogueManager.Instance.Hidde();
        DialogueManager.Instance.StartDialogue(_diaglogue);
    }



}