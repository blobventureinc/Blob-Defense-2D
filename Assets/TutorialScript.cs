using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] UpdatePlayerAttributes updateUI;
    // CINEMATIC
    [SerializeField] Camera camera;
    [SerializeField] Light2D globalLight;
    [SerializeField] Animator dayLightAnimator;

    // TO DEACTIVATE - dont forget to activate again
    [SerializeField] Tile_Targeting tileTargeting;
    [SerializeField] Player_Movement playerMovement;
    [SerializeField] GameObject gameManager;
    GameManager gm;
    ZoomCamera zoom;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject tutorialTooltips;

    // SHOW STUFF
    [SerializeField] GameObject tooltip1;
    [SerializeField] GameObject tooltip2;
    [SerializeField] GameObject tooltip3;
    [SerializeField] GameObject tooltip4;
    [SerializeField] GameObject tooltip5;
    [SerializeField] GameObject tooltip6;

    [SerializeField] Transform wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9, wp10;

    int state;

    int timer;

    bool done0;

    bool breaky = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            breaky = true;
            Debug.Log("Escape");
            player.transform.position = new Vector3(-8.0f, 4.0f, 0.0f);
            playerMovement.enabled = true;
            tileTargeting.enabled = true;
            dayLightAnimator.enabled = true;
            ui.SetActive(true);
            zoom.enabled = true;
            gm.enabled = true;
            tutorialTooltips.SetActive(true);
            Camera.main.orthographicSize = 4.0f;
            Camera.main.transform.localPosition = new Vector3(0, 0.4f, -100f);
            updateUI.Init();
            gameObject.SetActive(false);
        }
    }

    private void Start() {
        // DEACTIVATE STUFF
        tutorialTooltips.SetActive(false);
        gm = gameManager.GetComponent<GameManager>();
        zoom = gameManager.GetComponent<ZoomCamera>();
        playerMovement.enabled = false;
        tileTargeting.enabled = false;
        dayLightAnimator.enabled = false;
        ui.SetActive(false);
        zoom.enabled = false;
        gm.enabled = false;

        // CINEMATIC STUFF
        globalLight.intensity = 0.9f;
        globalLight.color = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        camera.orthographicSize = 2.0f;
        camera.transform.localPosition = new Vector3(0, 0.1f, -100f);

        timer = 0;
        state = 1;
        StartCoroutine("StartTutorial");
    }

    IEnumerator StartTutorial() {
        if (state == 1) {
            Debug.Log("State "+state);
            timer++;
            if (timer == 1) {
                tooltip1.SetActive(true);
            }
            yield return new WaitForSeconds(3.5f);
            tooltip1.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 2) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip2.SetActive(true);
            }
            yield return new WaitForSeconds(3.0f);
            tooltip2.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 3) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip3.SetActive(true);
            }
            yield return new WaitForSeconds(2.0f);
            tooltip3.SetActive(false);
            tileTargeting.enabled = false;
            playerMovement.enabled = true;
            yield return new WaitForSeconds(1.0f);
            playerMovement.MoveTo(wp1.position);
            //ebug.Log("Waypoint Position: " + waypoint1.position);
            //Debug.Log("Waypoint Position LocaL: " + waypoint1.localPosition);
            yield return new WaitForSeconds(0.7f);
            playerMovement.MoveTo(wp2.position);
            yield return new WaitForSeconds(1.1f);
            playerMovement.MoveTo(wp3.position);
            yield return new WaitForSeconds(1.0f);
            playerMovement.MoveTo(wp4.position);
            yield return new WaitForSeconds(1.3f);
            playerMovement.MoveTo(wp5.position);
            yield return new WaitForSeconds(2.8f);
            playerMovement.MoveTo(wp6.position);
            yield return new WaitForSeconds(1.4f);
            playerMovement.MoveTo(wp7.position);
            yield return new WaitForSeconds(2.0f);
            state++;
            timer = 0;
        }
        if (state == 4) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip4.SetActive(true);
            }
            yield return new WaitForSeconds(7.0f);
            tooltip4.SetActive(false);
            tooltip5.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            tooltip5.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 5) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip6.SetActive(true);
            }
            yield return new WaitForSeconds(5.0f);
            tooltip6.SetActive(false);
            playerMovement.MoveTo(wp8.position);
            yield return new WaitForSeconds(8.0f);
            state++;
            timer = 0;
        }
        if (breaky == true) {
            yield break;
        }
        playerMovement.enabled = true;
        tileTargeting.enabled = true;
        dayLightAnimator.enabled = true;
        ui.SetActive(true);
        zoom.enabled = true;
        gm.enabled = true;
        tutorialTooltips.SetActive(true);
        Camera.main.orthographicSize = 4.0f;
        Camera.main.transform.localPosition = new Vector3(0, 0.4f, -100f);
        gameObject.SetActive(false);
        yield break;
    }
}
