using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GraphicsManager : MonoBehaviour
{
	// Post process effects
	public PostProcessVolume postProcess;
	public DepthOfField depthOfField;
	Bloom bloom;
	AmbientOcclusion ambientOcclusion;
	ColorGrading colorGrading;
	ChromaticAberration chromaticAberration;
	LensDistortion lensDistortion;
	Grain grain;

	List<TypedData> processes = new List<TypedData>();

	private void Start()
	{
		postProcess.profile.TryGetSettings(out depthOfField);
		postProcess.profile.TryGetSettings(out bloom);
		postProcess.profile.TryGetSettings(out ambientOcclusion);
		postProcess.profile.TryGetSettings(out colorGrading);
		postProcess.profile.TryGetSettings(out chromaticAberration);
		postProcess.profile.TryGetSettings(out lensDistortion);
		postProcess.profile.TryGetSettings(out grain);

		processes.Clear();
		processes.Add(new TypedData(typeof(DepthOfField), depthOfField, typeof(DepthOfField).GetFields()));
		processes.Add(new TypedData(typeof(Bloom), bloom, typeof(Bloom).GetFields()));
		processes.Add(new TypedData(typeof(AmbientOcclusion), ambientOcclusion, typeof(AmbientOcclusion).GetFields()));
		processes.Add(new TypedData(typeof(ColorGrading), colorGrading, typeof(ColorGrading).GetFields()));
		processes.Add(new TypedData(typeof(ChromaticAberration), chromaticAberration, typeof(ChromaticAberration).GetFields()));
		processes.Add(new TypedData(typeof(LensDistortion), lensDistortion, typeof(LensDistortion).GetFields()));
		processes.Add(new TypedData(typeof(Grain), grain, typeof(Grain).GetFields()));
	}

	public void ChangePostProcessingState(int index, bool state)
	{
		FieldInfo currentState = processes[index].GetField("active");
		currentState.SetValue(processes[index].data, state);
	}
}