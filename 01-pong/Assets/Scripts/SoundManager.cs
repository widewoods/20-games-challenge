using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallMovement.OnBallCollision += PlayHitSound;
        GameManager.OnBallRespawn += PlayScoreSound;
    }

    void OnDisable()
    {
        BallMovement.OnBallCollision -= PlayHitSound;
        GameManager.OnBallRespawn -= PlayScoreSound;
    }

    void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound);
    }
}
