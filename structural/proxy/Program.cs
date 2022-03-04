using System;
using System.Collections.Generic;

namespace proxy
{
    //proxy design pattern lets you create a wrapper of the original object, it usually implements the same interface and it's useful because we can add additional responsabilily
    //to the class e.g add caching on each method request
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IThirdPartyYoutubeLib
    {
        object[] ListVideos();

        object GetVideoInfo(int id);
    }

    public class ThirdPartyYoutubeLib : IThirdPartyYoutubeLib
    {
        public object GetVideoInfo(int id)
        {
            throw new NotImplementedException();
        }

        public object[] ListVideos()
        {
            throw new NotImplementedException();
        }
    }

    public class ThirdPartyYoutubeLibProxy : IThirdPartyYoutubeLib
    {
        private readonly ThirdPartyYoutubeLib lib;

        private object[] videoCache;

        private Dictionary<int, object> videoInfosCache = new Dictionary<int, object>();

        public ThirdPartyYoutubeLibProxy()
        {
            lib = new ThirdPartyYoutubeLib();
        }
        public object GetVideoInfo(int id)
        {
            if (!videoInfosCache.ContainsKey(id)) { }
                videoInfosCache.Add(id, lib.GetVideoInfo(id));

            return videoInfosCache[id];
        }

        public object[] ListVideos()
        {
            if (videoCache == null)
                videoCache = lib.ListVideos();

            return videoCache;
        }
    }
}
