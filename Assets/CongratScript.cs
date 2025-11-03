using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay;

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    void Start()
    {
        TextToDisplay = new List<string>();

        TimeToNextText = 0.0f;
        CurrentText = 0;
        RotatingSpeed = 60.0f; // degrees per second

        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");

        if (Text != null)
            Text.text = TextToDisplay[0];

        if (SparksParticles != null)
            SparksParticles.Play();
    }

    void Update()
    {
        // Rotate the text continuously
        if (Text != null)
            Text.transform.Rotate(Vector3.up * RotatingSpeed * Time.deltaTime);

        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
                CurrentText = 0;

            if (Text != null)
                Text.text = TextToDisplay[CurrentText];
        }
    }
}
