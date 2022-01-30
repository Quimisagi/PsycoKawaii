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

    public void ChangeScene(float timeFade, PlayerMediator player, Vector2 position,Vector2 _cameraX, Vector2 _cameraY)
    {
        StartCoroutine(changeScene( timeFade, player, position, _cameraX, _cameraY));
    }

    private IEnumerator changeScene( float timeFade, PlayerMediator player, Vector2 position, Vector2 _cameraX, Vector2 _cameraY)
    {
        player.SetPause(true);
        _fade.Show(timeFade);
        yield return new WaitForSeconds(timeFade);

        //SceneManager.LoadScene(nameScene);
        player.transform.position = position;
        Camera.main.transform.position = new Vector3(position.x,position.y, Camera.main.transform.position.z);
        Camera.main.GetComponent<CameraController>().SetLimit(_cameraX, _cameraY);

        yield return new WaitForSeconds(timeFade);
        _fade.Hidden(timeFade);
        player.SetPause(false);
    }

    public void ChangeSceneName(string nameScene)
    {
        StartCoroutine(changeScene(nameScene));
    }

    private IEnumerator changeScene( string nameScene)
    {
        _fade.Show(0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nameScene);
        yield return new WaitForSeconds(0.5f);
        _fade.Hidden(0.5f);
    }

}
