using DamaDb.Header.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DamaDb.Storage
{
    public class Engine : IEngine
    {
        private readonly string _filePath;
        private HeaderInfo _header = null;

        public Engine(string filePath)
        {
            _filePath = filePath;
        }

        public Task Init()
        {
            var exits = System.IO.File.Exists(_filePath);
            if (!exits)
                _header = CreateAndGetHeader();
            else
                _header = GetHeader();

            return Task.FromResult<object>(null);
        }

        public HeaderInfo CreateAndGetHeader()
        {
            var header = new HeaderInfo();
            header.DataPosition = (1024 * 100);
            header.TabeCount = 0;

            using (var fileStream = new System.IO.FileStream(_filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                using (var writer = new System.IO.BinaryWriter(fileStream))
                {
                    header.ActualHeaderLength = 0;
                    writer.Write(header.ActualHeaderLength);

                    //Header
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, header);

                    header.ActualHeaderLength = (int)(fileStream.Position - HeaderInfo.HeaderLengthSize); //Int Length => 4
                    
                    fileStream.Position = 0;
                    writer.Write(header.ActualHeaderLength);
                    fileStream.Position = header.ActualHeaderLength + HeaderInfo.HeaderLengthSize;

                    //Null Ascii Char
                    var remainingBytes = (1024 * 100) - fileStream.Position;
                    byte nullByte = 0x00;
                    for (var i = 0; i < remainingBytes; i++) //102400 - 100‬
                        writer.Write(nullByte); //Null Byte 

                    writer.Flush();
                    writer.Close();
                }
                
                fileStream.Close();
            }

            return header;
        }

        public HeaderInfo GetHeader()
        {
            HeaderInfo header = null;
            using (var fileStream = new System.IO.FileStream(_filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    var headerLength = reader.ReadInt32();
                    var headerBytes = reader.ReadBytes(headerLength);
                    using (var memoryStream = new MemoryStream(headerBytes))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        header = bf.Deserialize(memoryStream) as HeaderInfo;
                        if (header != null)
                            header.ActualHeaderLength = headerLength;
                        
                        memoryStream.Close();
                    }

                    reader.Close();
                }

                fileStream.Close();
            }

            return header;
        }
    }
}
