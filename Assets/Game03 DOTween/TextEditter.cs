using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextEditter : MonoBehaviour
{
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;
    void Start()
    {
        _text1.DOText("Земенен по буквам.",3).SetLoops(-1,LoopType.Yoyo);
        _text2.DOText(" Дополнен.",3).SetRelative();
        _text3.DOText("Взломан непонятными символами.",3,true,ScrambleMode.Numerals);
    }

}
