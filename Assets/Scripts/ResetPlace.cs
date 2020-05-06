using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPlace : MonoBehaviour {
	
	[SerializeField]
	public GameObject player;
	private void Start() {
		
	}
	
	void Update()
    {
        // float primaryIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if(OVRInput.Get(OVRInput.Button.Start)){
            Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}

    }
}
