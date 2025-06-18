using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] GameObject sprite;
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeStrength = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            // Check if the ball entered the left or right dead zone
            if (gameObject.CompareTag("DeadZone_Left"))
            {
                StartCoroutine(HitEffect());
                StartCoroutine(ShakeEffect(shakeDuration, shakeStrength));
            }
            else if (gameObject.CompareTag("DeadZone_Right"))
            {
                StartCoroutine(HitEffect());
                StartCoroutine(ShakeEffect(shakeDuration, shakeStrength));
            }            
        }
    }

    IEnumerator HitEffect()
    {
        sprite.GetComponent<SpriteRenderer>().color = Color.red; // Flash red to show damage
        yield return new WaitForSeconds(0.5f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white; // Reset color after effect
    }

    IEnumerator ShakeEffect(float duration, float strength)
    {
        Vector3 originalPosition = sprite.transform.localPosition;

        float elapsedTime = 0.0f;

        while(elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            sprite.transform.localPosition = new Vector3(originalPosition.x + x, 
                originalPosition.y + y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        sprite.transform.localPosition = originalPosition; // Reset position after shaking
    }
}
