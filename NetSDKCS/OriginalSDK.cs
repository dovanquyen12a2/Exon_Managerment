
// if the OS is linux open this define when compile the library.﻿ and if the OS is linux 64bit open define LINUX_X64 in the NetSDKStruct.cs file.
//#define LINUX  

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NetSDKCS
{
    public static class OriginalSDK
    {
#if(LINUX)
        [DllImport("libdhnetsdk.so")]
		public static extern int CLIENT_GetLastError();

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_InitEx(fDisConnectCallBack cbDisConnect, IntPtr dwUser, IntPtr lpInitParam);

        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_Cleanup();

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_LoginEx2(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex lpDeviceInfo, ref int error);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_Logout(IntPtr lLoginID);

        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser);

        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_SetNetworkParam(IntPtr pNetParam);

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopRealPlayEx(IntPtr lRealHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_SetRealDataCallBackEx(IntPtr lRealHandle, fRealDataCallBackEx cbRealData, IntPtr dwUser, uint dwFlag);


        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_SaveRealData(IntPtr lRealHandle, string pchFileName);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopSaveRealData(IntPtr lRealHandle);


        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_SnapPictureEx(IntPtr lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_PlayBackByTimeEx2(IntPtr lLoginID, int nChannelID, ref NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_QueryRecordFile(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, ref int filecount, int waittime, bool bTime);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_CapturePictureEx(IntPtr hPlayHandle, string pchPicFileName, EM_NET_CAPTURE_FORMATS eFormat);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopPlayBack(IntPtr lPlayHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_DownloadByTimeEx(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string sSavedFileName,
			fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData,
			fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopDownload(IntPtr lFileHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_DHPTZControlEx2(IntPtr lLoginID, int nChannelID, uint dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_OpenSound(IntPtr hPlayHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_CloseSound();

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_PausePlayBack(IntPtr lPlayHandle, bool bPause);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_FastPlayBack(IntPtr lPlayHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_SlowPlayBack(IntPtr lPlayHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_NormalPlayBack(IntPtr lPlayHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue);

        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_SetDVRMessCallBackEx1(fMessCallBackEx cbMessage, IntPtr dwUser);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StartListenEx(IntPtr lLoginID);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopListen(IntPtr lLoginID);

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_RealLoadPictureEx(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopLoadPic(IntPtr lAnalyzerHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_QuerySystemInfo(IntPtr lLoginID, int nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime);

        [DllImport("libdhnetsdk.so")]
		public static extern IntPtr CLIENT_StartTalkEx(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_StopTalkEx(IntPtr lTalkHandle);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_RecordStartEx(IntPtr lLoginID);

        [DllImport("libdhnetsdk.so")]
		public static extern bool CLIENT_RecordStopEx(IntPtr lLoginID);

        [DllImport("libdhnetsdk.so")]
		public static extern int CLIENT_TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize);

        [DllImport("libdhnetsdk.so")]
		public static extern void CLIENT_AudioDec(IntPtr pAudioDataBuf, uint dwBufSize);
#else
        [DllImport("dhnetsdk.dll")]
        public static extern int CLIENT_GetLastError();

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_InitEx(fDisConnectCallBack cbDisConnect, IntPtr dwUser, IntPtr lpInitParam);

        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_Cleanup();

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_LoginEx2(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex lpDeviceInfo, ref int error);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_Logout(IntPtr lLoginID);

        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser);

        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_SetNetworkParam(IntPtr pNetParam);

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopRealPlayEx(IntPtr lRealHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_SetRealDataCallBackEx(IntPtr lRealHandle, fRealDataCallBackEx cbRealData, IntPtr dwUser, uint dwFlag);


        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_SaveRealData(IntPtr lRealHandle, string pchFileName);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopSaveRealData(IntPtr lRealHandle);


        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_SnapPictureEx(IntPtr lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_PlayBackByTimeEx2(IntPtr lLoginID, int nChannelID, ref NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_QueryRecordFile(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, ref int filecount, int waittime, bool bTime);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopPlayBack(IntPtr lPlayHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_DownloadByTimeEx(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string sSavedFileName,
            fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData,
            fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopDownload(IntPtr lFileHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_DHPTZControlEx2(IntPtr lLoginID, int nChannelID, uint dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_OpenSound(IntPtr hPlayHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_CloseSound();

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_PausePlayBack(IntPtr lPlayHandle, bool bPause);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_FastPlayBack(IntPtr lPlayHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_SlowPlayBack(IntPtr lPlayHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_NormalPlayBack(IntPtr lPlayHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue);

        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_SetDVRMessCallBackEx1(fMessCallBackEx cbMessage, IntPtr dwUser);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StartListenEx(IntPtr lLoginID);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopListen(IntPtr lLoginID);

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_RealLoadPictureEx(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopLoadPic(IntPtr lAnalyzerHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_QuerySystemInfo(IntPtr lLoginID, int nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime);

        [DllImport("dhnetsdk.dll")]
        public static extern IntPtr CLIENT_StartTalkEx(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_StopTalkEx(IntPtr lTalkHandle);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_RecordStartEx(IntPtr lLoginID);

        [DllImport("dhnetsdk.dll")]
        public static extern bool CLIENT_RecordStopEx(IntPtr lLoginID);

        [DllImport("dhnetsdk.dll")]
        public static extern int CLIENT_TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize);

        [DllImport("dhnetsdk.dll")]
        public static extern void CLIENT_AudioDec(IntPtr pAudioDataBuf, uint dwBufSize);

#endif
    }
}

