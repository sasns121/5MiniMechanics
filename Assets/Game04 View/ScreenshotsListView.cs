using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotsListView : MonoBehaviour
{
    [SerializeField] private ScreenshotView _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Sprite _baseScreenshot;
    [SerializeField] private Transform _dragingCanvas;
    private void Start()
    {
        RenderList(new List<Screenshot>()
        {
            new Screenshot(_baseScreenshot,DateTime.Now),
            new Screenshot(_baseScreenshot,DateTime.Now),
            new Screenshot(_baseScreenshot,DateTime.Now),
            new Screenshot(_baseScreenshot,DateTime.Now),
        });
    }

    private void RenderList(IEnumerable<Screenshot> screenshots)
    {
        foreach (Screenshot screenshot in screenshots)
        {
           ScreenshotView view = Instantiate(_template, _container);
           view.Render(screenshot);
            view.Init(_dragingCanvas);
        }

    }
}
