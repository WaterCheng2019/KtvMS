using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public  class SongDownloader
    {

        MusicProviders musicProviders;
        string target;
        List<SongItemDownloader> songs = new List<SongItemDownloader>();

        public SongDownloader(MusicProviders musicProviders, string target)
        {
            this.musicProviders = musicProviders;
            this.target = target;
        }

        public double totaPercent
        {
            get
            {
                if (songs.Count==0)
                {
                    return 100;
                }
                return songs.Sum(s=>s.receiveProgress)*100/songs.Count;
            }
        }
        public double totalSpeed
        {
            get
            {
                return songs.Sum(s=>s.receivrSpeed);
            }
        }

        public void AddDownload(MergedSong1 song)
        {
            SongItemDownloader downloader = new SongItemDownloader(musicProviders, target, song);
            downloader.DownloadFinish += Downloader_DownloadFinish;

            songs.Add(downloader);
            downloader.Download();
        }

        public void Downloader_DownloadFinish(object sender,SongItemDownloader e)
        {
            songs.Remove(e);
        }
       
  
    }

    public delegate void DownloadFinishEvent(object sender,SongItemDownloader e);
    /// <summary>
    /// 单个文件下载
    /// </summary>
    public class SongItemDownloader
    {
        MusicProviders musicProviders;
        string target;
        MergedSong1 song1;

        public event DownloadFinishEvent DownloadFinish;

        public SongItemDownloader(MusicProviders musicProviders,string target,MergedSong1 song1)
        {
            this.musicProviders = musicProviders;
            this.target = target;
            this.song1 = song1;
        }

        public long totalBytes;

        public long bytesReceived;

        public double receiveProgress;

        public double receivrSpeed;

        DateTime lastTime = DateTime.Now;

        public void Download()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += Clien_DownloadProgressChanged;
            new Thread(() =>
            {
                //多来源，防止单个来源出错
                foreach (var item in song1.items)
                {
                    try
                    {
                        client.DownloadFile(musicProviders.getDownloadUrl(item),target+"\\"+item.getFileName());
                        DownloadFinish?.Invoke(this,this);
                        break;
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }).Start();
        }

        private void Clien_DownloadProgressChanged(object sender,DownloadEventArgs e)
        {
            this.bytesReceived = e.bytesReceived;
            this.totalBytes = e.totalBytes;
            this.receivrSpeed = e.receiveSpend;
            this.receiveProgress = e.ReceiveProgress;
        }
    }
}
