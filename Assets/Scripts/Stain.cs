using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Stain : MonoBehaviour
{
    [SerializeField] Image _stainPrefab;
    public static Stain Instance { get; private set; }

    void Awake()
    {
        Instance = this;

        _stainPrefab.gameObject.SetActive( false );
    }
    
    public void StainScreen()
    {
        var halfW = Screen.width;
        var halfH = Screen.height;

        for ( int i = 0; i < Random.Range( 10, 20 ); i++ )
        {
            Image stain = Instantiate( _stainPrefab.gameObject, transform ).GetComponent<Image>();
            stain.gameObject.SetActive( true );
            stain.transform.rotation = Quaternion.Euler( 0, 0, Random.Range( 0, 360 ) );
            stain.transform.localScale = Vector3.one * Random.Range( 0.7f, 3 );
            stain.rectTransform.anchoredPosition = new Vector2( Random.Range( -halfW, halfW ), Random.Range( -halfH, halfH ) );
            stain.DOFade( 0, 1 ).SetDelay( Random.Range( 3, 5 ) ).OnComplete( () => Destroy( stain.gameObject ) );
        }
    }

#if UNITY_EDITOR
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.S ) )
            StainScreen();
    }
#endif
}
