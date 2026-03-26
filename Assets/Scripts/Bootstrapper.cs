// @author: seifer
//
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Bootstrapper
{
	[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
	static void LoadSceneOnPressPlay()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.playModeStateChanged += OnPlay;
#endif
	}

#if UNITY_EDITOR
	static void OnPlay( UnityEditor.PlayModeStateChange state )
	{
		if ( state != UnityEditor.PlayModeStateChange.EnteredPlayMode )
			return;

		if ( SceneManager.GetSceneByName( "_Main" ) is Scene bstrap && !bstrap.isLoaded || !bstrap.IsValid() )
			SceneManager.LoadScene( "_Main", LoadSceneMode.Additive );

		UnityEditor.EditorApplication.playModeStateChanged -= OnPlay;
	}
#endif

	public static IEnumerator WaitUntilBootstrapIsLoaded()
	{
		yield return new WaitUntil( () =>
		{
			var bstrap = SceneManager.GetSceneByName( "_Main" ); 
			return bstrap.IsValid() && bstrap.isLoaded; 
		});
	}

}
