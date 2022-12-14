using UnityEngine;

public static class Utils
{
    public static Bounds OrthographicBounds()
    {
        Camera camera = Camera.main;
        float cameraHeight = camera.orthographicSize * 2;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
