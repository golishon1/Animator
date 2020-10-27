using UnityEngine;

namespace UnityStandardAssets.Water
{
    [ExecuteInEditMode]
    public class WaterBasic : MonoBehaviour
    {
        private void Update()
        {
            var r = GetComponent<Renderer>();
            if (!r) return;
            var mat = r.sharedMaterial;
            if (!mat) return;

            var waveSpeed = mat.GetVector("WaveSpeed");
            var waveScale = mat.GetFloat("_WaveScale");
            var t = Time.time / 20.0f;

            var offset4 = waveSpeed * (t * waveScale);
            var offsetClamped = new Vector4(Mathf.Repeat(offset4.x, 1.0f), Mathf.Repeat(offset4.y, 1.0f),
                Mathf.Repeat(offset4.z, 1.0f), Mathf.Repeat(offset4.w, 1.0f));
            mat.SetVector("_WaveOffset", offsetClamped);
        }
    }
}