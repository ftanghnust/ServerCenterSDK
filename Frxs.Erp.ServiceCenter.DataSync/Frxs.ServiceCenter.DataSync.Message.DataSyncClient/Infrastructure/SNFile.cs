/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/23/2016 9:21:37 AM
 * *******************************************************/
using System.IO;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 处理记录最后一次访问的消息ID
    /// </summary>
    public class SNFile
    {
        /// <summary>
        /// 
        /// </summary>
        private string _path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public SNFile(string path)
        {
            this._path = path;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns>不存在直接返回 string.Empty </returns>
        public string Read()
        {
            if (!File.Exists(this._path))
            {
                return string.Empty;
            }
            using (StreamReader streamReader = new StreamReader(this._path))
            {
                return streamReader.ReadLine();
            }
        }

        /// <summary>
        /// 记录到文件
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Write(string content)
        {
            using (StreamWriter streamWriter = new StreamWriter(this._path))
            {
                streamWriter.WriteLine(content);
            }
        }
    }
}
