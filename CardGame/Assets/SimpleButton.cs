using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SimpleButton : MonoBehaviour
{
    Button myButton;
    public float scaleIncrementX;
    public float scaleIncrementY;

    private float ogScaleX, ogScaleY;
    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ogScaleX = transform.localScale.x;
        ogScaleY = transform.localScale.y;
        myButton.onClick.AddListener(ScalePop);
    }

    void ScalePop()
    {
        StartCoroutine(EnumScalePop());
    }

    IEnumerator EnumScalePop()
    {
        yield return new WaitForEndOfFrame();
        transform.DOScale(new Vector2(transform.localScale.x + scaleIncrementX, transform.localScale.y + scaleIncrementY), .5f)
            .SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.25f);
        transform.DOScale(new Vector2(ogScaleX, ogScaleY), .5f)
           .SetEase(Ease.OutBack);
    }
}
