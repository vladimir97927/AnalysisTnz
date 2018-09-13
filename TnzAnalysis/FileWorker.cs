using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TnzAnalysis
{
    public static class FileWorker
    {
        [DllImport("Tnzv01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static unsafe extern int TnzDDBOpenDatabase(byte[] dbFile, out IntPtr dbhDatabase);

        [DllImport("Tnzv01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static unsafe extern int TnzDDBGetChannelCount(IntPtr dbhDatabase, out int dwChannelsCount);

        [DllImport("Tnzv01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static unsafe extern int TnzDDBGetDataCount(IntPtr dbhDatabase, out int dwDBDataCount);

        [DllImport("Tnzv01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static unsafe extern int TnzDDBGetChannelSet(IntPtr dbhDatabase, int* dwChannelArray, int dwChannelArraySize);

        [DllImport("Tnzv01.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static unsafe extern int TnzDDBGetIndexDataSet(IntPtr dbhDatabase, int* dwChannelArray, int dwChannelArraySize, int dwIndex, Int16* pwData);

        private const int maxDataCount = 4000000;

        private const int maxChannelCount = 20;

        public static string FilePath { get; private set; }

        private static IntPtr _dbHandle;

        private static int _channelCount;

        private static int _dataCount;

        private static int[] _channels;

        public static short[][] AllChannelsData { get; private set; }

        private static void SetDbHandle()
        {
            byte[] dbFile = Encoding.ASCII.GetBytes(FilePath);
            int errorCode = TnzDDBOpenDatabase(dbFile, out IntPtr dbHandle);
            if (errorCode == TNZRESULT.TNZD_ERROR_OK)
            {
                _dbHandle = dbHandle;
            }
            else
            {
                throw new OpenFileException();
            }
        }

        private static void SetChannelCount()
        {
            int errorCode = TnzDDBGetChannelCount(_dbHandle, out int channelCount);
            if (errorCode == TNZRESULT.TNZD_ERROR_OK)
            {
                _channelCount = channelCount;
            }
            else
            {
                throw new OpenFileException();
            }
        }

        private static void SetDataCount()
        {
            int errorCode = TnzDDBGetDataCount(_dbHandle, out int dataCount);
            if (errorCode == TNZRESULT.TNZD_ERROR_OK)
            {
                _dataCount = dataCount;
            }
            else
            {
                throw new OpenFileException();
            }
        }

        private static unsafe void SetChannels()
        {
            if (_channelCount != 0)
            {
                _channels = new int[_channelCount];
                fixed (int* channelsPointer = _channels)
                {
                    int errorCode = TnzDDBGetChannelSet(_dbHandle, channelsPointer, _channelCount);
                    if (errorCode != TNZRESULT.TNZD_ERROR_OK)
                    {
                        throw new OpenFileException();
                    }
                }
            }
        }

        private static void InitAllChannelsData()
        {
            AllChannelsData = new short[maxChannelCount][];
            for (int i = 0; i < maxChannelCount; i++)
            {
                AllChannelsData[i] = new short[maxDataCount];
            }
        }

        public static unsafe void OpenFile(string filePath)
        {
            FilePath = filePath;
            SetDbHandle();
            SetChannelCount();
            SetDataCount();
            SetChannels();
            InitAllChannelsData();
            short[] channelData = new short[20];
            if (_dbHandle != IntPtr.Zero)
            {
                fixed (int* channelsPointer = _channels)
                {
                    fixed(short* channelDataPointer = channelData)
                    {
                        for (int i = 10; i < _dataCount + 10; i++)
                        {
                            int errorCode = TnzDDBGetIndexDataSet(_dbHandle, channelsPointer, _channelCount, i, channelDataPointer);
                            if (errorCode == TNZRESULT.TNZD_ERROR_OK)
                            {
                                for (int j = 0; j < AllChannelsData.Length; j++) // 10 history?
                                {
                                    AllChannelsData[j][i - 10] = channelData[j];
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
