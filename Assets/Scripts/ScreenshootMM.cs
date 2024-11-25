using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenshootMM : MonoBehaviour
{
    public Camera screenshotCamera;  // Assign the screenshot camera in the inspector
    public int screenshotWidth = 3840;  // Set desired width
    public int screenshotHeight = 2160; // Set desired height

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeScreenshotWithSkybox();
        }
    }

    public void TakeScreenshotWithSkybox()
    {
        // Step 1: Enable the screenshot camera and set its clear flags to include the skybox
        screenshotCamera.gameObject.SetActive(true);
        screenshotCamera.clearFlags = CameraClearFlags.Skybox;

        // Step 2: Create a high-resolution RenderTexture
        RenderTexture rt = new RenderTexture(screenshotWidth, screenshotHeight, 24, RenderTextureFormat.ARGB32);
        screenshotCamera.targetTexture = rt;

        // Step 3: Render the screenshot camera view to the RenderTexture
        RenderTexture.active = rt;
        screenshotCamera.Render();

        // Step 4: Create a high-resolution Texture2D to store the rendered image
        Texture2D screenShot = new Texture2D(screenshotWidth, screenshotHeight, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, screenshotWidth, screenshotHeight), 0, 0);
        screenShot.Apply();

        // Step 5: Save the Texture2D as a PNG file
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(Application.persistentDataPath, "SkyboxScreenshot.png");
        File.WriteAllBytes(filename, bytes);

        // Clean up
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        // Step 6: Disable the screenshot camera
        screenshotCamera.gameObject.SetActive(false);

        Debug.Log("Screenshot with skybox saved to: " + filename);
    }

    // Optional: Convert the Texture2D to Sprite
    public Sprite TextureToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
