using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public async void Load( string sceneToLoad )
    {
        await LoadAsync( sceneToLoad );
    }

    async Awaitable LoadAsync( string sceneToLoad )
    {
        Scene current = SceneManager.GetSceneAt( 1 );
        await SceneManager.LoadSceneAsync( sceneToLoad );
    }
}