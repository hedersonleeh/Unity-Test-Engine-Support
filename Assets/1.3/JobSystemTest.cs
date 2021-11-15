using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using System.Linq;
using Unity.Collections;

public class JobSystemTest : MonoBehaviour
{

    struct RedChannelCounterJob : IJob
    {
        public Color[] colorArray;
        public NativeArray<float> result;

        public void Execute()
        {
            for (int i = 0; i < colorArray.Length; i += 2)
            {
                var a = colorArray[i].r;
                var b = colorArray[i + 1].r;
                result[0] += a + b;
            }
        }
    }
    [SerializeField] private Texture2D texture;

    private void Start()
    {
        CountWithJobs();
        CountTexture();
    }
    private void CountWithJobs()
    {
        var colorArray = texture.GetPixels();
        var timer = new Stopwatch();
        timer.Start();

        NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);
        RedChannelCounterJob jobData = new RedChannelCounterJob();
        jobData.colorArray = colorArray;
        jobData.result = result;
        JobHandle firstHandle = jobData.Schedule();
        firstHandle.Complete();
        timer.Stop();

        float r = result[0];
        result.Dispose();
        UnityEngine.Debug.Log("The sum of red channel is:" + r + " it takes :" + timer.ElapsedMilliseconds + "(ms)");

    }
    private void CountTexture()
    {
        var colorArray = texture.GetPixels();
        float sumR =0;
        var timer = new Stopwatch();
       
        timer.Start();
        for (int i = 0; i < colorArray.Length; i+=2)
        {
            var a = colorArray[i].r;
            var b = colorArray[i+1].r;
            sumR += a + b;
        }
        timer.Stop();
       UnityEngine.Debug.Log("The sum of red channel is:" + sumR+" it takes :" + timer.ElapsedMilliseconds+"(ms)");
    }
}
