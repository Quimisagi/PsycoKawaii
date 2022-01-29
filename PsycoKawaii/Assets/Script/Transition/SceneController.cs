using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    private FadeScreen _fade;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _fade = FindObjectOfType<FadeScreen>();
    }

    public void ChangeScene(string nameScene, float timeFade, PlayerMediator player, Vector2 position)
    {
        StartCoroutine(changeScene(nameScene, timeFade, player, position));
    }

    private IEnumerator changeScene(string nameScene, float timeFade, PlayerMediator player, Vector2 position)
    {
        player.SetPause(true);
        _fade.Show(timeFade);
        yield return new WaitForSeconds(++timeFade);

        SceneManager.LoadScene(nameScene);
        player.transform.position = position;
        yield return new WaitForSeconds(++timeFade);
        _fade.Hidden(timeFade);
        player.SetPause(false);

    }

}
