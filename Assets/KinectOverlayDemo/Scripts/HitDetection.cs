using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJointHandRight = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJointWristRight = KinectWrapper.NuiSkeletonPositionIndex.WristRight;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJointElbowRight = KinectWrapper.NuiSkeletonPositionIndex.ElbowRight;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJointShoulderRight = KinectWrapper.NuiSkeletonPositionIndex.ShoulderRight;

	public KinectWrapper.NuiSkeletonPositionIndex TrackedJointHandLeft = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJointWristLeft = KinectWrapper.NuiSkeletonPositionIndex.WristLeft;
	public KinectWrapper.NuiSkeletonPositionIndex TrackedJointElbowLeft = KinectWrapper.NuiSkeletonPositionIndex.ElbowLeft;
	public KinectWrapper.NuiSkeletonPositionIndex TrackedJointShoulderLeft = KinectWrapper.NuiSkeletonPositionIndex.ShoulderLeft;

    public GameObject OverlayObject;
	public GameObject OverlayObjectLeft;
	public GameObject OverlayObjectLeftUpperArm;


	public float smoothFactor = 5f;
	
	public GUIText debugText;

	private float distanceToCamera = 10f;
    // Start is called before the first frame update
    void Start()
    {
        	if(OverlayObject)
		{
			distanceToCamera = (OverlayObject.transform.position - Camera.main.transform.position).magnitude;
			distanceToCamera = (OverlayObjectLeft.transform.position - Camera.main.transform.position).magnitude;
			distanceToCamera = (OverlayObjectLeftUpperArm.transform.position - Camera.main.transform.position).magnitude;


		}
    }

    // Update is called once per frame
    void Update() 
	{
		KinectManager manager = KinectManager.Instance;
		
		if(manager && manager.IsInitialized())
		{
		
			
//			Vector3 vRight = BottomRight - BottomLeft;
//			Vector3 vUp = TopLeft - BottomLeft;
			
			int iJointIndexLeftHand = (int)TrackedJointHandLeft;
            int iJointIndexLeftWrist = (int)TrackedJointWristLeft;
            int iJointIndexLeftElbow = (int)TrackedJointElbowLeft;

			if(manager.IsUserDetected())
			{
				uint userId = manager.GetPlayer1ID();
				
				if(manager.IsJointTracked(userId, iJointIndexLeftHand))
				{
					Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndexLeftHand);
                    Vector3 posJoint1 = manager.GetRawSkeletonJointPos(userId, iJointIndexLeftWrist);
					 Vector3 posJoint2 = manager.GetRawSkeletonJointPos(userId, iJointIndexLeftElbow);



					if(posJoint != Vector3.zero)
					{
						// 3d posi0tion to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);
						
						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos(posDepth);
						
						float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
						float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;
						
//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
						//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));

						if(debugText)
						{
							debugText.GetComponent<GUIText>().text = "Tracked user ID: " + userId;  // new Vector2(scaleX, scaleY).ToString();
						}
						
						if(OverlayObject)
						{
							Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
							OverlayObject.transform.position = Vector3.Lerp(OverlayObject.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);
						}
					}
				}
				
			}
			
		}
	}
}
