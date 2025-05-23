using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource audioSource;
    public AudioClip uiClick;
    public AudioClip turretPlace;
    public AudioClip enemyHit;
    public AudioClip turretShoot;
    public AudioClip enemySpawn;
    public AudioClip gruntSound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayUIClick() => audioSource.PlayOneShot(uiClick);
    public void PlayTurretPlace() => audioSource.PlayOneShot(turretPlace);
    public void PlayEnemyHit() => audioSource.PlayOneShot(enemyHit);
    public void PlayTurretShoot() => audioSource.PlayOneShot(turretShoot);
    public void PlayEnemySpawn() => audioSource.PlayOneShot(enemySpawn);
    public void PlayGruntSound() => audioSource.PlayOneShot(gruntSound);
}
