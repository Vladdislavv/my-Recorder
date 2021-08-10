using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace Recorder.models
{
    class Record
    {
        private WaveFileWriter waveFileWriter;
        private WaveIn waveIn = new();

        public void StartRecord(string path)
        {
            CreateNewFile(path );
            waveFileWriter = new WaveFileWriter(path , waveIn.WaveFormat);
            waveIn = new();
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.StartRecording();
        }

        public void StopRecord()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveFileWriter.Close();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            waveFileWriter.WriteData(e.Buffer, 0, e.BytesRecorded);
        }

        private void CreateNewFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path );
            FileStream fileStream = fileInfo.Create();
            fileStream.Close();
        }
    }
}
