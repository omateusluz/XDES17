using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    private Rigidbody2D ObstaculoRB;

    private GameController _GameController;
    private CameraShaker _CameraShaker;

    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();

        _GameController = Object.FindFirstObjectByType<GameController>();

        _CameraShaker = Object.FindFirstObjectByType<CameraShaker>() as CameraShaker;
    }

    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _GameController._obstaculoVelocidade * Time.smoothDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _CameraShaker != null)
        {
            _CameraShaker.ShakeIt();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
