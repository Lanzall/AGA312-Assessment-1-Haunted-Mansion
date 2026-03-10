using DG.Tweening;
using UnityEngine;
using TMPro;


public class TweenFun : MonoBehaviour
{
    public enum Direction { North, East, South, West}
    [SerializeField] private Transform player;
    [SerializeField] private float moveDistance = 5;
    [SerializeField] private float moveDuration = 5;
    [SerializeField] private float shakeStrength = 0.4f;
    [SerializeField] private Ease moveEase;

    [SerializeField] bool gridMovement;
    private bool isMoving;

    [Header("UI")]
    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeTime = 2f;
    [SerializeField] private Ease fadeEase;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int scoreBonus = 100;
    [SerializeField] private float scoreTweenTime = 1f;
    [SerializeField] private Ease scoreEase;
    private int score;

    private void Start()
    {
        fadeCanvas.alpha = 1;
        fadeCanvas.DOFade(0, fadeTime).SetEase(fadeEase);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Direction.North);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Direction.East);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Direction.South);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Direction.West);
        }
    }

    private void MovePlayer(Direction _direction)
    {
        if (isMoving && gridMovement)
            return;

        isMoving = true;

        switch (_direction)
        {
            case Direction.North:
                player.DOLocalMoveZ(player.localPosition.z + moveDistance, moveDuration)
                    .SetEase(moveEase)
                    .OnComplete(TweenComplete);
                break;
            case Direction.East:
                player.DOLocalMoveX(player.localPosition.x + moveDistance, moveDuration)
                    .SetEase(moveEase)
                    .OnComplete(TweenComplete);
                break;
            case Direction.South:
                player.DOLocalMoveZ(player.localPosition.z - moveDistance, moveDuration)
                    .SetEase(moveEase)
                    .OnComplete(TweenComplete);
                break;
            case Direction.West:
                player.DOLocalMoveX(player.localPosition.x - moveDistance, moveDuration)
                    .SetEase(moveEase)
                    .OnComplete(TweenComplete);
                break;
        }
        ChangeColor();
    }

    private void TweenComplete()
    {
        isMoving = false;
        ScreenShake();
        IncreaseScore();
    }

    private void ScreenShake() => Camera.main.DOShakePosition(moveDuration / 2, shakeStrength);

    private void ChangeColor() => player.GetComponent<Renderer>().material.DOColor(ColorX.GetRandomColor(), moveDuration);

    private void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, score + scoreBonus, scoreTweenTime, scoreEase, "F1");
        score = score + scoreBonus;
    }
}
