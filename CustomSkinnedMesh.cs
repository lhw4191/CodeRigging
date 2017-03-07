using UnityEngine;
using System.Collections;

public class CustomSkinnedMesh : MonoBehaviour {
    public Material mt;
    public Transform[] bones;

	// Use this for initialization
	void Start () {
        Mesh m = new Mesh();

        m.vertices = new Vector3[]
        {
            new Vector3(-0.7f, 0.0f, 0.0f),
            new Vector3(-1.0f, 1.0f, 0.0f),
            new Vector3(-1.0f, 2.5f, 0.0f),
            new Vector3(1.0f, 2.5f, 0.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
            new Vector3(0.7f, 0.0f, 0.0f),

            new Vector3(-1.3f, -1.0f, 0.0f),
            new Vector3(-0.8f, -1.0f, 0.0f),

            new Vector3(0.8f, -1.0f, 0.0f),
            new Vector3(1.3f, -1.0f, 0.0f),

            new Vector3(-1.7f, 0.25f, 0.0f),
            new Vector3(-1.1f, 0.25f, 0.0f),

            new Vector3(1.1f, 0.25f, 0.0f),
            new Vector3(1.7f, 0.25f, 0.0f)
        };

        m.triangles = new int[] {
            0, 1, 4,
            0, 4, 5,
            1, 2, 3,
            1, 3, 4,
            6, 0, 7,
            8, 5, 9,
            10, 1, 11,
            12, 4, 13,
        };
        m.bindposes = new Matrix4x4[]
        {
            bones[0].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[1].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[2].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[3].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[4].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[5].worldToLocalMatrix * transform.localToWorldMatrix
        };

        m.boneWeights = new BoneWeight[]
        {
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 0, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 0, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f },

            new BoneWeight() {boneIndex0 = 3, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 3, weight0 = 1f },

            new BoneWeight() {boneIndex0 = 4, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 4, weight0 = 1f },

            new BoneWeight() {boneIndex0 = 1, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f },

            new BoneWeight() {boneIndex0 = 2, weight0 = 1f },
            new BoneWeight() {boneIndex0 = 2, weight0 = 1f },
            // 굳이 boneIndex2를 사용하지 않아도 되는 애니매이션을 사용했음
        };

        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
        smr.sharedMesh = m; 
        smr.sharedMaterial = mt;
        smr.bones = bones;
        smr.rootBone = transform;
        //smr.quality = SkinQuality.Bone1;
        smr.quality = SkinQuality.Bone2;
    }

    // Update is called once per frame
    void Update () {
	
	}
}