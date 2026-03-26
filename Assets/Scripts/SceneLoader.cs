using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    void Awake()
    {
        Instance = this;

#if !UNITY_EDITOR
        LoadSceneIfNothing();
#endif
    }

    public async void Load( string sceneToLoad )
    {
        await LoadAsync( sceneToLoad );
    }

    async Awaitable LoadAsync( string sceneToLoad )
    {
        Scene current = SceneManager.GetSceneAt( 1 );
        await SceneManager.LoadSceneAsync( sceneToLoad, LoadSceneMode.Additive );
        await SceneManager.UnloadSceneAsync( current );
    }

    public void LoadSceneIfNothing()
    {
        // Washing is default starting scene
        if ( SceneManager.loadedSceneCount == 1 )
            SceneManager.LoadSceneAsync( "Washing", LoadSceneMode.Additive );
    }
}