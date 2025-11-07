using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityVolumeRendering;
using System.Threading.Tasks;

public class LoadPresetDataset : MonoBehaviour
{
    [SerializeField] DatasetPaths datasetPaths;
    private string rowDatasetPath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rowDatasetPath = datasetPaths.RawDatasetPath;
        StartCoroutine(LoadDatasetCoroutine());
    }

    private IEnumerator LoadDatasetCoroutine()
    {
        DespawnAllDatasets();
        yield return null;
        // start the async work and wait for completion
        Task loadTask = ReadAllFilesAndLoadDatasetAsync();
        yield return new WaitUntil(() => loadTask.IsCompleted);
        // observe exceptions if any
        if (loadTask.IsFaulted)
            Debug.LogException(loadTask.Exception);

    }
    // of this is available also a synchronous version, look at the documentation eventually
    private async Task ReadAllFilesAndLoadDatasetAsync()
    {
        try
        {
            if (Path.GetExtension(rowDatasetPath) == ".ini")
                rowDatasetPath = rowDatasetPath.Substring(0, rowDatasetPath.Length - 4);

            // Parse .ini file
            DatasetIniData initData = DatasetIniReader.ParseIniFile(rowDatasetPath + ".ini");
            if (initData != null)
            {
                // Import the dataset
                RawDatasetImporter importer = new RawDatasetImporter(rowDatasetPath, initData.dimX, initData.dimY, initData.dimZ, initData.format, initData.endianness, initData.bytesToSkip);
                VolumeDataset dataset = await importer.ImportAsync();
                // Spawn the object
                if (dataset != null)
                {
                    VolumeRenderedObject obj = await VolumeObjectFactory.CreateObjectAsync(dataset);
                    obj.transform.SetParent(this.transform, false);
                    obj.transform.localPosition = Vector3.zero;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            throw; // optional: keep rethrowing so caller/task sees the error
        }
    }
    private void DespawnAllDatasets()
    {
        VolumeRenderedObject[] volobjs = FindObjectsByType<VolumeRenderedObject>(FindObjectsSortMode.None);
        foreach(VolumeRenderedObject volobj in volobjs)
        {
            GameObject.Destroy(volobj.gameObject);
        }
    }
}
