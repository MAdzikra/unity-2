using UnityEngine;
using System.Collections;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    public ParticleSystem muzzleFlash;
    public AudioSource gunAudio;
    public AudioClip shootSound;
    public GameObject laser;

    private void Start()
    {
        laser.SetActive(false);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                muzzleFlash.Emit(1);
                gunAudio.PlayOneShot(shootSound);
                StartCoroutine(ShowLaser());
                if (target != null)
                {
                    target.Hit();
                }
            }
        }
    }

    IEnumerator ShowLaser()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        laser.SetActive(false);
    }
}
