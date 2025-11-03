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
        // Initialize the list before using it
        TextToDisplay = new List<string>();

        TimeToNextText = 0.0f;
        CurrentText = 0;
        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulations!");
        TextToDisplay.Add("All Errors Fixed!");

        // Make sure references exist before using them
        if (Text != null)
            Text.text = TextToDisplay[0];
        else
            Debug.LogError("Text reference not assigned in the Inspector!");

        if (SparksParticles != null)
            SparksParticles.Play();
        else
            Debug.LogError("SparksParticles reference not assigned in the Inspector!");
    }

    void Update()
    {
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
