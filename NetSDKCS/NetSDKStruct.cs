
//if the OS is linux 64bit open this define when compile the library.﻿ and open define LINUX in the OriginalSDK.cs file.
//#define LINUX_X64   

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NetSDKCS
{
    /// <summary>
    /// initialization parameter structure
    /// </summary>
    public struct NETSDK_INIT_PARAM
    {
        public int nThreadNum;                                         // specify netsdk's normal network process thread number, zero means using default value
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bReserved;                                          // reserved
    }

    /// <summary>
    /// SDK error code number enumeration
    /// </summary>
    public enum EM_ErrorCode : uint
    {
        NET_NOERROR = 0,		            // No error 
        NET_ERROR = 0xFFFFFFFF,			// Unknown error
        NET_SYSTEM_ERROR = 0x80000000 | 1,       // Windows system error
        NET_NETWORK_ERROR = 0x80000000 | 2,       // Protocol error it may result from network timeout
        NET_DEV_VER_NOMATCH = 0x80000000 | 3,       // Device protocol does not match
        NET_INVALID_HANDLE = 0x80000000 | 4,       // Handle is invalid
        NET_OPEN_CHANNEL_ERROR = 0x80000000 | 5,       // Failed to open channel 
        NET_CLOSE_CHANNEL_ERROR = 0x80000000 | 6,		// Failed to close channel 
        NET_ILLEGAL_PARAM = 0x80000000 | 7,		// User parameter is illegal 
        NET_SDK_INIT_ERROR = 0x80000000 | 8,		// SDK initialization error 
        NET_SDK_UNINIT_ERROR = 0x80000000 | 9,		// SDK clear error 
        NET_RENDER_OPEN_ERROR = 0x80000000 | 10,		// Error occurs when apply for render resources.
        NET_DEC_OPEN_ERROR = 0x80000000 | 11,		// Error occurs when opening the decoder library 
        NET_DEC_CLOSE_ERROR = 0x80000000 | 12,		// Error occurs when closing the decoder library 
        NET_MULTIPLAY_NOCHANNEL = 0x80000000 | 13,		// The detected channel number is 0 in multiple-channel preview. 
        NET_TALK_INIT_ERROR = 0x80000000 | 14,		// Failed to initialize record library 
        NET_TALK_NOT_INIT = 0x80000000 | 15,        // The record library has not been initialized
        NET_TALK_SENDDATA_ERROR = 0x80000000 | 16,		// Error occurs when sending out audio data 
        NET_REAL_ALREADY_SAVING = 0x80000000 | 17,		// The real-time has been protected.
        NET_NOT_SAVING = 0x80000000 | 18,		// The real-time data has not been save.
        NET_OPEN_FILE_ERROR = 0x80000000 | 19,		// Error occurs when opening the file.
        NET_PTZ_SET_TIMER_ERROR = 0x80000000 | 20,		// Failed to enable PTZ to control timer.
        NET_RETURN_DATA_ERROR = 0x80000000 | 21,		// Error occurs when verify returned data.
        NET_INSUFFICIENT_BUFFER = 0x80000000 | 22,		// There is no sufficient buffer.
        NET_NOT_SUPPORTED = 0x80000000 | 23,		// The current SDK does not support this fucntion.
        NET_NO_RECORD_FOUND = 0x80000000 | 24,		// There is no searched result.
        NET_NOT_AUTHORIZED = 0x80000000 | 25,		// You have no operation right.
        NET_NOT_NOW = 0x80000000 | 26,		// Can not operate right now. 
        NET_NO_TALK_CHANNEL = 0x80000000 | 27,		// There is no audio talk channel.
        NET_NO_AUDIO = 0x80000000 | 28,		// There is no audio.
        NET_NO_INIT = 0x80000000 | 29,		// The network SDK has not been initialized.
        NET_DOWNLOAD_END = 0x80000000 | 30,		// The download completed.
        NET_EMPTY_LIST = 0x80000000 | 31,		// There is no searched result.
        NET_ERROR_GETCFG_SYSATTR = 0x80000000 | 32,		// Failed to get system property setup.
        NET_ERROR_GETCFG_SERIAL = 0x80000000 | 33,		// Failed to get SN.
        NET_ERROR_GETCFG_GENERAL = 0x80000000 | 34,		// Failed to get general property.
        NET_ERROR_GETCFG_DSPCAP = 0x80000000 | 35,		// Failed to get DSP capacity description.
        NET_ERROR_GETCFG_NETCFG = 0x80000000 | 36,		// Failed to get network channel setup.
        NET_ERROR_GETCFG_CHANNAME = 0x80000000 | 37,		// Failed to get channel name.
        NET_ERROR_GETCFG_VIDEO = 0x80000000 | 38,		// Failed to get video property.
        NET_ERROR_GETCFG_RECORD = 0x80000000 | 39,		// Failed to get record setup
        NET_ERROR_GETCFG_PRONAME = 0x80000000 | 40,		// Failed to get decoder protocol name 
        NET_ERROR_GETCFG_FUNCNAME = 0x80000000 | 41,		// Failed to get 232 COM function name.
        NET_ERROR_GETCFG_485DECODER = 0x80000000 | 42,		// Failed to get decoder property
        NET_ERROR_GETCFG_232COM = 0x80000000 | 43,		// Failed to get 232 COM setup
        NET_ERROR_GETCFG_ALARMIN = 0x80000000 | 44,		// Failed to get external alarm input setup
        NET_ERROR_GETCFG_ALARMDET = 0x80000000 | 45,		// Failed to get motion detection alarm
        NET_ERROR_GETCFG_SYSTIME = 0x80000000 | 46,		// Failed to get device time
        NET_ERROR_GETCFG_PREVIEW = 0x80000000 | 47,		// Failed to get preview parameter
        NET_ERROR_GETCFG_AUTOMT = 0x80000000 | 48,		// Failed to get audio maintenance setup
        NET_ERROR_GETCFG_VIDEOMTRX = 0x80000000 | 49,		// Failed to get video matrix setup
        NET_ERROR_GETCFG_COVER = 0x80000000 | 50,		// Failed to get privacy mask zone setup
        NET_ERROR_GETCFG_WATERMAKE = 0x80000000 | 51,		// Failed to get video watermark setup
        NET_ERROR_GETCFG_MULTICAST = 0x80000000 | 52,	    // Failed to get config￡omulticast port by channel
        NET_ERROR_SETCFG_GENERAL = 0x80000000 | 55,		// Failed to modify general property
        NET_ERROR_SETCFG_NETCFG = 0x80000000 | 56,		// Failed to modify channel setup
        NET_ERROR_SETCFG_CHANNAME = 0x80000000 | 57,		// Failed to modify channel name
        NET_ERROR_SETCFG_VIDEO = 0x80000000 | 58,		// Failed to modify video channel 
        NET_ERROR_SETCFG_RECORD = 0x80000000 | 59,		// Failed to modify record setup 
        NET_ERROR_SETCFG_485DECODER = 0x80000000 | 60,		// Failed to modify decoder property 
        NET_ERROR_SETCFG_232COM = 0x80000000 | 61,		// Failed to modify 232 COM setup 
        NET_ERROR_SETCFG_ALARMIN = 0x80000000 | 62,		// Failed to modify external input alarm setup
        NET_ERROR_SETCFG_ALARMDET = 0x80000000 | 63,		// Failed to modify motion detection alarm setup 
        NET_ERROR_SETCFG_SYSTIME = 0x80000000 | 64,		// Failed to modify device time 
        NET_ERROR_SETCFG_PREVIEW = 0x80000000 | 65,		// Failed to modify preview parameter
        NET_ERROR_SETCFG_AUTOMT = 0x80000000 | 66,		// Failed to modify auto maintenance setup 
        NET_ERROR_SETCFG_VIDEOMTRX = 0x80000000 | 67,		// Failed to modify video matrix setup 
        NET_ERROR_SETCFG_COVER = 0x80000000 | 68,		// Failed to modify privacy mask zone
        NET_ERROR_SETCFG_WATERMAKE = 0x80000000 | 69,		// Failed to modify video watermark setup 
        NET_ERROR_SETCFG_WLAN = 0x80000000 | 70,		// Failed to modify wireless network information 
        NET_ERROR_SETCFG_WLANDEV = 0x80000000 | 71,		// Failed to select wireless network device
        NET_ERROR_SETCFG_REGISTER = 0x80000000 | 72,		// Failed to modify the actively registration parameter setup.
        NET_ERROR_SETCFG_CAMERA = 0x80000000 | 73,		// Failed to modify camera property
        NET_ERROR_SETCFG_INFRARED = 0x80000000 | 74,		// Failed to modify IR alarm setup
        NET_ERROR_SETCFG_SOUNDALARM = 0x80000000 | 75,		// Failed to modify audio alarm setup
        NET_ERROR_SETCFG_STORAGE = 0x80000000 | 76,		// Failed to modify storage position setup
        NET_AUDIOENCODE_NOTINIT = 0x80000000 | 77,		// The audio encode port has not been successfully initialized. 
        NET_DATA_TOOLONGH = 0x80000000 | 78,		// The data are too long.
        NET_UNSUPPORTED = 0x80000000 | 79,		// The device does not support current operation. 
        NET_DEVICE_BUSY = 0x80000000 | 80,		// Device resources is not sufficient.
        NET_SERVER_STARTED = 0x80000000 | 81,		// The server has boot up 
        NET_SERVER_STOPPED = 0x80000000 | 82,		// The server has not fully boot up 
        NET_LISTER_INCORRECT_SERIAL = 0x80000000 | 83,		// Input serial number is not correct.
        NET_QUERY_DISKINFO_FAILED = 0x80000000 | 84,		// Failed to get HDD information.
        NET_ERROR_GETCFG_SESSION = 0x80000000 | 85,		// Failed to get connect session information.
        NET_USER_FLASEPWD_TRYTIME = 0x80000000 | 86,		// The password you typed is incorrect. You have exceeded the maximum number of retries.
        NET_LOGIN_ERROR_PASSWORD = 0x80000000 | 100,	    // Password is not correct
        NET_LOGIN_ERROR_USER = 0x80000000 | 101,	    // The account does not exist
        NET_LOGIN_ERROR_TIMEOUT = 0x80000000 | 102,	    // Time out for log in returned value.
        NET_LOGIN_ERROR_RELOGGIN = 0x80000000 | 103,	    // The account has logged in 
        NET_LOGIN_ERROR_LOCKED = 0x80000000 | 104,	    // The account has been locked
        NET_LOGIN_ERROR_BLACKLIST = 0x80000000 | 105,	    // The account bas been in the black list
        NET_LOGIN_ERROR_BUSY = 0x80000000 | 106,	    // Resources are not sufficient. System is busy now.
        NET_LOGIN_ERROR_CONNECT = 0x80000000 | 107,	    // Time out. Please check network and try again.
        NET_LOGIN_ERROR_NETWORK = 0x80000000 | 108,	    // Network connection failed.
        NET_LOGIN_ERROR_SUBCONNECT = 0x80000000 | 109,	    // Successfully logged in the device but can not create video channel. Please check network connection.
        NET_LOGIN_ERROR_MAXCONNECT = 0x80000000 | 110,     // exceed the max connect number
        NET_LOGIN_ERROR_PROTOCOL3_ONLY = 0x80000000 | 111,	    // protocol 3 support
        NET_LOGIN_ERROR_UKEY_LOST = 0x80000000 | 112,	    // There is no USB or USB info error
        NET_LOGIN_ERROR_NO_AUTHORIZED = 0x80000000 | 113,     // Client-end IP address has no right to login
        NET_RENDER_SOUND_ON_ERROR = 0x80000000 | 120,	    // Error occurs when Render library open audio.
        NET_RENDER_SOUND_OFF_ERROR = 0x80000000 | 121,	    // Error occurs when Render library close audio 
        NET_RENDER_SET_VOLUME_ERROR = 0x80000000 | 122,	    // Error occurs when Render library control volume
        NET_RENDER_ADJUST_ERROR = 0x80000000 | 123,	    // Error occurs when Render library set video parameter
        NET_RENDER_PAUSE_ERROR = 0x80000000 | 124,	    // Error occurs when Render library pause play
        NET_RENDER_SNAP_ERROR = 0x80000000 | 125,	    // Render library snapshot error
        NET_RENDER_STEP_ERROR = 0x80000000 | 126,	    // Render library stepper error
        NET_RENDER_FRAMERATE_ERROR = 0x80000000 | 127,	    // Error occurs when Render library set frame rate.
        NET_RENDER_DISPLAYREGION_ERROR = 0x80000000 | 128,     // Error occurs when Render lib setting show region
        NET_RENDER_GETOSDTIME_ERROR = 0x80000000 | 129,     // An error occurred when Render library getting current play time
        NET_GROUP_EXIST = 0x80000000 | 140,     // Group name has been existed.
        NET_GROUP_NOEXIST = 0x80000000 | 141,	    // The group name does not exist. 
        NET_GROUP_RIGHTOVER = 0x80000000 | 142,	    // The group right exceeds the right list!
        NET_GROUP_HAVEUSER = 0x80000000 | 143,	    // The group can not be removed since there is user in it!
        NET_GROUP_RIGHTUSE = 0x80000000 | 144,	    // The user has used one of the group right. It can not be removed. 
        NET_GROUP_SAMENAME = 0x80000000 | 145,      // New group name has been existed
        NET_USER_EXIST = 0x80000000 | 146,	    // The user name has been existed
        NET_USER_NOEXIST = 0x80000000 | 147,	    // The account does not exist.
        NET_USER_RIGHTOVER = 0x80000000 | 148,	    // User right exceeds the group right. 
        NET_USER_PWD = 0x80000000 | 149,	    // Reserved account. It does not allow to be modified.
        NET_USER_FLASEPWD = 0x80000000 | 150,	    // password is not correct
        NET_USER_NOMATCHING = 0x80000000 | 151,	    // Password is invalid
        NET_USER_INUSE = 0x80000000 | 152,	    // account in use
        NET_ERROR_GETCFG_ETHERNET = 0x80000000 | 300,	    // Failed to get network card setup.
        NET_ERROR_GETCFG_WLAN = 0x80000000 | 301,	    // Failed to get wireless network information.
        NET_ERROR_GETCFG_WLANDEV = 0x80000000 | 302,	    // Failed to get wireless network device.
        NET_ERROR_GETCFG_REGISTER = 0x80000000 | 303,	    // Failed to get actively registration parameter.
        NET_ERROR_GETCFG_CAMERA = 0x80000000 | 304,	    // Failed to get camera property 
        NET_ERROR_GETCFG_INFRARED = 0x80000000 | 305,	    // Failed to get IR alarm setup
        NET_ERROR_GETCFG_SOUNDALARM = 0x80000000 | 306,	    // Failed to get audio alarm setup
        NET_ERROR_GETCFG_STORAGE = 0x80000000 | 307,	    // Failed to get storage position 
        NET_ERROR_GETCFG_MAIL = 0x80000000 | 308,	    // Failed to get mail setup.
        NET_CONFIG_DEVBUSY = 0x80000000 | 309,	    // Can not set right now. 
        NET_CONFIG_DATAILLEGAL = 0x80000000 | 310,	    // The configuration setup data are illegal.
        NET_ERROR_GETCFG_DST = 0x80000000 | 311,     // Failed to get DST setup
        NET_ERROR_SETCFG_DST = 0x80000000 | 312,     // Failed to set DST 
        NET_ERROR_GETCFG_VIDEO_OSD = 0x80000000 | 313,     // Failed to get video osd setup.
        NET_ERROR_SETCFG_VIDEO_OSD = 0x80000000 | 314,     // Failed to set video osd 
        NET_ERROR_GETCFG_GPRSCDMA = 0x80000000 | 315,     // Failed to get CDMA\GPRS configuration
        NET_ERROR_SETCFG_GPRSCDMA = 0x80000000 | 316,     // Failed to set CDMA\GPRS configuration
        NET_ERROR_GETCFG_IPFILTER = 0x80000000 | 317,     // Failed to get IP Filter configuration
        NET_ERROR_SETCFG_IPFILTER = 0x80000000 | 318,     // Failed to set IP Filter configuration
        NET_ERROR_GETCFG_TALKENCODE = 0x80000000 | 319,     // Failed to get Talk Encode configuration
        NET_ERROR_SETCFG_TALKENCODE = 0x80000000 | 320,     // Failed to set Talk Encode configuration
        NET_ERROR_GETCFG_RECORDLEN = 0x80000000 | 321,     // Failed to get The length of the video package configuration
        NET_ERROR_SETCFG_RECORDLEN = 0x80000000 | 322,     // Failed to set The length of the video package configuration
        NET_DONT_SUPPORT_SUBAREA = 0x80000000 | 323,        // Not support Network hard disk partition
        NET_ERROR_GET_AUTOREGSERVER = 0x80000000 | 324,     // Failed to get the register server information
        NET_ERROR_CONTROL_AUTOREGISTER = 0x80000000 | 325,      // Failed to control actively registration
        NET_ERROR_DISCONNECT_AUTOREGISTER = 0x80000000 | 326,	    // Failed to disconnect actively registration
        NET_ERROR_GETCFG_MMS = 0x80000000 | 327,	    // Failed to get mms configuration
        NET_ERROR_SETCFG_MMS = 0x80000000 | 328,	    // Failed to set mms configuration
        NET_ERROR_GETCFG_SMSACTIVATION = 0x80000000 | 329,	    // Failed to get SMS configuration
        NET_ERROR_SETCFG_SMSACTIVATION = 0x80000000 | 330,	    // Failed to set SMS configuration
        NET_ERROR_GETCFG_DIALINACTIVATION = 0x80000000 | 331,	    // Failed to get activation of a wireless connection
        NET_ERROR_SETCFG_DIALINACTIVATION = 0x80000000 | 332,	    // Failed to set activation of a wireless connection
        NET_ERROR_GETCFG_VIDEOOUT = 0x80000000 | 333,     // Failed to get the parameter of video output
        NET_ERROR_SETCFG_VIDEOOUT = 0x80000000 | 334,	    // Failed to set the configuration of video output
        NET_ERROR_GETCFG_OSDENABLE = 0x80000000 | 335,	    // Failed to get osd overlay enabling
        NET_ERROR_SETCFG_OSDENABLE = 0x80000000 | 336,	    // Failed to set OSD overlay enabling
        NET_ERROR_SETCFG_ENCODERINFO = 0x80000000 | 337,     // Failed to set digital input configuration of front encoders
        NET_ERROR_GETCFG_TVADJUST = 0x80000000 | 338,	    // Failed to get TV adjust configuration
        NET_ERROR_SETCFG_TVADJUST = 0x80000000 | 339,	    // Failed to set TV adjust configuration
        NET_ERROR_CONNECT_FAILED = 0x80000000 | 340,	    // Failed to request to establish a connection
        NET_ERROR_SETCFG_BURNFILE = 0x80000000 | 341,	    // Failed to request to upload burn files
        NET_ERROR_SNIFFER_GETCFG = 0x80000000 | 342,	    // // Failed to get capture configuration information
        NET_ERROR_SNIFFER_SETCFG = 0x80000000 | 343,	    // Failed to set capture configuration information
        NET_ERROR_DOWNLOADRATE_GETCFG = 0x80000000 | 344,	    // Failed to get download restrictions information
        NET_ERROR_DOWNLOADRATE_SETCFG = 0x80000000 | 345,	    // Failed to set download restrictions information
        NET_ERROR_SEARCH_TRANSCOM = 0x80000000 | 346,	    // Failed to query serial port parameters
        NET_ERROR_GETCFG_POINT = 0x80000000 | 347,	    // Failed to get the preset info
        NET_ERROR_SETCFG_POINT = 0x80000000 | 348,	    // Failed to set the preset info
        NET_SDK_LOGOUT_ERROR = 0x80000000 | 349,     // SDK log out the device abnormally
        NET_ERROR_GET_VEHICLE_CFG = 0x80000000 | 350,	    // Failed to get vehicle configuration
        NET_ERROR_SET_VEHICLE_CFG = 0x80000000 | 351,	    // Failed to set vehicle configuration
        NET_ERROR_GET_ATM_OVERLAY_CFG = 0x80000000 | 352,	    // Failed to get ATM overlay configuration
        NET_ERROR_SET_ATM_OVERLAY_CFG = 0x80000000 | 353,	    // Failed to set ATM overlay configuration
        NET_ERROR_GET_ATM_OVERLAY_ABILITY = 0x80000000 | 354,	    // Failed to get ATM overlay ability
        NET_ERROR_GET_DECODER_TOUR_CFG = 0x80000000 | 355,	    // Failed to get decoder tour configuration
        NET_ERROR_SET_DECODER_TOUR_CFG = 0x80000000 | 356,	    // Failed to set decoder tour configuration
        NET_ERROR_CTRL_DECODER_TOUR = 0x80000000 | 357,	    // Failed to control decoder tour
        NET_GROUP_OVERSUPPORTNUM = 0x80000000 | 358,	    // Beyond the device supports for the largest number of user groups
        NET_USER_OVERSUPPORTNUM = 0x80000000 | 359,	    // Beyond the device supports for the largest number of users 
        NET_ERROR_GET_SIP_CFG = 0x80000000 | 368,	    // Failed to get SIP configuration
        NET_ERROR_SET_SIP_CFG = 0x80000000 | 369,	    // Failed to set SIP configuration
        NET_ERROR_GET_SIP_ABILITY = 0x80000000 | 370,	    // Failed to get SIP capability
        NET_ERROR_GET_WIFI_AP_CFG = 0x80000000 | 371,	    // Failed to get "WIFI ap' configuration 
        NET_ERROR_SET_WIFI_AP_CFG = 0x80000000 | 372,	    // Failed to set "WIFI ap" configuration  
        NET_ERROR_GET_DECODE_POLICY = 0x80000000 | 373,	    // Failed to get decode policy 
        NET_ERROR_SET_DECODE_POLICY = 0x80000000 | 374,	    // Failed to set decode policy 
        NET_ERROR_TALK_REJECT = 0x80000000 | 375,	    // refuse talk
        NET_ERROR_TALK_OPENED = 0x80000000 | 376,	    // talk has opened by other client
        NET_ERROR_TALK_RESOURCE_CONFLICIT = 0x80000000 | 377,	    // resource conflict
        NET_ERROR_TALK_UNSUPPORTED_ENCODE = 0x80000000 | 378,	    // unsupported encode type
        NET_ERROR_TALK_RIGHTLESS = 0x80000000 | 379,	    // no right
        NET_ERROR_TALK_FAILED = 0x80000000 | 380,	    // request failed
        NET_ERROR_GET_MACHINE_CFG = 0x80000000 | 381,	    // Failed to get device relative config
        NET_ERROR_SET_MACHINE_CFG = 0x80000000 | 382,	    // Failed to set device relative config
        NET_ERROR_GET_DATA_FAILED = 0x80000000 | 383,	    // get data failed
        NET_ERROR_MAC_VALIDATE_FAILED = 0x80000000 | 384,     // MAC validate failed
        NET_ERROR_GET_INSTANCE = 0x80000000 | 385,     // Failed to get server instance 
        NET_ERROR_JSON_REQUEST = 0x80000000 | 386,     // Generated json string is error
        NET_ERROR_JSON_RESPONSE = 0x80000000 | 387,     // The responding json string is error
        NET_ERROR_VERSION_HIGHER = 0x80000000 | 388,     // The protocol version is lower than current version
        NET_SPARE_NO_CAPACITY = 0x80000000 | 389,	    // Hotspare disk operation failed. The capacity is low
        NET_ERROR_SOURCE_IN_USE = 0x80000000 | 390,	    // Display source is used by other output
        NET_ERROR_REAVE = 0x80000000 | 391,     // advanced users grab low-level user resource
        NET_ERROR_NETFORBID = 0x80000000 | 392,     // net forbid
        NET_ERROR_GETCFG_MACFILTER = 0x80000000 | 393,     // get MAC filter configuration error
        NET_ERROR_SETCFG_MACFILTER = 0x80000000 | 394,     // set MAC filter configuration error
        NET_ERROR_GETCFG_IPMACFILTER = 0x80000000 | 395,     // get IP/MAC filter configuration error
        NET_ERROR_SETCFG_IPMACFILTER = 0x80000000 | 396,     // set IP/MAC filter configuration error
        NET_ERROR_OPERATION_OVERTIME = 0x80000000 | 397,     // operation over time 
        NET_ERROR_SENIOR_VALIDATE_FAILED = 0x80000000 | 398,     // senior validation failure
        NET_ERROR_DEVICE_ID_NOT_EXIST = 0x80000000 | 399,	    // device ID is not exist
        NET_ERROR_UNSUPPORTED = 0x80000000 | 400,     // unsupport operation
        NET_ERROR_PROXY_DLLLOAD = 0x80000000 | 401,	    // proxy dll load error
        NET_ERROR_PROXY_ILLEGAL_PARAM = 0x80000000 | 402,	    // proxy user parameter is not legal
        NET_ERROR_PROXY_INVALID_HANDLE = 0x80000000 | 403,	    // handle invalid
        NET_ERROR_PROXY_LOGIN_DEVICE_ERROR = 0x80000000 | 404,	    // login device error
        NET_ERROR_PROXY_START_SERVER_ERROR = 0x80000000 | 405,	    // start proxy server error
        NET_ERROR_SPEAK_FAILED = 0x80000000 | 406,	    // request speak failed
        NET_ERROR_NOT_SUPPORT_F6 = 0x80000000 | 407,     // unsupport F6
        NET_ERROR_CD_UNREADY = 0x80000000 | 408,	    // CD is not ready
        NET_ERROR_DIR_NOT_EXIST = 0x80000000 | 409,	    // Directory does not exist
        NET_ERROR_UNSUPPORTED_SPLIT_MODE = 0x80000000 | 410,	    // The device does not support the segmentation model
        NET_ERROR_OPEN_WND_PARAM = 0x80000000 | 411,	    // Open the window parameter is illegal
        NET_ERROR_LIMITED_WND_COUNT = 0x80000000 | 412,	    // Open the window more than limit
        NET_ERROR_UNMATCHED_REQUEST = 0x80000000 | 413,	    // Request command with the current pattern don't match
        NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR = 0x80000000 | 414,	    // Render Library to enable high-definition image internal adjustment strategy error
        NET_ERROR_UPGRADE_FAILED = 0x80000000 | 415,     // Upgrade equipment failure
        NET_ERROR_NO_TARGET_DEVICE = 0x80000000 | 416,      // Can't find the target device
        NET_ERROR_NO_VERIFY_DEVICE = 0x80000000 | 417,      // Can't find the verify device 
        NET_ERROR_CASCADE_RIGHTLESS = 0x80000000 | 418,	    // No cascade permissions
        NET_ERROR_LOW_PRIORITY = 0x80000000 | 419,	    // low priority
        NET_ERROR_REMOTE_REQUEST_TIMEOUT = 0x80000000 | 420,	    // The remote device request timeout
        NET_ERROR_LIMITED_INPUT_SOURCE = 0x80000000 | 421,	    //Input source beyond maximum route restrictions
        NET_ERROR_SET_LOG_PRINT_INFO = 0x80000000 | 422,     // Failed to set log print
        NET_ERROR_PARAM_DWSIZE_ERROR = 0x80000000 | 423,     // "dwSize" is not initialized in input param
        NET_ERROR_LIMITED_MONITORWALL_COUNT = 0x80000000 | 424,     // TV wall exceed limit
        NET_ERROR_PART_PROCESS_FAILED = 0x80000000 | 425,     // Fail to execute part of the process
        NET_ERROR_TARGET_NOT_SUPPORT = 0x80000000 | 426,     // Fail to transmit due to not supported by target
        NET_ERROR_VISITE_FILE = 0x80000000 | 510,	    // Access to the file failed
        NET_ERROR_DEVICE_STATUS_BUSY = 0x80000000 | 511,	    // Device busy
        NET_USER_PWD_NOT_AUTHORIZED = 0x80000000 | 512,     // Fail to change the password
        NET_USER_PWD_NOT_STRONG = 0x80000000 | 513,     // Password strength is not enough
        NET_ERROR_NO_SUCH_CONFIG = 0x80000000 | 514,     // No corresponding setup
        NET_ERROR_AUDIO_RECORD_FAILED = 0x80000000 | 515,     // Failed to record audio
        NET_ERROR_SEND_DATA_FAILED = 0x80000000 | 516,     // Failed to send out data 
        NET_ERROR_OBSOLESCENT_INTERFACE = 0x80000000 | 517,     // Abandoned port 
        NET_ERROR_INSUFFICIENT_INTERAL_BUF = 0x80000000 | 518,     // Internal buffer is not sufficient 
        NET_ERROR_NEED_ENCRYPTION_PASSWORD = 0x80000000 | 519,     // verify password when changing device IP
        NET_ERROR_SERIALIZE_ERROR = 0x80000000 | 1010,    // Failed to serialize data
        NET_ERROR_DESERIALIZE_ERROR = 0x80000000 | 1011,    // Failed to deserialize data

        NET_ERROR_LOWRATEWPAN_ID_EXISTED = 0x80000000 | 1012,    // the wireless id is already existed
        NET_ERROR_LOWRATEWPAN_ID_LIMIT = 0x80000000 | 1013,    // the wireless id limited
        NET_ERROR_LOWRATEWPAN_ID_ABNORMAL = 0x80000000 | 1014,    // add the wireless id abnormaly

        ERR_INTERNAL_INVALID_CHANNEL = 0x90001002,            // invaild channel
        ERR_INTERNAL_REOPEN_CHANNEL = 0x90001003,            // reopen channel failed 
        ERR_INTERNAL_SEND_DATA = 0x90002008,            // send data failed
        ERR_INTERNAL_CREATE_SOCKET = 0x90002003,            // creat socket failed
    }

    /// <summary>
    /// device information structure
    /// </summary>
    public struct NET_DEVICEINFO_Ex
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] sSerialNumber;	                        // serial number
        public int nAlarmInPortNum;                         // count of DVR alarm input
        public int nAlarmOutPortNum;                        // count of DVR alarm output
        public int nDiskNum;                                // number of DVR disk
        public int nDVRType;                                // DVR type, refer to EM_NET_DEVICE_TYPE
        public int nChanNum;                                // number of DVR channel
        public byte byLimitLoginTime;                        // Online Timeout, Not Limited Access to 0, not 0 Minutes Limit Said
        public byte byLeftLogTimes;                          // When login failed due to password error, notice user by this parameter.This parameter is invalid when remaining login times is zero.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved;                               // keep bytes for aligned
        public int nLockLeftTime;                           // when log in failed,the left time for users to unlock (seconds), -1 indicate the device haven't set the parameter 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] Reserved;                                // reserved
    }

    public enum EM_NET_DEVICE_TYPE
    {
        NET_PRODUCT_NONE = 0,
        NET_DVR_NONREALTIME_MACE,					                        // Non real-time MACE
        NET_DVR_NONREALTIME,						                        // Non real-time
        NET_NVS_MPEG1,								                        // Network video server
        NET_DVR_MPEG1_2,							                        // MPEG1 2-ch DVR
        NET_DVR_MPEG1_8,							                        // MPEG1 8-ch DVR
        NET_DVR_MPEG4_8,							                        // MPEG4 8-ch DVR
        NET_DVR_MPEG4_16,							                        // MPEG4 16-ch DVR
        NET_DVR_MPEG4_SX2,							                        // LB series DVR
        NET_DVR_MEPG4_ST2,							                        // GB  series DVR
        NET_DVR_MEPG4_SH2,							                        // HB  series DVR
        NET_DVR_MPEG4_GBE,							                        // GBE  series DVR
        NET_DVR_MPEG4_NVSII,						                        // II network video server
        NET_DVR_STD_NEW,							                        // New standard configuration protocol
        NET_DVR_DDNS,								                        // DDNS server
        NET_DVR_ATM,								                        // ATM series 
        NET_NB_SERIAL,								                        // 2nd non real-time NB series DVR
        NET_LN_SERIAL,								                        // LN  series 
        NET_BAV_SERIAL,								                        // BAV series
        NET_SDIP_SERIAL,							                        // SDIP series
        NET_IPC_SERIAL,								                        // IPC series
        NET_NVS_B,									                        // NVS B series
        NET_NVS_C,									                        // NVS H series 
        NET_NVS_S,									                        // NVS S series
        NET_NVS_E,									                        // NVS E series
        NET_DVR_NEW_PROTOCOL,						                        // Search device type from QueryDevState. it is in string format
        NET_NVD_SERIAL,								                        // NVD
        NET_DVR_N5,									                        // N5
        NET_DVR_MIX_DVR,							                        // HDVR
        NET_SVR_SERIAL,								                        // SVR series
        NET_SVR_BS,									                        // SVR-BS
        NET_NVR_SERIAL,								                        // NVR series
        NET_DVR_N51,                                                        // N51
        NET_ITSE_SERIAL,							                        // ITSE Intelligent Analysis Box
        NET_ITC_SERIAL,                                                     // Intelligent traffic camera equipment
        NET_HWS_SERIAL,                                                     // radar speedometer HWS
        NET_PVR_SERIAL,                                                     // portable video record
        NET_IVS_SERIAL,                                                     // IVS(intelligent video server series)
        NET_IVS_B,                                                          // universal intelligent detect video server series 
        NET_IVS_F,                                                          // face recognisation server
        NET_IVS_V,                                                          // video quality diagnosis server
        NET_MATRIX_SERIAL,							                        // matrix
        NET_DVR_N52,								                        // N52
        NET_DVR_N56,								                        // N56
        NET_ESS_SERIAL,                                                     // ESS
        NET_IVS_PC,                                                         // number statistic server
        NET_PC_NVR,                                                         // pc-nvr
        NET_DSCON,									                        // screen controller
        NET_EVS,									                        // network video storage server
        NET_EIVS,									                        // an embedded intelligent video analysis system
        NET_DVR_N6,                                                         // DVR-N6
        NET_UDS,                                                            // K-Lite Codec Pack
        NET_AF6016,									                        // Bank alarm host
        NET_AS5008,									                        // Video network alarm host
        NET_AH2008,									                        // Network alarm host
        NET_A_SERIAL,								                        // Alarm host series
        NET_BSC_SERIAL,								                        // Access control series of products
        NET_NVS_SERIAL,                                                     // NVS series product
        NET_VTO_SERIAL,                                                     // VTO series product
        NET_VTNC_SERIAL,                                                    // VTNC series product
        NET_TPC_SERIAL,               				                        // TPC series product, it is the thermal device 
        NET_ASM_SERIAL,                                                     // ASM series product
        NET_VTS_SERIAL,                                                     // VTS series product
    }

    /// <summary>
    /// login device mode enumeration
    /// </summary>
    public enum EM_LOGIN_SPAC_CAP_TYPE
    {
        TCP = 0,                                            // TCP login, default
        ANY = 1,                                            // No criteria login
        SERVER_CONN = 2,                                            // auto sign up login
        MULTICAST = 3,                                            // multicast login, default
        UDP = 4,                                            // UDP method login
        MAIN_CONN_ONLY = 6,                                            // only main connection login
        SSL = 7,                                            // SSL encryption login
        INTELLIGENT_BOX = 9,                                            // login IVS box remote device
        NO_CONFIG = 10,                                           // login device do not config
        U_LOGIN = 11,                                           // USB key device login
        LDAP = 12,                                           // LDAP login
        AD = 13,                                           // AD login
        RADIUS = 14,                                           // Radius  login 
        SOCKET_5 = 15,                                           // Socks5 login
        CLOUD = 16,                                           // cloud login
        AUTH_TWICE = 17,                                           // dual authentication loin
        TS = 18,                                           // TS stream client login
        P2P = 19,                                           // web private login
        MOBILE = 20,                                           // mobile client login
        INVALID = 21,                                           // invalid login
    }

    /// <summary>
    /// the corresponding parameter when setting log in structure
    /// </summary>
    public struct NET_PARAM
    {
        public int nWaittime;				                // Waiting time(unit is ms), 0:default 5000ms.
        public int nConnectTime;			                // Connection timeout value(Unit is ms), 0:default 1500ms.
        public int nConnectTryNum;			                // Connection trial times, 0:default 1.
        public int nSubConnectSpaceTime;	                // Sub-connection waiting time(Unit is ms), 0:default 10ms.
        public int nGetDevInfoTime;		                // Access to device information timeout, 0:default 1000ms.
        public int nConnectBufSize;		                // Each connected to receive data buffer size(Bytes), 0:default 250*1024
        public int nGetConnInfoTime;		                // Access to sub-connect information timeout(Unit is ms), 0:default 1000ms.
        public int nSearchRecordTime;                      // Timeout value of search video (unit ms), default 3000ms
        public int nsubDisconnetTime;                      // dislink disconnect time,0:default 60000ms
        public byte byNetType;				                // net type, 0-LAN, 1-WAN
        public byte byPlaybackBufSize;                      // playback data from the receive buffer size(m),when value = 0,default 4M
        public byte bDetectDisconnTime;                     // Pulse detect offline time(second) .When it is 0, the default setup is 60s, and the min time is 2s 
        public byte bKeepLifeInterval;                      // Pulse send out interval(second). When it is 0, the default setup is 10s, the min internal is 2s. 
        public int nPicBufSize;                            // actual pictures of the receive buffer size(byte)when value = 0,default 2*1024*1024
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved;			                    // reserved
    }

    /// <summary>
    /// snapshot parameter structure
    /// </summary>
    public struct NET_SNAP_PARAMS
    {
        public uint Channel;				                                // Snapshot channel
        public uint Quality;				                                // Image quality:level 1 to level 6
        public uint ImageSize;				                                // Video size;0:QCIF,1:CIF,2:D1
        public uint mode;					                                // Snapshot mode;0:request one frame,1:send out requestion regularly,2: Request consecutively
        public uint InterSnap;				                                // Time unit is second.If mode=1, it means send out requestion regularly. The time is valid.
        public uint CmdSerial;				                                // Request serial number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] Reserved;
    }

    /// <summary>
    /// realplay type
    /// </summary>
	public enum EM_RealPlayType
    {
        Realplay = 0,						                                // Real-time preview
        Multiplay,							                                // Multiple-channel preview 
        Realplay_0,				    		                                // Real-time monitor-main stream. It is the same as EM_RType_Realplay
        Realplay_1,					    	                                // Real-time monitor -- extra stream 1
        Realplay_2,					    	                                // Real-time monitor -- extra stream 2
        Realplay_3,					    	                                // Real-time monitor -- extra stream 3
        Multiplay_1,						                                // Multiple-channel preview--1-window 
        Multiplay_4,						                                // Multiple-channel preview--4-window
        Multiplay_8,						                                // Multiple-channel preview--8-window
        Multiplay_9,						                                // Multiple-channel preview--9-window
        Multiplay_16,						                                // Multiple-channel preview--16-window
        Multiplay_6,						                                // Multiple-channel preview--6-window
        Multiplay_12,						                                // Multiple-channel preview--12-window
        Multiplay_25,                                                       // Multiple-channel preview--25-window
        Multiplay_36,                                                       // Multiple-channel preview--36-window
    }

    /// <summary>
    /// realplay disconnnect event
    /// </summary>
    public enum EM_REALPLAY_DISCONNECT_EVENT_TYPE
    {
        REAVE,                                                              // resources is taked by advanced user
        NETFORBID,                                                          // forbidden
        SUBCONNECT,                                                         // sublink disconnect
    }

    /// <summary>
    /// absolute control PTZ corresponding structure
    /// </summary>
    public struct NET_PTZ_CONTROL_ABSOLUTELY
    {
        public NET_PTZ_SPACE_UNIT stuPosition;                        // PTZ Absolute Speed 
        public NET_PTZ_SPEED_UNIT stuSpeed;                           // PTZ Operation Speed
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// continuous control PTZ corresponding structure
    /// </summary>
    public struct NET_PTZ_SPEED_UNIT
    {
        public float fPositionX;                         // PTZ horizontal speed, normalized to -1~1 
        public float fPositionY;                         // PTZ vertical speed, normalized to -1~1 
        public float fZoom;                              // PTZ aperture magnification, normalized to 0~1 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szReserve;                          // Reserved
    }
    /// <summary>
    /// PTZ control coordinate unit structure
    /// </summary>
    public struct NET_PTZ_SPACE_UNIT
    {
        public int nPositionX;                         // PTZ horizontal motion position, effective range[0,3600]
        public int nPositionY;                         // PTZ vertical motion position, effective range[-1800,1800]
        public int nZoom;                              // PTZ aperture change position, the effective range[0,128]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// continuous control PTZ corresponding structure
    /// </summary>
    public struct NET_PTZ_CONTROL_CONTINUOUSLY
    {
        public NET_PTZ_SPEED_UNIT stuSpeed;                           // PTZ speed 
        public int nTimeOut;                           // Continuous motion timeout, the unit is in seconds 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// with speed rotation site PTZ control corresponding to the preset structure
    /// </summary>
    public struct NET_PTZ_CONTROL_GOTOPRESET
    {
        public int nPresetIndex;                       // Preset BIT Index 
        public NET_PTZ_SPEED_UNIT stuSpeed;                           // PTZ Operation Speed
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// set the PTZ vision information structure
    /// </summary>
    public struct NET_PTZ_VIEW_RANGE_INFO
    {
        public int nStructSize;                        // current struct size
        public int nAzimuthH;                          // Horizontal azimuth Angle, 0~3600, unit: degrees 
    }

    /// <summary>
    /// PTZ absolute focus corresponding structure
    /// </summary>
    public struct NET_PTZ_FOCUS_ABSOLUTELY
    {
        public uint dwValue;                            // PTZ Focused On Location, range (0~8191) 
        public uint dwSpeed;                            // PTZ Focused On Speed, the scope (0~7) 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// PTZ control - fan and corresponding structure
    /// </summary>
    public struct NET_PTZ_CONTROL_SECTORSCAN
    {
        public int nBeginAngle;                        // Staring Angle,Range:[-180,180]
        public int nEndAngle;                          // Ending Angle,Range:[-180,180]
        public int nSpeed;                             // Speed,Range:[0,255]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szReserve;                          // Reserved
    }

    /// <summary>
    /// control Fish eye E-PTZ information structure 
    /// </summary>
    public struct NET_PTZ_CONTROL_SET_FISHEYE_EPTZ
    {
        public uint dwSize;	                            // structure size
        public uint dwWindowID;                         // EPtz control window no.
        public uint dwCommand;                          // E-PTZ command 
        public uint dwParam1;                           // command corresponding to parameter 1
        public uint dwParam2;                           // command corresponding to  parameter 2
        public uint dwParam3;                           // command corresponding to  parameter 3
        public uint dwParam4;                           // command corresponding to  parameter 4
    }

    /// <summary>
    /// track control command enumeration
    /// </summary>
    public enum EM_NET_TRACK_CONTROL_CMD
    {
        UP,                                                                 // Move up, dwParam1 means step length range 1-8 
        DOWN,                                                               // Move down, dwParam1 means step length  range 1-8
        LEFT,                                                               // Move left, dwParam1 means step length  range 1-8
        RIGHT,                                                              // Move right, dwParam1 means step length  range 1-8
        SETPRESET,                                                          // Set preset，dwParam1 means preset value
        CLEARPRESET,                                                        // Clear preset，dwParam1 means preset value
        GOTOPRESET,                                                         // Goto preset，dwParam1 means preset value
    }

    /// <summary>
    /// track control information structure
    /// </summary>
    public struct NET_PTZ_CONTROL_SET_TRACK_CONTROL
    {
        public uint dwSize;                             // dwSize need to be assigned sizeof(NET_PTZ_CONTROL_SET_TRACK_CONTROL)
        public uint dwChannelID;                        // channel number
        public uint dwCommand;                          // Control command，corresponding to enum EM_NET_TRACK_CONTROL_CMD
        public uint dwParam1;                           // command corresponding to parameter 1
        public uint dwParam2;                           // command corresponding to parameter 2
        public uint dwParam3;                           // command corresponding to parameter 3
    }

    /// <summary>
    /// PTZ control command enumeration
    /// </summary>
    public enum EM_EXTPTZ_ControlType : uint
    {
        UP_CONTROL = 0,                                    // Up
        DOWN_CONTROL,                                                       // Down
        LEFT_CONTROL,                                                       // Left
        RIGHT_CONTROL,                                                      // Right
        ZOOM_ADD_CONTROL,                                                   // +Zoom in 
        ZOOM_DEC_CONTROL,                                                   // -Zoom out 
        FOCUS_ADD_CONTROL,                                                  // +Zoom in 
        FOCUS_DEC_CONTROL,                                                  // -Zoom out 
        APERTURE_ADD_CONTROL,                                               // + Aperture 
        APERTURE_DEC_CONTROL,                                               // -Aperture
        POINT_MOVE_CONTROL,                                                 // Go to preset 
        POINT_SET_CONTROL,                                                  // Set 
        POINT_DEL_CONTROL,                                                  // Delete
        POINT_LOOP_CONTROL,                                                 // Tour 
        LAMP_CONTROL,                                                       // Light and wiper 

        LEFTTOP = 0x20,				                    // Upper left
        RIGHTTOP,						                                    // Upper right 
        LEFTDOWN,						                                    // Down left
        RIGHTDOWN,						                                    // Down right 
        ADDTOLOOP,						                                    // Add preset to tour		tour	 preset value
        DELFROMLOOP,					                                    // Delete preset in tour	tour	 preset value
        CLOSELOOP,						                                    // Delete tour				tour		
        STARTPANCRUISE,					                                    // Begin pan rotation		
        STOPPANCRUISE,					                                    // Stop pan rotation		
        SETLEFTBORDER,					                                    // Set left limit		
        SETRIGHTBORDER,					                                    // Set right limit	
        STARTLINESCAN,					                                    // Begin scanning			
        CLOSELINESCAN,					                                    // Stop scanning		
        SETMODESTART,					                                    // Start mode	mode line		
        SETMODESTOP,					                                    // Stop mode	mode line		
        RUNMODE,						                                    // Enable mode	Mode line		
        STOPMODE,						                                    // Disable mode	Mode line	
        DELETEMODE,						                                    // Delete mode	Mode line
        REVERSECOMM,					                                    // Flip
        FASTGOTO,						                                    // 3D position	X address(8192)	Y address(8192)	zoom(4)
        AUXIOPEN,						                                    // auxiliary open	Auxiliary point	
        AUXICLOSE,						                                    // Auxiliary close	Auxiliary point
        OPENMENU = 0x36,				                    // Open dome menu 
        CLOSEMENU,						                                    // Close menu 
        MENUOK,							                                    // Confirm menu 
        MENUCANCEL,						                                    // Cancel menu 
        MENUUP,							                                    // menu up 
        MENUDOWN,						                                    // menu down
        MENULEFT,						                                    // menu left
        MENURIGHT,						                                    // Menu right 
        ALARMHANDLE = 0x40,				                    // Alarm activate PTZ parm1:Alarm input channel;parm2:Alarm activation type  1-preset 2-scan 3-tour;parm 3:activation value,such as preset value.
        MATRIXSWITCH = 0x41,			                        // Matrix switch parm1:monitor number(video output number);parm2:video input number;parm3:matrix number 
        LIGHTCONTROL,					                                    // Light controller
        EXACTGOTO,						                                    // 3D accurately positioning parm1:Pan degree(0~3600); parm2: tilt coordinates(0~900); parm3:zoom(1~128)
        RESETZERO,                                                          // Reset  3D positioning as zero
        MOVE_ABSOLUTELY,                                                    // Absolute motion control command,param4 corresponding struct NET_PTZ_CONTROL_ABSOLUTELY
        MOVE_CONTINUOUSLY,                                                  // Continuous motion control command,param4 corresponding struct NET_PTZ_CONTROL_CONTINUOUSLY
        GOTOPRESET,                                                         // PTZ control command, at a certain speed to preset locu,parm4 corresponding struct NET_PTZ_CONTROL_GOTOPRESET
        SET_VIEW_RANGE = 0x49,                                 // Set to horizon(param4 corresponding struct NET_PTZ_VIEW_RANGE_INFO)
        FOCUS_ABSOLUTELY = 0x4A,                                 // Absolute focus(param4 corresponding struct NET_PTZ_FOCUS_ABSOLUTELY)
        HORSECTORSCAN = 0x4B,                                 // Level fan sweep(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        VERSECTORSCAN = 0x4C,                                 // Vertical sweep fan(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        SET_ABS_ZOOMFOCUS = 0x4D,                                 // Set absolute focus, focus on value, param1 for focal length, range: [0255], param2 as the focus, scope: [0255], param3, param4 is invalid
        SET_FISHEYE_EPTZ = 0x4E,                                 // Control fish eye PTZ,param4corresponding to structure NET_PTZ_CONTROL_SET_FISHEYE_EPTZ 
        SET_TRACK_START = 0x4F,                                 // Track start control(param4 corresponding to structure  NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE， param1、param2、param3 is invalid)
        SET_TRACK_STOP = 0x50,                                 // Track stop control (param4 corresponding to structure NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE，param1、param2、param3  is invalid)

        UP_TELE = 0x70,				                    // Up + TELE param1=speed (1-8) 
        DOWN_TELE,						                                    // Down + TELE
        LEFT_TELE,						                                    // Left + TELE
        RIGHT_TELE,						                                    // Right + TELE
        LEFTUP_TELE,					                                    // Upper left + TELE
        LEFTDOWN_TELE,					                                    // Down left + TELE
        TIGHTUP_TELE,					                                    // Upper right + TELE
        RIGHTDOWN_TELE,					                                    // Down right + TELE
        UP_WIDE,						                                    // Up + WIDE param1=speed (1-8) 
        DOWN_WIDE,						                                    // Down + WIDE
        LEFT_WIDE,						                                    // Left + WIDE
        RIGHT_WIDE,						                                    // Right + WIDE
        LEFTUP_WIDE,					                                    // Upper left + WIDE
        LEFTDOWN_WIDE,					                                    // Down left+ WIDE
        TIGHTUP_WIDE,					                                    // Upper right + WIDE
        RIGHTDOWN_WIDE,					                                    // Down right + WIDE
        TOTAL,							                                    // max command value
    }

    /// <summary>
    /// frame parameter structure of Callback video data frame
    /// </summary>
    public struct NET_VideoFrameParam
    {
        public byte encode;				    // Encode type 
        public byte frametype;				// I = 0, P = 1, B = 2...
        public byte format;			    	// PAL - 0, NTSC - 1
        public byte size;                   // CIF - 0, HD1 - 1, 2CIF - 2, D1 - 3, VGA - 4, QCIF - 5, QVGA - 6 ,
                                            // SVCD - 7,QQVGA - 8, SVGA - 9, XVGA - 10,WXGA - 11,SXGA - 12,WSXGA - 13,UXGA - 14,WUXGA - 15,
        public uint fourcc;				    // If it is H264 encode it is always 0,Fill in FOURCC('X','V','I','D') in MPEG 4;
        public uint reserved;				// Reserved
        public NET_TIME struTime;			    // Time information 
    }

    /// <summary>
    /// frame parameter structure of audio data callback 
    /// </summary>
    public struct NET_CBPCMDataParam
    {
        public byte channels;				// Track amount 
        public byte samples;				// sample 0 - 8000, 1 - 11025, 2 - 16000, 3 - 22050, 4 - 32000, 5 - 44100, 6 - 48000
        public byte depth;					// Sampling depth. Value:8/16 show directly
        public byte param1;				    // 0 - indication no symbol,1-indication with symbol
        public uint reserved;				// Reserved
    }

    /// <summary>
    /// internet Time structure
    /// </summary>
    public struct NET_TIME
    {
        public uint dwYear;                 // Year
        public uint dwMonth;                // Month
        public uint dwDay;                  // Day
        public uint dwHour;                 // Hour
        public uint dwMinute;               // Minute
        public uint dwSecond;               // Second
        public static NET_TIME FromDateTime(DateTime dateTime)
        {
            try
            {
                NET_TIME net_time = new NET_TIME();
                net_time.dwYear = (uint)dateTime.Year;
                net_time.dwMonth = (uint)dateTime.Month;
                net_time.dwDay = (uint)dateTime.Day;
                net_time.dwHour = (uint)dateTime.Hour;
                net_time.dwMinute = (uint)dateTime.Minute;
                net_time.dwSecond = (uint)dateTime.Second;
                return net_time;
            }
            catch
            {
                return new NET_TIME();
            }
        }
        public DateTime ToDateTime()
        {
            try
            {
                return new DateTime((int)dwYear, (int)dwMonth, (int)dwDay, (int)dwHour, (int)dwMinute, (int)dwSecond);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"));
        }
    }

    /// <summary>
    /// control playback type
    /// </summary>
    public enum PlayBackType
    {
        Play,                                                               // play
        Pause,                                                              // pause
        Stop,                                                               // stop
        Fast,                                                               // fast
        Slow,                                                               // slow
        Normal,                                                             // normal
    }

    /// <summary>
    /// user work mode enumeration
    /// </summary>
    public enum EM_USEDEV_MODE
    {
        TALK_CLIENT_MODE,						                            // Set client-end mode to begin audio talk 
        TALK_SERVER_MODE,						                            // Set server mode to begin audio talk 
        TALK_ENCODE_TYPE,						                            // Set encode format for audio talk,corresponding structure NET_DEV_TALKDECODE_INFO
        ALARM_LISTEN_MODE,						                            // Set alarm subscribe way 
        CONFIG_AUTHORITY_MODE,					                            // Set user right to realize configuration management
        TALK_TALK_CHANNEL,						                            // set talking channel(0~MaxChannel-1)
        RECORD_STREAM_TYPE,                                                 // set the stream type of the record for query(0-both main and extra stream,1-only main stream,2-only extra stream)  
        TALK_SPEAK_PARAM,                                                   // set speaking parameter,corresponding structure NET_SPEAK_PARAM
        RECORD_TYPE,                                                        // Set by time video playback and download the video file TYPE,see to EM_RECORD_TYPE
        TALK_MODE3,								                            // Set voice intercom parameters of three generations of equipment and the corresponding structure NET_TALK_EX
        PLAYBACK_REALTIME_MODE,                                             // set real time playback function(0-off,1-on)
        TALK_TRANSFER_MODE,                                                 // judge the voice intercom if it was a forwarding mode, (corresponding to  NET_TALK_TRANSFER_PARAM)
        TALK_VT_PARAM,                                                      // set VT parameters,corresponding structure NET_VT_TALK_PARAM
        TARGET_DEV_ID,                                                      // set target device identifier for searching system capacity information, (not zero - locate device forwards the information)
    }

    /// <summary>
    /// audio encode information structure
    /// </summary>
    public struct NET_DEV_TALKDECODE_INFO
    {
        public EM_TALK_CODING_TYPE encodeType;              // Encode type 
        public int nAudioBit;               // Bit:8/16
        public uint dwSampleRate;		    // Sampling rate such as 8000 or 16000
        public int nPacketPeriod;          // Pack Period,Unit ms
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] reserved;               // resrved
    }

    /// <summary>
    /// audio encode type enumeration
    /// </summary>
    public enum EM_TALK_CODING_TYPE
    {
        DEFAULT = 0,						                                // No-head PCM
        PCM = 1,							                                // With head PCM
        G711a,								                                // G711a
        AMR,								                                // AMR
        G711u,								                                // G711u
        G726,								                                // G726
        G723_53,							                                // G723_53
        G723_63,							                                // G723_63
        AAC,								                                // AAC
        OGG,                                                                // OGG
        G729 = 10,                                                          // G729
        MPEG2,                                                              // MPEG2
        MPEG2_Layer2,                                                       // MPEG2-Layer2
        G722_1,                                                             // G.722.1
        ADPCM = 21,                                                         // ADPCM
        MP3 = 22,							                                // MP3
    }

    /// <summary>
    /// speak information structure
    /// </summary>
    public struct NET_SPEAK_PARAM
    {
        public uint dwSize;                         // struct size 
        public int nMode;                          // 0:talk back(default), 1: propaganda,from propaganda ro talk back,need afresh to configure
        public int nSpeakerChannel;                // reproducer channel
        public bool bEnableWait;                    // Wait for device to responding or not when enable bidirectional talk. Default setup is no.TRUE:wait ;FALSE:no
    }

    /// <summary>
    /// record file type
    /// </summary>
    public enum EM_RECORD_TYPE
    {
        ALL,                                                                // All the video
        NORMAL,                                                             // common  video
        ALARM,                                                              // External alarm video
        MOTION,                                                             // DM alarm video
    }

    /// <summary>
    /// extend talk information for EM_USEDEV_MODE.TALK_MODE3
    /// </summary>
    public struct NET_TALK_EX
    {
        public uint dwSize;                         // struct size
        public int nChannel;                       // channel number 
        public int nAudioPort;                     // Audio transmission listener ports
        public int nWaitTime;                      // Ms wait time, unit, use the default value is 0
        public IntPtr hVideoWnd;                        // Visual talk video window
        public NET_TALK_VIDEO_FORMAT stuVideoFmt;			        // Video encode format
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] szMulticastAddr;                // Multicast address
        public ushort wMulticastLocalPort;          // Multicast local port
        public ushort wMulticastRemotePort;	        // Multicast remote port
    }

    /// <summary>
    /// video format information
    /// </summary>
    public struct NET_TALK_VIDEO_FORMAT
    {
        public uint dwSize;                         // struct size
        public uint dwCompression;                  // Video compression format
        public int nFrequency;				        // Video sampling frequency
    }

    /// <summary>
    /// open the forwarding mode of intercom or not 
    /// </summary>
    public struct NET_TALK_TRANSFER_PARAM
    {
        public uint dwSize;                         // struct size
        public bool bTransfer;                      // Open the forwarding mode of intercom or not, TRUE: yes, FALSE: no
    }

    /// <summary>
    /// talk about VT information
    /// </summary>
    public struct NET_VT_TALK_PARAM
    {
        public uint dwSize;                         // struct size
        public int nValidFlag;                     // identity filed is valid by bitwise.see EM_VT_PARAM_VALID
        public fVtEventCallBack pfEventCb;                      // event call back, EM_VT_PARAM_VALID.EVENT_CB is valid
        public IntPtr dwUser;                         // call back user data, EM_VT_PARAM_VALID.USER_DATA is valid
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szPeerMidNum;                   // Mid-number(the called number), 8byte, EM_VT_PARAM_VALID.MID_NUM is valid
        public EM_NEWCALL_ACTION emAction;                       // call operation, 0:no-operation, 1:repulse, 2:accept, EM_VT_PARAM_VALID.ACTION is valid
        public int nWaitTime;                      // waitting time(ms), EM_VT_PARAM_VALID.WAITTIME is valid
        public IntPtr hVideoWnd;                      // handle for show video, EM_VT_PARAM_VALID.VIDEOWND is valid
        public bool bClient;                        // talk mode, true:client, false:server, EM_VT_PARAM_VALID.CSMODE is valid
        public NET_DEV_TALKDECODE_INFO stAudioEncode;                  // talk decode information.
    }

    /// <summary>
    /// call operation  for VT 
    /// </summary>
    public enum EM_NEWCALL_ACTION
    {
        UNKNOWN,                                                            // no-operation
        REFUSE,                                                             // repulse
        ACCEPT,                                                             // accept
    }

    /// <summary>
    /// valid paramter for VT
    /// </summary>
    public enum EM_VT_PARAM_VALID
    {
        EVENT_CB = 0x0001,                               // event call back
        USER_DATA = 0x0002,                               // user data
        MID_NUM = 0x0004,                               // Mid-number
        ACTION = 0x0008,                               // call operation
        WAITTIME = 0x0010,                               // waitting time
        VIDEOWND = 0x0020,                               // handle for show video
        CSMODE = 0x0040,                               // talk mode
        AUDIO_ENCODE = 0x0080,                               // audio encode
        LOCAL_IP = 0x0100,                               // local ip
    }

    /// <summary>
    /// event type
    /// </summary>
    public enum EM_AUDIO_CB_FLAG
    {
        UNKNOWN,                                                            // unknow
        NEWCALL,                                                            // new call
        REMOTE_HANGUP,                                                      // hangup
        DISCONNECT,                                                         // disconncet
        RING,                                                               // ring
    }

    /// <summary>
    /// record play back parameter in
    /// </summary>
    public struct NET_IN_PLAY_BACK_BY_TIME_INFO
    {
        public NET_TIME stStartTime;                            // Begin time
        public NET_TIME stStopTime;                             // End time
        public IntPtr hWnd;                                   // Play window
        public fDownLoadPosCallBack cbDownLoadPos;                          // Download pos callback
        public IntPtr dwPosUser;                              // Pos user
        public fDataCallBack fDownLoadDataCallBack;                  // Download data callback
        public IntPtr dwDataUser;                             // Data user
        public int nPlayDirection;                         // Playback direction
        public int nWaittime;                              // Watiting time
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bReserved;                              // Reserved
    }

    /// <summary>
    /// record play back parameter out
    /// </summary>
    public struct NET_OUT_PLAY_BACK_BY_TIME_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bReserved;                               // Reserved
    }

    /// <summary>
    /// record file information
    /// </summary>
    public struct NET_RECORDFILE_INFO
    {
        public uint ch;						                    // Channel number
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 124)]
        public string filename;                                 // File name 
        public uint framenum;                                   // the total number of file frames
        public uint size;					                    // File length 
        public NET_TIME starttime;				                    // Start time 
        public NET_TIME endtime;				                    // End time 
        public uint driveno;				                    // HDD number, 0－127 is the local record. 128-network record
        public uint startcluster;                               // Start cluster number 
        public byte nRecordFileType;                            // Recorded file type  0:general record;1:alarm record ;2:motion detection;3:card number record ;4:image ;255:all
        public byte bImportantRecID;                            // 0:general record 1:Important record
        public byte bHint;                                      // Document Indexing
        public byte bRecType;                                   // 0-main stream record 1-sub1 stream record 2-sub2 stream record 3-sub3 stream record
    }

    /// <summary>
    /// type of video search
    /// </summary>
    public enum EM_QUERY_RECORD_TYPE
    {

        ALL = 0,                                               // All the recorded video  
        ALARM = 1,                                               // The video of external alarm
        MOTION_DETECT = 2,                                               // The video of dynamic detection alarm
        ALARM_ALL = 3,                                               // All the alarmed video
        CARD = 4,                                               // query by the card number
        CONDITION = 5,                                               // query by condition
        JOIN = 6,                                               // combination query 
        CARD_PICTURE = 8,                                               // query pictures by the card number, used by HB-U and NVS
        PICTURE = 9,                                               // query pictures, used by HB-U and NVS
        FIELD = 10,                                              // query by field
        INTELLI_VIDEO = 11,			                                    // Smart record search 
        NET_DATA = 15,                                              // query network data, used by Jinqiao Internet Bar
        TRANS_DATA = 16,                                              // query the video of serial data
        IMPORTANT = 17,                                              // query the important video
        TALK_DATA = 18,                                              // query the recording file

        INVALID = 256,                                             // invalid query type
    }

    /// <summary>
    /// alarm type,used in fMessCallBackEx
    /// </summary>
    public enum EM_ALARM_TYPE
    {
        COMM_ALARM = 0x1100,		// General alarm(Including external alarm, video loss and motion detection)
        SHELTER_ALARM = 0x1101,		// Camera masking alarm 
        DISK_FULL_ALARM = 0x1102,		// HDD full alarm 
        DISK_ERROR_ALARM = 0x1103,		// HDD malfunction alarm 
        SOUND_DETECT_ALARM = 0x1104,		// Audio detection alarm 
        ALARM_DECODER_ALARM = 0x1105,		// Alarm decoder alarm 

        ALARM_ALARM_EX = 0x2101,		// External alarm ,data's length(byte) is same to device's alarm channels' count, 1 means 
        MOTION_ALARM_EX = 0x2102,		// Motion detection alarm 
        VIDEOLOST_ALARM_EX = 0x2103,		// Video loss alarm 
        SHELTER_ALARM_EX = 0x2104,		// Camera masking alarm 
        SOUND_DETECT_ALARM_EX = 0x2105,		// Audio detection alarm 
        DISKFULL_ALARM_EX = 0x2106,		// HDD full alarm 
        DISKERROR_ALARM_EX = 0x2107,		// HDD malfunction alarm 
        ENCODER_ALARM_EX = 0x210A,		// Encoder alarm 
        URGENCY_ALARM_EX = 0x210B,		// Emergency alarm 
        WIRELESS_ALARM_EX = 0x210C,		// Wireless alarm 
        NEW_SOUND_DETECT_ALARM_EX = 0x210D,		// New auido detection alarm. Please refer to NET_NEW_SOUND_ALARM_STATE for alarm information structure;
        ALARM_DECODER_ALARM_EX = 0x210E,		// Alarm decoder alarm 
        DECODER_DECODE_ABILITY = 0x210F,		// NVD:Decoding capacity
        FDDI_DECODER_ABILITY = 0x2110,		// Fiber encoder alarm
        PANORAMA_SWITCH_ALARM_EX = 0x2111,		// Panorama switch alarm
        LOSTFOCUS_ALARM_EX = 0x2112,		// Lost focus alarm
        OEMSTATE_EX = 0x2113,		// oem state
        DSP_ALARM_EX = 0x2114,		// DSP alarm
        ATMPOS_BROKEN_EX = 0x2115,		// atm and pos disconnection alarm, 0:disconnection 1:connection
        RECORD_CHANGED_EX = 0x2116,		// Record state changed alarm
        CONFIG_CHANGED_EX = 0x2117,		// Device config changed alarm
        DEVICE_REBOOT_EX = 0x2118,		// Device rebooting alarm
        WINGDING_ALARM_EX = 0x2119,       // CoilFault alarm
        TRAF_CONGESTION_ALARM_EX = 0x211A,       // traffic congestion alarm
        TRAF_EXCEPTION_ALARM_EX = 0x211B,       // traffic exception alarm
        EQUIPMENT_FILL_ALARM_EX = 0x211C,       // FlashFault alarm
        ALARM_ARM_DISARM_STATE = 0x211D,		// alarm arm disarm 
        ALARM_ACC_POWEROFF = 0x211E,       // ACC power off alarm
        ALARM_3GFLOW_EXCEED = 0x211F,       // Alarm of 3G flow exceed(see struct NET_DEV_3GFLOW_EXCEED_STATE_INFO)
        ALARM_SPEED_LIMIT = 0x2120,       // Speed limit alarm 
        ALARM_VEHICLE_INFO_UPLOAD = 0x2121,       // Vehicle information uploading 
        STATIC_ALARM_EX = 0x2122,       // Static detection alarm
        PTZ_LOCATION_EX = 0x2123,       // ptz location info
        ALARM_CARD_RECORD_UPLOAD = 0x2124,		// card record info(struct NET_ALARM_CARD_RECORD_INFO_UPLOAD)
        ALARM_ATM_INFO_UPLOAD = 0x2125,		// ATM trade info(struct NET_ALARM_ATM_INFO_UPLOAD)
        ALARM_ENCLOSURE = 0x2126,       // enclosure alarm(struct NET_ALARM_ENCLOSURE_INFO)
        ALARM_SIP_STATE = 0x2127,       // SIP state alarm(struct NET_ALARM_SIP_STATE)
        ALARM_RAID_STATE = 0x2128,       // RAID state alarm(struct NET_ALARM_RAID_INFO)
        ALARM_CROSSING_SPEED_LIMIT = 0x2129,	    // crossing speed limit alarm(struct NET_ALARM_SPEED_LIMIT)
        ALARM_OVER_LOADING = 0x212A,       // over loading alarm(struct NET_ALARM_OVER_LOADING)
        ALARM_HARD_BRAKING = 0x212B,       // hard brake alarm(struct NET_ALARM_HARD_BRAKING)
        ALARM_SMOKE_SENSOR = 0x212C,       // smoke sensor alarm(struct NET_ALARM_SMOKE_SENSOR)
        ALARM_TRAFFIC_LIGHT_FAULT = 0x212D,       // traffic light fault alarm(struct NET_ALARM_TRAFFIC_LIGHT_FAULT) 
        ALARM_TRAFFIC_FLUX_STAT = 0x212E,       // traffic flux alarm(struct NET_ALARM_TRAFFIC_FLUX_LANE_INFO)
        ALARM_CAMERA_MOVE = 0x212F,       // camera move alarm(struct NET_ALARM_CAMERA_MOVE_INFO)
        ALARM_DETAILEDMOTION = 0x2130,       // detailed motion alarm(struct NET_ALARM_DETAILEDMOTION_CHNL_INFO)
        ALARM_STORAGE_FAILURE = 0x2131,       // storage failure alarm(struct NET_ALARM_STORAGE_FAILURE)
        ALARM_FRONTDISCONNECT = 0x2132,       // front IPC disconnect alarm(struct NET_ALARM_FRONTDISCONNET_INFO)
        ALARM_ALARM_EX_REMOTE = 0x2133,       // remote external alarm
        ALARM_BATTERYLOWPOWER = 0x2134,       // battery low power alarm(struct NET_ALARM_BATTERYLOWPOWER_INFO)
        ALARM_TEMPERATURE = 0x2135,       // temperature alarm(struct NET_ALARM_TEMPERATURE_INFO)
        ALARM_TIREDDRIVE = 0x2136,       // tired drive alarm(struct NET_ALARM_TIREDDRIVE_INFO)
        ALARM_LOST_RECORD = 0x2137,       // Alarm of record loss (corresponding structure NET_ALARM_LOST_RECORD)
        ALARM_HIGH_CPU = 0x2138,       // Alarm of High CPU Occupancy rate (corresponding structure NET_ALARM_HIGH_CPU) 
        ALARM_LOST_NETPACKET = 0x2139,       // Alarm of net package loss (corresponding structure NET_ALARM_LOST_NETPACKET)
        ALARM_HIGH_MEMORY = 0x213A,       // Alarm of high memory occupancy rate(corresponding structure NET_ALARM_HIGH_MEMORY)
        LONG_TIME_NO_OPERATION = 0x213B,	    // WEB user have no operation for long time (no extended info)
        BLACKLIST_SNAP = 0x213C,       // blacklist snap(corresponding to NET_BLACKLIST_SNAP_INFO)         
        ALARM_DISK = 0x213E,		// alarm of disk(corresponding to NET_ALARM_DISK_INFO)
        ALARM_FILE_SYSTEM = 0x213F,		// alarm of file systemcorresponding to NET_ALARM_FILE_SYSTEM_INFO)
        ALARM_IVS = 0x2140,       // alarm of ivs(corresponding to NET_ALARM_IVS_INFO)
        ALARM_GOODS_WEIGHT_UPLOAD = 0x2141,		// goods weight (corresponding to NET_ALARM_GOODS_WEIGHT_UPLOAD_INFO)
        ALARM_GOODS_WEIGHT = 0x2142,		// alarm of goods weight(corresponding to NET_ALARM_GOODS_WEIGHT_INFO)
        GPS_STATUS = 0x2143,       // GPS orientation info(corresponding to NET_GPS_STATUS_INFO)
        ALARM_DISKBURNED_FULL = 0x2144,       // alarm disk burned full(corresponding to NET_ALARM_DISKBURNED_FULL_INFO)
        ALARM_STORAGE_LOW_SPACE = 0x2145,		// storage low space(corresponding to NET_ALARM_STORAGE_LOW_SPACE_INFO)
        ALARM_DISK_FLUX = 0x2160,		// disk flux abnormal(corresponding to NET_ALARM_DISK_FLUX)
        ALARM_NET_FLUX = 0x2161,		// net flux abnormal(corresponding to NET_ALARM_NET_FLUX)
        ALARM_FAN_SPEED = 0x2162,		// fan speed abnormal(corresponding to NET_ALARM_FAN_SPEED)
        ALARM_STORAGE_FAILURE_EX = 0x2163,       // storage mistake(corresponding to NET_ALARM_STORAGE_FAILURE_EX)
        ALARM_RECORD_FAILED = 0x2164,		// record abnormal(corresponding to NET_ALARM_RECORD_FAILED_INFO)
        ALARM_STORAGE_BREAK_DOWN = 0x2165,		// storage break down(corresponding to NET_ALARM_STORAGE_BREAK_DOWN_INFO)
        ALARM_VIDEO_ININVALID = 0x2166,       // NET_ALARM_VIDEO_ININVALID_INFO
        ALARM_VEHICLE_TURNOVER = 0x2167,		// vehicle turnover arm event(struct NET_ALARM_VEHICEL_TURNOVER_EVENT_INFO)
        ALARM_VEHICLE_COLLISION = 0x2168,       // vehicle collision event(struct NET_ALARM_VEHICEL_COLLISION_EVENT_INFO)
        ALARM_VEHICLE_CONFIRM = 0x2169,       // vehicle confirm information event(struct NET_ALARM_VEHICEL_CONFIRM_INFO)
        ALARM_VEHICLE_LARGE_ANGLE = 0x2170,       // vehicle camero large angle event(struct NET_ALARM_VEHICEL_LARGE_ANGLE)
        ALARM_TALKING_INVITE = 0x2171,		// device talking invite event (struct NET_ALARM_TALKING_INVITE_INFO)
        ALARM_ALARM_EX2 = 0x2175,		// local alarm event (struct NET_ALARM_ALARM_INFO_EX2)
        ALARM_VIDEO_TIMING = 0x2176,       // video timing detecting event(struct NET_ALARM_VIDEO_TIMING)
        ALARM_COMM_PORT = 0x2177,       // COM event(struct NET_ALARM_COMM_PORT_EVENT_INFO)
        ALARM_AUDIO_ANOMALY = 0x2178,       // audio anomaly event(struct NET_ALARM_AUDIO_ANOMALY)
        ALARM_AUDIO_MUTATION = 0x2179,       // audio mutation event(struct NET_ALARM_AUDIO_MUTATION)
        EVENT_TYREINFO = 0x2180,       // Tyre information report event (struct NET_EVENT_TYRE_INFO)
        ALARM_POWER_ABNORMAL = 0X2181,       // Redundant power supplies abnormal alarm(struct NET_ALARM_POWER_ABNORMAL_INFO)
        EVENT_REGISTER_OFF = 0x2182,		// On-board equipment active offline events(struct  NET_EVENT_REGISTER_OFF_INFO)
        ALARM_NO_DISK = 0x2183,       // No hard disk alarm(struct NET_ALARM_NO_DISK_INFO)
        ALARM_FALLING = 0x2184,       // The fall alarm(struct NET_ALARM_FALLING_INFO)
        ALARM_PROTECTIVE_CAPSULE = 0x2185,       // Protective capsule event(corresponding structure NET_ALARM_PROTECTIVE_CAPSULE_INFO)
        ALARM_NO_RESPONSE = 0x2186,       // Call Non-response alarm(corresponding to NET_ALARM_NO_RESPONSE_INFO)
        ALARM_CONFIG_ENABLE_CHANGE = 0x2187,       // Config enable to change reported event(corresponding to structure  NET_ALARM_CONFIG_ENABLE_CHANGE_INFO)
        EVENT_CROSSLINE_DETECTION = 0x2188,       // Cross warning line event( Corresponding to structure NET_ALARM_EVENT_CROSSLINE_INFO )
        EVENT_CROSSREGION_DETECTION = 0x2189,       // Warning zone event(Corresponding to structure NET_ALARM_EVENT_CROSSREGION_INFO )
        EVENT_LEFT_DETECTION = 0x218a,       // Abandoned object event(Corresponding to structure NET_ALARM_EVENT_LEFT_INFO )
        EVENT_FACE_DETECTION = 0x218b,       // Human face detect event(Corresponding to structure NET_ALARM_EVENT_FACE_INFO ) 
        ALARM_IPC = 0x218c,       // IPC alarm,IPC upload local alarm via DVR or NVR(Corresponding to structure NET_ALARM_IPC_INFO)
        EVENT_TAKENAWAYDETECTION = 0x218d,       // Missing object event(Corresponding to structure NET_ALARM_TAKENAWAY_DETECTION_INFO)
        EVENT_VIDEOABNORMALDETECTION = 0x218e,       // Video abnormal event(Corresponding to structure NET_ALARM_VIDEOABNORMAL_DETECTION_INFO)
        EVENT_MOTIONDETECT = 0x218f,       // Video motion detect event  (Corresponding to structure NET_ALARM_MOTIONDETECT_INFO)
        ALARM_PIR = 0x2190,       // PIR alarm (Corresponding to BYTE*, pBuf length dwBufLen)
        ALARM_STORAGE_HOT_PLUG = 0x2191,       // Storage hot swap event(Corresponding to structure NET_ALARM_STORAGE_HOT_PLUG_INFO)
        ALARM_FLOW_RATE = 0x2192,		// the event of rate of flow(Corresponding to structure NET_ALARM_FLOW_RATE_INFO)
        ALARM_MOVEDETECTION = 0x2193,		// Move detection event(Corresponding to structure NET_ALARM_MOVE_DETECTION_INFO)
        ALARM_WANDERDETECTION = 0x2194,		// WanderDetection event(Corresponding to structure NET_ALARM_WANDERDETECTION_INFO)
        ALARM_CROSSFENCEDETECTION = 0x2195,		// cross fence(Corresponding to NET_ALARM_CROSSFENCEDETECTION_INFO)
        ALARM_PARKINGDETECTION = 0x2196,		// parking detection event(Corresponding to NET_ALARM_PARKINGDETECTION_INFO)
        ALARM_RIOTERDETECTION = 0x2197,     // Rioter detection event(Corresponding to NET_ALARM_RIOTERDETECTION_INFO)

        ALARM_STORAGE_NOT_EXIST = 0x3167,		// A storage group does not exist(struct NET_ALARM_STORAGE_NOT_EXIST_INFO)
        ALARM_NET_ABORT = 0x3169,		// Network fault event(struct NET_ALARM_NETABORT_INFO)
        ALARM_IP_CONFLICT = 0x3170,	    // IP conflict event(struct NET_ALARM_IP_CONFLICT_INFO)
        ALARM_MAC_CONFLICT = 0x3171,		// MAC conflict event(struct NET_ALARM_MAC_CONFLICT_INFO)
        ALARM_POWERFAULT = 0x3172,		// power fault event(struct NET_ALARM_POWERFAULT_INFO)
        ALARM_CHASSISINTRUDED = 0x3173,		// Chassis intrusion, tamper alarm events(struct NET_ALARM_CHASSISINTRUDED_INFO)
        ALARM_ALARMEXTENDED = 0x3174,       // Native extension alarm events(struct NET_ALARM_ALARMEXTENDED_INFO)

        ALARM_ARMMODE_CHANGE_EVENT = 0x3175,		// Cloth removal state change events(struct NET_ALARM_ARMMODE_CHANGE_INFO)
        ALARM_BYPASSMODE_CHANGE_EVENT = 0x3176,     // The bypass state change events(struct NET_ALARM_BYPASSMODE_CHANGE_INFO)

        ALARM_ACCESS_CTL_NOT_CLOSE = 0x3177,		// Entrance guard did not close events(struct NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO)
        ALARM_ACCESS_CTL_BREAK_IN = 0x3178,		// break-in event(struct NET_ALARM_ACCESS_CTL_BREAK_IN_INFO)
        ALARM_ACCESS_CTL_REPEAT_ENTER = 0x3179,		//access Again and again event(struct NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO)
        ALARM_ACCESS_CTL_DURESS = 0x3180,		// Stress CARDS event(struct NET_ALARM_ACCESS_CTL_DURESS_INFO)
        ALARM_ACCESS_CTL_EVENT = 0x3181,        // Access event(struct NET_ALARM_ACCESS_CTL_EVENT_INFO)

        URGENCY_ALARM_EX2 = 0x3182,       // Emergency ALARM EX2(struct NET_ALARM_URGENCY_ALARM_EX2, Artificially triggered emergency, general processing is linked external communication function requests for help
        ALARM_INPUT_SOURCE_SIGNAL = 0x3183,       // Alarm input source signal events (as long as there is input will generate the event, whether to play the current mode, unable to block, struct NET_ALARM_INPUT_SOURCE_SIGNAL_INFO)
        ALARM_ANALOGALARM_EVENT = 0x3184,       //  analog alarm(struct NET_ALARM_ANALOGALARM_EVENT_INFO)
        ALARM_ACCESS_CTL_STATUS = 0x3185,       // Access control status event(corresponding structure NET_ALARM_ACCESS_CTL_STATUS_INFO)
        ALARM_ACCESS_SNAP = 0x3186,       // Access control snapshot event(corresponding to NET_ALARM_ACCESS_SNAP_INFO)
        ALARM_ALARMCLEAR = 0x3187,       // Cancel alarm(corresponding to structure NET_ALARM_ALARMCLEAR_INFO)
        ALARM_CIDEVENT = 0x3188,       // CID event(corresponding to structure NET_ALARM_CIDEVENT_INFO)
        ALARM_TALKING_HANGUP = 0x3189,       // Device hand up evnt(corresponding to structure NET_ALARM_TALKING_HANGUP_INFO)
        ALARM_BANKCARDINSERT = 0x318a,       // Bank card evnt(corresponding to structure NET_ALARM_BANKCARDINSERT_INFO)
        ALARM_RCEMERGENCY_CALL = 0x318b,       // Emergency call alarm event(corresponding to structure NET_ALARM_RCEMERGENCY_CALL_INFO)
        ALARM_OPENDOORGROUP = 0x318c,       // Multi-people group unlock event(corresponding to  structure NET_ALARM_OPEN_DOOR_GROUP_INFO)
        ALARM_FINGER_PRINT = 0x318d,       // get fingerprint event(corresponding to  structure NET_ALARM_CAPTURE_FINGER_PRINT_INFO)
        ALARM_CARD_RECORD = 0x318e,       // card no. record event(corresponding to  structure  NET_ALARM_CARD_RECORD_INFO)
        ALARM_SUBSYSTEM_STATE_CHANGE = 0x318f,       // sub system status change event(corresponding to  structure NET_ALARM_SUBSYSTEM_STATE_CHANGE_INFO)
        ALARM_BATTERYPOWER_EVENT = 0x3190,       // battery scheduled warning event(corresponding to  structure NET_ALARM_BATTERYPOWER_INFO)
        ALARM_BELLSTATUS_EVENT = 0x3191,       // bell status event(corresponding to  structure NET_ALARM_BELLSTATUS_INFO)
        ALARM_DEFENCE_STATE_CHANGE_EVENT = 0x3192,       // zone status change event(corresponding to  structure NET_ALARM_DEFENCE_STATUS_CHANGE_INFO), 
                                                         // customized need￡?and arm/disarm change event, bypass event status have different definitions,
                                                         // The status via QueryDevState port NET_DEVSTATE_DEFENCE_STATE command get
        ALARM_TICKET_STATISTIC = 0x3193,       // ticket statistics info event(corresponding to  structure  NET_ALARM_TICKET_STATISTIC)
        ALARM_LOGIN_FAILIUR = 0x3194,       // login failed event(corresponding to  structure NET_ALARM_LOGIN_FAILIUR_INFO)
        ALARM_MODULE_LOST = 0x3195,       // expansion module offline event(corresponding to  structure  NET_ALARM_MODULE_LOST_INFO)
        ALARM_PSTN_BREAK_LINE = 0x3196,       // PSTN offline event(corresponding to  structure NET_ALARM_PSTN_BREAK_LINE_INFO)
        ALARM_ANALOG_PULSE = 0x3197,       // analog alarm evnet(instant event), specific sensor  trigger(corresponding to  structure NET_ALARM_ANALOGPULSE_INFO)
        ALARM_MISSION_CONFIRM = 0x3198,       // task confirmation event(corresponding to  structure  NET_ALARM_MISSION_CONFIRM_INFO)
        ALARM_DEVICE_MSG_NOTIFY = 0x3199,       // device to platform notice event?t(corresponding to  structure  NET_ALARM_DEVICE_MSG_NOTIFY_INFO)
        ALARM_VEHICLE_STANDING_OVER_TIME = 0x319A,       // parking timeout event(corresponding to  structure  NET_ALARM_VEHICLE_STANDING_OVER_TIME_INFO)
        ALARM_ENCLOSURE_ALARM = 0x319B,       // e-fence event(corresponding to  structure  NET_ALARM_ENCLOSURE_ALARM_INFO)
        ALARM_GUARD_DETECT = 0x319C,	    // station detection event, one in station first report the start event and last on in station report stop event before leave (corresponding to  structure NET_ALARM_GUARD_DETECT_INFO)
        ALARM_GUARD_INFO_UPDATE = 0x319D,	    // station info update event￡?report if people in station(corresponding to  structure NET_ALARM_GUARD_UPDATE_INFO)  
        ALARM_NODE_ACTIVE = 0x319E,       // Node activation event (corresponding to structure NET_ALARM_NODE_ACTIVE_INFO)
        ALARM_VIDEO_STATIC = 0x319F,       // Video static detection event (corresponding to structure NET_ALARM_VIDEO_STATIC_INFO)
        ALARM_REGISTER_REONLINE = 0x31a0,       // Active registration device re-login event (corresponding to structure NET_ALARM_REGISTER_REONLINE_INFO)
        ALARM_ISCSI_STATUS = 0x31a1,       // ISCSI alarm event (corresponding to structure NET_ALARM_ISCSI_STATUS_INFO)
        ALARM_SCADA_DEV_ALARM = 0x31a2,       // detection collection device alarm event (corresponding to structure NET_ALARM_SCADA_DEV_INFO)
        ALARM_AUXILIARY_DEV_STATE = 0x31a3,       // Sub device status(corresponding structure NET_ALARM_AUXILIARY_DEV_STATE)
        ALARM_PARKING_CARD = 0x31a4,       // Parking swipe card event(corresponding structure NET_ALARM_PARKING_CARD)
        ALARM_PROFILE_ALARM_TRANSMIT = 0x31a5,       // Alarm transmit event(corresponding structure NET_ALARM_PROFILE_ALARM_TRANSMIT_INFO)
        ALARM_VEHICLE_ACC = 0x31a6,       // Vehicle acc event(corresponding structure NET_ALARM_VEHICLE_ACC_INFO)
        ALARM_TRAFFIC_SUSPICIOUSCAR = 0x31a7,       // suspiciouscar event(corresponding structure NET_ALARM_TRAFFIC_SUSPICIOUSCAR_INFO)
        ALARM_ACCESS_LOCK_STATUS = 0x31a8,       // the event of latch state (corresponding structure  NET_ALARM_ACCESS_LOCK_STATUS_INFO)
        ALARM_FINACE_SCHEME = 0x31a9,       // Finace scheme event(corresponding structure NET_ALARM_FINACE_SCHEME_INFO)
        ALARM_HEATIMG_TEMPER = 0x31aa,       // Thermal temperature abnormal event alarm(Corresponding to structure NET_ALARM_HEATIMG_TEMPER_INFO)
        ALARM_TALKING_IGNORE_INVITE = 0x31ab,       // Device cancel bidirectional talk query event(Corresponding to structure NET_ALARM_TALKING_IGNORE_INVITE_INFO)
        ALARM_BUS_SHARP_TURN = 0x31ac,       // Vehicle Abrupt-turn event(Corresponding to structure NET_ALARM_BUS_SHARP_TURN_INFO)
        ALARM_BUS_SCRAM = 0x31ad,       // vehicle abrupt stop event(Corresponding to structure NET_ALARM_BUS_SCRAM_INFO)
        ALARM_BUS_SHARP_ACCELERATE = 0x31ae,       // Vehicle abrupt speed up event(Corresponding to structure NET_ALARM_BUS_SHARP_ACCELERATE_INFO)
        ALARM_BUS_SHARP_DECELERATE = 0x31af,       // Vehicle abrupt slow down event (Corresponding to structure NET_ALARM_BUS_SHARP_DECELERATE_INFO)
        ALARM_ACCESS_CARD_OPERATE = 0x31b0,		// A&C data operation event (Corresponding to structure NET_ALARM_ACCESS_CARD_OPERATE_INFO)
        ALARM_POLICE_CHECK = 0x31b1,       // Policeman check in event(Corresponding to structure NET_ALARM_POLICE_CHECK_INFO)
        ALARM_NET = 0x31b2,       // Network alarm event(Corresponding to structure NET_ALARM_NET_INFO)
        ALARM_NEW_FILE = 0X31b3,       // New file event(Corresponding to structure NET_ALARM_NEW_FILE_INFO)

        ALARM_FIREWARNING = 0x31b5,       // Thermal fire position (Corresponding to structure NET_ALARM_FIREWARNING_INFO)
        ALARM_RECORD_LOSS = 0x31b6,       // Record loss event: the HDD is OK, delete results from misoperation.  (Corresponding to structure NET_ALARM_RECORD_LOSS_INFO)
        ALARM_VIDEO_FRAME_LOSS = 0x31b7,       // Frame loss event，it results from poor network environment or insufficient encode capability (Corresponding to structure NET_ALARM_VIDEO_FRAME_LOSS_INFO)
        ALARM_RECORD_VOLUME_FAILURE = 0x31b8,       // Abnormal record results from HDD volume(Corresponding to structure NET_ALARM_RECORD_VOLUME_FAILURE_INFO)
        EVENT_SNAP_UPLOAD = 0X31b9,       // Image upload completion event(Corresponding to structure NET_EVENT_SNAP_UPLOAD_INFO)
        ALARM_AUDIO_DETECT = 0x31ba,       // Audio detect event(Corresponding to structure NET_ALARM_AUDIO_DETECT )
        ALARM_UPLOADPIC_FAILCOUNT = 0x31bb,       // Failure data amount during the image upload process （Corresponding to structure NET_ALARM_UPLOADPIC_FAILCOUNT_INFO）
        ALARM_POS_MANAGE = 0x31bc,       // POS management event(Corresponding to NET_ALARM_POS_MANAGE_INFO )
        ALARM_REMOTE_CTRL_STATUS = 0x31bd,       // remote control status(Corresponding to NET_ALARM_REMOTE_CTRL_STATUS )
        ALARM_PASSENGER_CARD_CHECK = 0x31be,       // desuetude, passenger card check(Corresponding to structure NET_ALARM_PASSENGER_CARD_CHECK )
        ALARM_SOUND = 0x31bf,       // Sound event(Corresponding to NET_ALARM_SOUND )
        ALARM_LOCK_BREAK = 0x31c0,       // Lock break event(Corresponding to NET_ALARM_LOCK_BREAK_INFO )
        ALARM_HUMAN_INSIDE = 0x31c1,       // Human Inside event((Corresponding to structure NET_ALARM_HUMAN_INSIDE_INFO)
        ALARM_HUMAN_TUMBLE_INSIDE = 0x31c2,       // Human tumble Inside(Corresponding to structure NET_ALARM_HUMAN_TUMBLE_INSIDE_INFO)
        ALARM_DISABLE_LOCKIN = 0x31c3,       // Lock entry trigger event(Corresponding to structure NET_ALARM_DISABLE_LOCKIN_INFO)
        ALARM_DISABLE_LOCKOUT = 0x31c4,       // Lock go out trigger(Corresponding to structure NET_ALARM_DISABLE_LOCKOUT_INFO)
        ALARM_UPLOAD_PIC_FAILED = 0x31c5,       // break rules data upload failed (Corresponding to NET_ALARM_UPLOAD_PIC_FAILED_INFO )
        ALARM_FLOW_METER = 0x31c6,       // flow meter info event (NET_ALARM_FLOW_METER_INFO)
        ALARM_WIFI_SEARCH = 0x31c7,       // search around wifi device(Corresponding to NET_ALARM_WIFI_SEARCH_INFO)
        ALARM_WIRELESSDEV_LOWPOWER = 0X31C8,       // lowpower of wirelessdevice(NET_ALARM_WIRELESSDEV_LOWPOWER_INFO)
        ALARM_PTZ_DIAGNOSES = 0x31c9,		// Ptz Diagnoses event(Corresponding to NET_ALARM_PTZ_DIAGNOSES_INFO)
        ALARM_FLASH_LIGHT_FAULT = 0x31ca,       // flash light fault event (Corresponding to NET_ALARM_FLASH_LIGHT_FAULT_INFO)
        ALARM_STROBOSCOPIC_LIGTHT_FAULT = 0x31cb,       // stroboscopic light fault event (Corresponding to NET_ALARM_STROBOSCOPIC_LIGTHT_FAULT_INFO)
        ALARM_HUMAM_NUMBER_STATISTIC = 0x31cc,       // NumberStat event (Corresponding to NET_ALARM_HUMAN_NUMBER_STATISTIC_INFO)
        ALARM_VIDEOUNFOCUS = 0x31ce,       // Video unfocus (Corresponding NET_ALARM_VIDEOUNFOCUS_INFO)
        ALARM_BUF_DROP_FRAME = 0x31cd,       // Video recond buffer drop frame event(Corresponding to NET_ALARM_BUF_DROP_FRAME_INFO)
        ALARM_DOUBLE_DEV_VERSION_ABNORMAL = 0x31cf,       // Abnormal event when master broad'version and slave broad'version different  (Corresponding to NET_ALARM_DOUBLE_DEV_VERSION_ABNORMAL_INFO)
        ALARM_DCSSWITCH = 0x31d0,       // Switch with master and slave(Corresponding to NET_ALARM_DCSSWITCH_INFO)
        ALARM_RADAR_CONNECT_STATE = 0x31d1,       // Radar connect state(Corresponding to NET_ALARM_RADAR_CONNECT_STATE_INFO)
        ALARM_DEFENCE_ARMMODE_CHANGE = 0x31d2,       // Defence arming status change(Corresponding to NET_ALARM_DEFENCE_ARMMODECHANGE_INFO)
        ALARM_SUBSYSTEM_ARMMODE_CHANGE = 0x31d3,       // Subsystem arming status change(Corresponding to NET_ALARM_SUBSYSTEM_ARMMODECHANGE_INFO)
        ALARM_RFID_INFO = 0x31d4,       // infrared detection information event (Corresponding NET_ALARM_RFID_INFO)
        ALARM_SMOKE_DETECTION = 0x31d5,       // smoke detection(Corresponding NET_ALARM_SMOKE_DETECTION_INFO)
        ALARM_BETWEENRULE_TEMP_DIFF = 0x31d6,       // TemperatureDifference Between Rule (Corresponding NET_ALARM_BETWEENRULE_DIFFTEMPER_INFO)
        ALARM_TRAFFIC_PIC_ANALYSE = 0x31d7,		// Traffic picture analyse(Corresponding NET_ALARM_PIC_ANALYSE_INFO)
        ALARM_HOTSPOT_WARNING = 0x31d8,       // Hotspot warning(Corresponding NET_ALARM_HOTSPOT_WARNING_INFO)
        ALARM_COLDSPOT_WARNING = 0x31d9,       // coldspot warning(Corresponding NET_ALARM_COLDSPOT_WARNING_INFO)
        ALARM_FIREWARNING_INFO = 0x31da,       // firewarning (Corresponding NET_ALARM_FIREWARNING_INFO_DETAIL)
        ALARM_FACE_OVERHEATING = 0x31db,       // face overheating(Corresponding NET_ALARM_FACE_OVERHEATING_INFO)
        ALARM_SENSOR_ABNORMAL = 0X31dc,       // Sensor abnormal(Corresponding NET_ALARM_SENSOR_ABNORMAL_INFO)
        ALARM_PATIENTDETECTION = 0x31de,       // patient detection(Corresponding NET_ALARM_PATIENTDETECTION_INFO)
        ALARM_RADAR_HIGH_SPEED = 0x31df,       // radar high speed detection(Corresponding to NET_ALARM_RADAR_HIGH_SPEED_INFO)
        ALARM_POLLING_ALARM = 0x31e0,       // Polling Alarm (Corresponding to NET_ALARM_POLLING_ALARM_INFO)
        ALARM_ITC_HWS000 = 0x31e1,       // the alarm event for ITC_HWS000 (Corresponding NET_ALARM_ITC_HWS000)
        ALARM_TRAFFICSTROBESTATE = 0x31e2,       // Traffic Strobe State(Corresponding to NET_ALARM_TRAFFICSTROBESTATE_INFO)
        ALARM_TELEPHONE_CHECK = 0x31e3,       // telephone number check event(Corresponding to NET_ALARM_TELEPHONE_CHECK_INFO)
        ALARM_PASTE_DETECTION = 0x31e4,       // Paste Detection(Corresponding to NET_ALARM_PASTE_DETECTION_INFO )
        ALARM_SHOOTINGSCORERECOGNITION = 0x31e5,       // the alarm event for Shooting (Corresponding to NET_ALARM_PIC_SHOOTINGSCORERECOGNITION_INFO)
        ALARM_SWIPEOVERTIME = 0x31e6,       // the alarm event for swipe overtime(Corresponding to NET_ALARM_SWIPE_OVERTIME_INFO)
        ALARM_DRIVING_WITHOUTCARD = 0x31e7,       // the alarm event for driving without card(Corresponding to NET_ALARM_DRIVING_WITHOUTCARD_INFO)
        ALARM_TRAFFIC_PEDESTRIAN_RUN_REDLIGHT_DETECTION = 0x31e8,       //red light event (Corresponding to NET_ALARM_TRAFFIC_PEDESTRIAN_RUN_REDLIGHT_DETECTION_INFO)
        ALARM_FIGHTDETECTION = 0x31e9, 		//the alarm event for fight detection(Corresponding to NET_ALARM_FIGHTDETECTION)
    }

    /// <summary>
    /// intelligent event type,used in RealLoadPicture or fAnalyzerDataCallBack
    /// </summary>
    public enum EM_EVENT_IVS_TYPE
    {
        ALL = 0x00000001,		                // subscription all event
        CROSSLINEDETECTION = 0x00000002,		                // cross line event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO)
        CROSSREGIONDETECTION = 0x00000003,		                // cross region event(Corresponding to NET_DEV_EVENT_CROSSREGION_INFO)
        PASTEDETECTION = 0x00000004,		                // past event(Corresponding to NET_DEV_EVENT_PASTE_INFO)
        LEFTDETECTION = 0x00000005,		                // left event(Corresponding to NET_DEV_EVENT_LEFT_INFO)
        STAYDETECTION = 0x00000006,		                // stay event(Corresponding to NET_DEV_EVENT_STAY_INFO)
        WANDERDETECTION = 0x00000007,		                // wander event(Corresponding to NET_DEV_EVENT_WANDER_INFO)
        PRESERVATION = 0x00000008,		                // reservation event(Corresponding to NET_DEV_EVENT_PRESERVATION_INFO) 
        MOVEDETECTION = 0x00000009,		                // move event(Corresponding to NET_DEV_EVENT_MOVE_INFO)
        TAILDETECTION = 0x0000000A,		                // tail event(Corresponding to NET_DEV_EVENT_TAIL_INFO)
        RIOTERDETECTION = 0x0000000B,		                // rioter event(Corresponding to NET_DEV_EVENT_RIOTERL_INFO)
        FIREDETECTION = 0x0000000C,		                // fire event(Corresponding to NET_DEV_EVENT_FIRE_INFO)
        SMOKEDETECTION = 0x0000000D,		                // smoke event(Corresponding to NET_DEV_EVENT_SMOKE_INFO)
        FIGHTDETECTION = 0x0000000E,		                // fight event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
        FLOWSTAT = 0x0000000F,		                // flow stat event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
        NUMBERSTAT = 0x00000010,		                // number stat event(Corresponding to NET_DEV_EVENT_NUMBERSTAT_INFO)
        CAMERACOVERDDETECTION = 0x00000011,		                // camera cover event
        CAMERAMOVEDDETECTION = 0x00000012,		                // camera move event
        VIDEOABNORMALDETECTION = 0x00000013,		                // video abnormal event(Corresponding to NET_DEV_EVENT_VIDEOABNORMALDETECTION_INFO)
        VIDEOBADDETECTION = 0x00000014,		                // video bad event
        TRAFFICCONTROL = 0x00000015,		                // traffic control event(Corresponding to NET_DEV_EVENT_TRAFFICCONTROL_INFO)
        TRAFFICACCIDENT = 0x00000016,		                // traffic accident event(Corresponding to NET_DEV_EVENT_TRAFFICACCIDENT_INFO)
        TRAFFICJUNCTION = 0x00000017,		                // traffic junction event(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        TRAFFICGATE = 0x00000018,		                // traffic gate event(Corresponding to NET_DEV_EVENT_TRAFFICGATE_INFO)
        TRAFFICSNAPSHOT = 0x00000019,		                // traffic snapshot(Corresponding to NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO)
        FACEDETECT = 0x0000001A,                       // face detection(Corresponding to NET_DEV_EVENT_FACEDETECT_INFO)
        TRAFFICJAM = 0x0000001B,                       // traffic-Jam(Corresponding to NET_DEV_EVENT_TRAFFICJAM_INFO)
        TRAFFIC_RUNREDLIGHT = 0x00000100,		                // traffic-RunRedLight(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO)
        TRAFFIC_OVERLINE = 0x00000101,		                // traffic-Overline(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERLINE_INFO)
        TRAFFIC_RETROGRADE = 0x00000102,		                // traffic-Retrograde(Corresponding to NET_DEV_EVENT_TRAFFIC_RETROGRADE_INFO)
        TRAFFIC_TURNLEFT = 0x00000103,		                // traffic-TurnLeft(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO)
        TRAFFIC_TURNRIGHT = 0x00000104,		                // traffic-TurnRight(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO)	
        TRAFFIC_UTURN = 0x00000105,		                // traffic-Uturn(Corresponding to NET_DEV_EVENT_TRAFFIC_UTURN_INFO)
        TRAFFIC_OVERSPEED = 0x00000106,		                // traffic-Overspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO)
        TRAFFIC_UNDERSPEED = 0x00000107,		                // traffic-Underspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)
        TRAFFIC_PARKING = 0x00000108,                       // traffic-Parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKING_INFO)
        TRAFFIC_WRONGROUTE = 0x00000109,                       // traffic-WrongRoute(Corresponding to NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)
        TRAFFIC_CROSSLANE = 0x0000010A,                       // traffic-CrossLane(Corresponding to NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO)
        TRAFFIC_OVERYELLOWLINE = 0x0000010B,                       // traffic-OverYellowLine(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)
        TRAFFIC_DRIVINGONSHOULDER = 0x0000010C,                       // traffic-DrivingOnShoulder(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO)   
        TRAFFIC_YELLOWPLATEINLANE = 0x0000010E,                       // traffic-YellowPlateInLane(Corresponding to NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)
        TRAFFIC_PEDESTRAINPRIORITY = 0x0000010F,		                // Traffic offense-Pedestral has higher priority at the  crosswalk(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO)
        CROSSFENCEDETECTION = 0x0000011F,                       // cross fence(Corresponding to NET_DEV_EVENT_CROSSFENCEDETECTION_INFO) 
        ELECTROSPARKDETECTION = 0X00000110,                       // ElectroSpark event(Corresponding to NET_DEV_EVENT_ELECTROSPARK_INFO) 
        TRAFFIC_NOPASSING = 0x00000111,                       // no passing(Corresponding to NET_DEV_EVENT_TRAFFIC_NOPASSING_INFO)
        ABNORMALRUNDETECTION = 0x00000112,                       // abnormal run(Corresponding to NET_DEV_EVENT_ABNORMALRUNDETECTION_INFO)
        RETROGRADEDETECTION = 0x00000113,                       // retrograde(Corresponding to NET_DEV_EVENT_RETROGRADEDETECTION_INFO)
        INREGIONDETECTION = 0x00000114,                       // in region detection(Corresponding to NET_DEV_EVENT_INREGIONDETECTION_INFO)
        TAKENAWAYDETECTION = 0x00000115,                       // taking away things(Corresponding to NET_DEV_EVENT_TAKENAWAYDETECTION_INFO)
        PARKINGDETECTION = 0x00000116,                       // parking(Corresponding to NET_DEV_EVENT_PARKINGDETECTION_INFO)
        FACERECOGNITION = 0x00000117,		                // face recognition(Corresponding to NET_DEV_EVENT_FACERECOGNITION_INFO)
        TRAFFIC_MANUALSNAP = 0x00000118,                       // manual snap(Corresponding to NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)
        TRAFFIC_FLOWSTATE = 0x00000119,		                // traffic flow state(Corresponding to NET_DEV_EVENT_TRAFFIC_FLOW_STATE)
        TRAFFIC_STAY = 0x0000011A,		                // traffic stay(Corresponding to NET_DEV_EVENT_TRAFFIC_STAY_INFO)
        TRAFFIC_VEHICLEINROUTE = 0x0000011B,		                // traffic vehicle route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO)
        ALARM_MOTIONDETECT = 0x0000011C,                       // motion detect(Corresponding to NET_DEV_EVENT_ALARM_INFO)
        ALARM_LOCALALARM = 0x0000011D,                       // local alarm(Corresponding to NET_DEV_EVENT_ALARM_INFO)
        PRISONERRISEDETECTION = 0x0000011E,		                // prisoner rise detect(Corresponding to NET_DEV_EVENT_PRISONERRISEDETECTION_INFO)
        TRAFFIC_TOLLGATE = 0x00000120,		                // traffic tollgate(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        DENSITYDETECTION = 0x00000121,                       // density detection of persons(Corresponding to NET_DEV_EVENT_DENSITYDETECTION_INFO)
        VIDEODIAGNOSIS = 0x00000122,		                // video diagnosis result(Corresponding to NET_VIDEODIAGNOSIS_COMMON_INFO and NET_REAL_DIAGNOSIS_RESULT)
        QUEUEDETECTION = 0x00000123,                       // queue detection(Corresponding to NET_DEV_EVENT_QUEUEDETECTION_INFO)
        TRAFFIC_VEHICLEINBUSROUTE = 0x00000124,                       // take up in bus route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO)
        TRAFFIC_BACKING = 0x00000125,                       // illegal astern(Corresponding to NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO) 
        AUDIO_ABNORMALDETECTION = 0x00000126,                       // audio abnormity(Corresponding to NET_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO)
        TRAFFIC_RUNYELLOWLIGHT = 0x00000127,                       // run yellow light(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNYELLOWLIGHT_INFO)
        CLIMBDETECTION = 0x00000128,                       // climb detection(Corresponding to NET_DEV_EVENT_IVS_CLIMB_INFO) 
        LEAVEDETECTION = 0x00000129,                       // leave detection(Corresponding to NET_DEV_EVENT_IVS_LEAVE_INFO)
        TRAFFIC_PARKINGONYELLOWBOX = 0x0000012A,                       // parking on yellow box(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO)
        TRAFFIC_PARKINGSPACEPARKING = 0x0000012B,                       // parking space parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)
        TRAFFIC_PARKINGSPACENOPARKING = 0x0000012C,                       // parking space no parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)
        TRAFFIC_PEDESTRAIN = 0x0000012D,                       // passerby(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAIN_INFO)
        TRAFFIC_THROW = 0x0000012E,                       // throw(Corresponding to NET_DEV_EVENT_TRAFFIC_THROW_INFO)
        TRAFFIC_IDLE = 0x0000012F,                       // idle(Corresponding to NET_DEV_EVENT_TRAFFIC_IDLE_INFO)
        ALARM_VEHICLEACC = 0x00000130,                       // Vehicle ACC power outage alarm events(Corresponding to NET_DEV_EVENT_ALARM_VEHICLEACC_INFO)
        ALARM_VEHICLE_TURNOVER = 0x00000131,                       // Vehicle rollover alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        ALARM_VEHICLE_COLLISION = 0x00000132,                       // Vehicle crash alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        ALARM_VEHICLE_LARGE_ANGLE = 0x00000133,                       // On-board camera large Angle turn events
        TRAFFIC_PARKINGSPACEOVERLINE = 0x00000134,                       // Parking line pressing events(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEOVERLINE_INFO)
        MULTISCENESWITCH = 0x00000135,                       // Many scenes switching events(Corresponding to NET_DEV_EVENT_IVS_MULTI_SCENE_SWICH_INFO)
        TRAFFIC_RESTRICTED_PLATE = 0X00000136,                       // Limited license plate event(Corresponding to NET_DEV_EVENT_TRAFFIC_RESTRICTED_PLATE)
        TRAFFIC_OVERSTOPLINE = 0X00000137,                       // Cross stop line event(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE)
        TRAFFIC_WITHOUT_SAFEBELT = 0x00000138,                       // Traffic unfasten seat belt event(Corresponding to NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT) 
        TRAFFIC_DRIVER_SMOKING = 0x00000139,                       // Driver smoking event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_SMOKING) 
        TRAFFIC_DRIVER_CALLING = 0x0000013A,                       // Driver call event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING) 
        TRAFFIC_PEDESTRAINRUNREDLIGHT = 0x0000013B,                       // Pedestrain red light(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINRUNREDLIGHT_INFO)
        TRAFFIC_PASSNOTINORDER = 0x0000013C,                       // Pass not in order(corresponding NET_DEV_EVENT_TRAFFIC_PASSNOTINORDER_INFO)
        OBJECT_DETECTION = 0x00000141,                       // Object feature detection event(Corresponding to NET_DEV_EVENT_TRAFFIC_OBJECT_DETECTION) 
        ALARM_ANALOGALARM = 0x00000150,                       // Analog alarm channel?ˉs alarm event(corresponding NET_DEV_EVENT_ALARM_ANALOGALRM_INFO)
        CROSSLINEDETECTION_EX = 0x00000151,                       // Warning lineexpansion event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO_EX) 
        ALARM_COMMON = 0x00000152,                       // Normal Record
        ALARM_VIDEOBLIND = 0x00000153,                       // Video tampering event(Corresponding to NET_DEV_EVENT_ALARM_VIDEOBLIND)
        ALARM_VIDEOLOSS = 0x00000154,                       // Video loss event
        GETOUTBEDDETECTION = 0x00000155,		                // Event of getting out bed detection(Corresponding to NET_DEV_EVENT_GETOUTBED_INFO)
        PATROLDETECTION = 0x00000156,		                // Event of patrol detection(Corresponding to NET_DEV_EVENT_PATROL_INFO)
        ONDUTYDETECTION = 0x00000157,		                // Event of on duty detection(Corresponding to NET_DEV_EVENT_ONDUTY_INFO)
        NOANSWERCALL = 0x00000158,                       // Event of VTO do not answer calling request
        STORAGENOTEXIST = 0x00000159,                       // Event of storage do not exist
        STORAGELOWSPACE = 0x0000015A,                       // Event of storage space low
        STORAGEFAILURE = 0x0000015B,                       // Event of storage failure
        PROFILEALARMTRANSMIT = 0x0000015C,                       // Event of profile alarm transmit
        VIDEOSTATIC = 0x0000015D,                       // Event of static video detect(corresponding NET_DEV_EVENT_ALARM_VIDEOSTATIC_INFO)
        VIDEOTIMING = 0x0000015E,                       // Event of video timing detect(corresponding NET_DEV_EVENT_ALARM_VIDEOTIMING_INFO)
        HEATMAP = 0x0000015F,                       // Heat map (Corresponding to )
        CITIZENIDCARD = 0x00000160,                       // ID info reading event (Corresponding to NET_DEV_EVENT_ALARM_CITIZENIDCARD_INFO)
        PICINFO = 0x00000161,                       // Image info event(Corresponding to NET_DEV_EVENT_ALARM_PIC_INFO)
        NETPLAYCHECK = 0x00000162,		                // NetPlayCheck event(corresponding NET_DEV_EVENT_ALARM_NETPLAYCHECK_INFO)
        TRAFFIC_JAM_FORBID_INTO = 0x00000163,		                // Jam Forbid into  event(corresponding NET_DEV_EVENT_ALARM_JAMFORBIDINTO_INFO)
        SNAPBYTIME = 0x00000164,                       // Snap by time event(corresponding NET_DEV_EVENT_SNAPBYTIME)
        PTZ_PRESET = 0x00000165,                       // PTZ turn to preset event(corresponding to NET_DEV_EVENT_ALARM_PTZ_PRESET_INFO)
        RFID_INFO = 0x00000166,                       // Event of infrared detect info(corresponding to NET_DEV_EVENT_ALARM_RFID_INFO)
        STANDUPDETECTION = 0X00000167,		                // Event of standing up detection
        QSYTRAFFICCARWEIGHT = 0x00000168,		                // Event of QSYTrafficCarWeight (corresponding to NET_DEV_EVENT_QSYTRAFFICCARWEIGHT_INFO)
        TRAFFIC_COMPAREPLATE = 0x00000169,		                // Event of compare plate(corresponding to NET_DEV_EVENT_TRAFFIC_COMPAREPLATE_INFO)
        SHOOTINGSCORERECOGNITION = 0x0000016A,		                // Event of shooting score recognition(corresponding to NET_CFG_IVS_SHOOTINGSCORERECOGNITION_INFO)
        TRAFFIC_ANALYSE_PRESNAP = 0x00000170,                       // Event of presnap analyse(corresponding to NET_DEV_EVENT_TRAFFIC_ANALYSE_PRESNAP_INFO)

        TRAFFIC_ALL = 0x000001FF,                       // All event start with [TRAFFIC]
                                                        // EVENT_IVS_TRAFFICCONTROL -> EVENT_TRAFFICSNAPSHOT
                                                        // EVENT_IVS_TRAFFIC_RUNREDLIGHT -> EVENT_IVS_TRAFFIC_UNDERSPEED
        VIDEOANALYSE = 0x00000200,                       // All IVS events 
        LINKSD = 0x00000201,                       // LinkSD events(Corresponding to NET_DEV_EVENT_LINK_SD)
        VEHICLEANALYSE = 0x00000202,		                // Vehicle Analyse (Corresponding to NET_DEV_EVENT_VEHICLEANALYSE)

        FLOWRATE = 0x00000203,		                // Flow rate events(Corresponding to NET_DEV_EVENT_FLOWRATE_INFO)
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_RUNREDLIGHT's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;			    // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;               // Corresponding Lane number
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public NET_EVENT_FILE_INFO stuFileInfo;        // event file info
        public int nLightState;     // state of traffic light 0:unknown 1:green 2:red 3:yellow
        public int nSpeed;              // speed,km/h
        public int nSequence;          // snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;		// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        public byte byImageIndex;		// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_TIME_EX stRedLightUTC;       // time of red light starting
        public NET_RESOLUTION_INFO stuResolution;       // picture resolution
        public byte byRedLightMargin;	// red light margin, s
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byAlignment;		// Align string
        public int nRedLightPeriod;    // Red light period. The unit is ms. 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
        public byte[] bReserved;          // Reserved string 
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// time struct 
    /// </summary>
    public struct NET_TIME_EX
    {
        public uint dwYear;             // Year
        public uint dwMonth;            // Month
        public uint dwDay;              // Date
        public uint dwHour;             // Hour
        public uint dwMinute;           // Minute
        public uint dwSecond;           // Second
        public uint dwMillisecond;      // Millisecond
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] dwReserved;         // reserved

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"), dwMillisecond.ToString("D3"));
        }
    }

    /// <summary>
    /// Struct of object info for video analysis 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)] // 4-byte alignment
    public struct NET_MSG_OBJECT
    {
        public int nObjectID;               // Object ID,each ID represent a unique object
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szObjectType;         // Object type
        public int nConfidence;         // Confidence(0~255),a high value indicate a high confidence
        public int nAction;             // Object action:1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
#if (LINUX_X64)
		public NET_RECT_LONG_TYPE                   BoundingBox;		    // BoundingBox
#else
        public NET_RECT BoundingBox;            // BoundingBox
#endif
        public NET_POINT Center;                    // The shape center of the object
        public int nPolygonNum;         // the number of culminations for the polygon
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_POINT[] Contour;             // a polygon that have a exactitude figure
        public uint rgbaMainColor;          // The main color of the object;the first byte indicate red value, as byte order as green, blue, transparence, for example:RGB(0,255,0),transparence = 0, rgbaMainColor = 0x00ff0000.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szText;                   // the interrelated text of object,such as number plate,container number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szObjectSubType;        // object sub type,different object type has different sub type:
                                              // Vehicle Category:"Unknown","Motor","Non-Motor","Bus","Bicycle","Motorcycle"
                                              // Plate Category:"Unknown","mal","Yellow","DoubleYellow","Police","Armed",
                                              // "Military","DoubleMilitary","SAR","Trainning"
                                              // "Personal" ,"Agri","Embassy","Moto","Tractor","Other"
                                              // HumanFace Category:"Normal","HideEye","HideNose","HideMouth"
        public ushort wSubBrand;              // Specifies the sub-brand of vehicle,the real value can be found in a mapping table from the development manual 
        public byte byReserved1;            // reserved     
        public byte bPicEnble;              // picture info enable
        public NET_PIC_INFO stPicInfo;              // picture info
        public byte bShotFrame;             // is shot frame
        public byte bColor;                 // rgbaMainColor is enable
        public byte byReserved2;
        public byte byTimeType;             // Time indicates the type of detailed instructions,EM_TIME_TYP
        public NET_TIME_EX stuCurrentTime;          // in view of the video compression,current time(when object snap or reconfnition, the frame will be attached to the frame in a video or pictures,means the frame in the original video of the time)
        public NET_TIME_EX stuStartTime;            // strart time(object appearing for the first time)
        public NET_TIME_EX stuEndTime;              // end time(object appearing for the last time)
#if (LINUX_X64)
		public NET_RECT_LONG_TYPE                   stuOriginalBoundingBox;	// original bounding box(absolute coordinates)
        public NET_RECT_LONG_TYPE                   stuSignBoundingBox;	    // sign bounding box coordinate
#else
        public NET_RECT stuOriginalBoundingBox;	// original bounding box(absolute coordinates)
        public NET_RECT stuSignBoundingBox;     // sign bounding box coordinate
#endif
        public uint dwCurrentSequence;      // The current frame number (frames when grabbing the object)
        public uint dwBeginSequence;        // Start frame number (object appeared When the frame number
        public uint dwEndSequence;          // The end of the frame number (when the object disappearing Frame number)
        public Int64 nBeginFileOffset;      // At the beginning of the file offset, Unit: Word Section (when objects began to appear, the video frames in the original video file offset relative to the beginning of the file
        public Int64 nEndFileOffset;			// At the end of the file offset, Unit: Word Section (when the object disappeared, video frames in the original video file offset relative to the beginning of the file)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byColorSimilar;         // Object color similarity, the range :0-100, represents an array subscript Colors, see EM_COLOR_TYPE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byUpperBodyColorSimilar;// When upper body color similarity (valid object type man 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byLowerBodyColorSimilar;// Lower body color similarity when objects (object type human valid 
        public int nRelativeID;            // ID of relative object
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] szSubText;				// "ObjectType"is "Vehicle" or "Logo" means a certain brand under LOGO such as Audi A6L since there are so many brands SDK sends this field in real-time ,device filled as real.
        public ushort wBrandYear;             // Specifies the model years of vehicle. the real value can be found in a mapping table from the development manual 
    }

    /// <summary>
    /// enum time type
    /// </summary>
    public enum EM_TIME_TYPE
    {
        ABSLUTE,                                                            // absolute time  
        RELATIVE,                                                           // Relative time, relative to the video file header frame as the time basis points, the first frame corresponding to the UTC (0000-00-00 00:00:00)
    }

    /// <summary>
    /// enum color type
    /// </summary>
    public enum EM_COLOR_TYPE
    {
        RED,                                                                // red
        YELLOW,                                                             // yellow
        GREEN,                                                              // green
        CYAN,                                                               // cyan
        BLUE,                                                               // glue
        PURPLE,                                                             // purple
        BLACK,                                                              // black
        WHITE,                                                              // white
    }

    /// <summary>
    /// rect size struct
    /// </summary>
    public struct NET_RECT
    {
        public int nLeft;                  // left
        public int nTop;                   // top
        public int nRight;                 // right
        public int nBottom;                //bottom
    }

    /// <summary>
    /// rect size struct for linux x64
    /// </summary>
    public struct NET_RECT_LONG_TYPE
    {
        public long nLeft;                  // left
        public long nTop;                   // top
        public long nRight;                 // right
        public long nBottom;                //bottom
    }
    /// <summary>
    /// dimension point struct
    /// </summary>
    public struct NET_POINT
    {
        public short nx;                     //x
        public short ny;                     //y
    }

    /// <summary>
    /// picture information struct
    /// </summary>
    public struct NET_PIC_INFO
    {
        public uint dwOffSet;               // current picture file's offset in the binary file, byte
        public uint dwFileLenth;            // current picture file's size, byte
        public ushort wWidth;                 // picture width, pixel
        public ushort wHeight;                // picture high, pixel
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszFilePath;            // File path
                                              // User use this field need to apply for space for copy and storage
        public byte bIsDetected;			// When submit to the server, the algorithm has checked the image or not 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] bReserved;				// 12<--16
    }

    /// <summary>
    /// event file information struct
    /// </summary>
    public struct NET_EVENT_FILE_INFO
    {
        public byte bCount;                 // the file count in the current file's group
        public byte bIndex;                 // the index of the file in the group
        public byte bFileTag;               // file tag, see the enum EM_EVENT_FILETAG
        public byte bFileType;              // file type,0-normal 1-compose 2-cut picture
        public NET_TIME_EX stuFileTime;            // file time
        public uint nGroupId;               // the only id of one group file
    }

    /// <summary>
    /// event file's tag type
    /// </summary>
    public enum EM_EVENT_FILETAG
    {
        NET_ATMBEFOREPASTE = 1,                                             // Before ATM Paste
        NET_ATMAFTERPASTE,                                                  // After ATM Paste
    }

    /// <summary>
    /// picture resolution struct
    /// </summary>
    public struct NET_RESOLUTION_INFO
    {
        public ushort snWidth;                // width
        public ushort snHight;                // hight
    }

    /// <summary>
    /// trafficCar event information struct
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPlateNumber;          // plate number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPlateType;            // plate type
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPlateColor;           // plate color, "Blue","Yellow", "White","Black"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szVehicleColor;         // vehicle color, "White", "Black", "Red", "Yellow", "Gray", "Blue","Green"
        public int nSpeed;                 // speed, Km/H
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szEvent;                // trigger event type
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szViolationCode;        // violation code, see TrafficGlobal.ViolationCode
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szViolationDesc;        // violation describe
        public int nLowerSpeedLimit;       // lower speed limit
        public int nUpperSpeedLimit;       // upper speed limit
        public int nOverSpeedMargin;       // over speed margin, km/h 
        public int nUnderSpeedMargin;      // under speed margin, km/h 
        public int nLane;                  // lane	
        public int nVehicleSize;           // vehicle size, see VideoAnalyseRule's describe
                                           // Bit 0:"Light-duty", small car
                                           // Bit 1:"Medium", medium car
                                           // Bit 2:"Oversize", large car
                                           // Bit 3:"Minisize", mini car
                                           // Bit 4:"Largesize", long car
        public float fVehicleLength;         // vehicle length, m
        public int nSnapshotMode;          // snap mode 0-normal,1-globle,2-near,4-snap on the same side,8-snap on the reverse side,16-plant picture
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szChannelName;          // channel name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineName;          // Machine name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineGroup;         // machine group
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szRoadwayNo;            // road way number	
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
        public byte[] szDrivingDirection;     // szDrivingDirection[3][256];
                                              // DrivingDirection: for example ["Approach", "Shanghai", "Hangzhou"]
                                              // "Approach" means driving direction,where the car is more near;"Leave"-means where if mor far to the car
                                              // the second and third param means the location of the driving direction
        [MarshalAs(UnmanagedType.LPStr)]
        public string szDeviceAddress;        // device address,OSD superimposed onto the image,from TrafficSnapshot.DeviceAddress,'\0'means end.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szVehicleSign;            // Vehicle identification, such as "Unknown" - unknown "Audi" - Audi, "Honda" - Honda ...
        public NET_SIG_CARWAY_INFO_EX stuSigInfo;             // Generated by the vehicle inspection device to capture the signal redundancy
        [MarshalAs(UnmanagedType.LPStr)]
        public string szMachineAddr;            // Equipment deployment locations
        public float fActualShutter;         // Current picture exposure time, in milliseconds
        public byte byActualGain;           // Current picture gain, ranging from 0 to 100
        public byte byDirection;			// Lane Direction,0 - south to north 1- Southwest to northeast 2 - West to east, 3 - Northwest to southeast 4 - north to south 5 - northeast to southwest 6 - East to West 7 - Southeast to northwest 8 - Unknown 9-customized
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        [MarshalAs(UnmanagedType.LPStr)]
        public string szDetailedAddress;      // Address, as szDeviceAddress supplement
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szDefendCode;           // waterproof  
        public int nTrafficBlackListID;    // Link black list data recorddefualt main keyID, 0 invalid,>0 black list data record
        public NET_COLOR_RGBA stuRGBA;                // bofy color RGBA
        public NET_TIME stSnapTime;             // snap time
        public int nRecNo;                 // Rec No
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[] szCustomParkNo;         // self defined parking space number for parking
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved1;
        public int nDeckNo;                // Metal plate No. 
        public int nFreeDeckCount;         // Free metal plate No.
        public int nFullDeckCount;         // Occupized metal plate No. 
        public int nTotalDeckCount;        // Total metal plate No. 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szViolationName;        // violation name
        public uint nWeight;				// Weight of car(kg)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szCustomRoadwayDirection;// custom road way, valid when byDirection is 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 584)]
        public byte[] bReserved;              // Reserved bytes
    }

    /// <summary>
    /// Vehicle detector redundancy information
    /// </summary>
    public struct NET_SIG_CARWAY_INFO_EX
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byRedundance;           // The vehicle detector generates the snap signal redundancy info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] bReserved;              // Reserved field
    }

    /// <summary>
    /// color RGBA
    /// </summary>
    public struct NET_COLOR_RGBA
    {
        public int nRed;                   // red
        public int nGreen;                 // green
        public int nBlue;                  // blue
        public int nAlpha;                 // transparent
    }

    /// <summary>
    /// command event information
    /// </summary>
    public struct NET_EVENT_COMM_INFO
    {
        public EM_NTP_STATUS emNTPStatus;					// NTP time sync status 
        public int nDriversNum;					// driver info number
        public IntPtr pstDriversInfo;					// driver info data (NET_MSG_OBJECT_EX)
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszFilePath;					// writing path for loacl disk or sd card, or write to default path if NULL
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszFTPPath;						// ftp path
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszVideoPath;					// ftp path for assocated video
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public NET_EVENT_COMM_SEAT[] stCommSeat;                        // Seat info
        public int nAttachmentNum;					// Car Attachment number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public NET_EVENT_COMM_ATTACHMENT[] stuAttachment;                   // Car Attachment 
        public int nAnnualInspectionNum;		    // Annual Inspection number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public NET_RECT[] stuAnnualInspection;	        // Annual Inspection 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1100)]
        public byte[] bReserved;						// reserved
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] szCountry;						// Country
    }

    /// <summary>
    /// NTP status
    /// </summary>
    public enum EM_NTP_STATUS
    {
        UNKNOWN = 0,                                                       // unknow
        DISABLE,                                                       // disable
        SUCCESSFUL,                                                       // successful
        FAILED,                                                       // failed
    }

    /// <summary>
    /// Video analysis object info expansion structure 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)] // 4-byte alignment
    public struct NET_MSG_OBJECT_EX
    {
        public uint dwSize;                         // struct size
        public int nObjectID;                      // object ID, each ID means a exclusive object
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szObjectType;                   // object  type 
        public int nConfidence;                    // confidence coefficient (0~255) value the bigger means  confidence coefficient the higher
        public int nAction;                        // object  motion :1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
#if (LINUX_X64)
		public NET_RECT_LONG_TYPE           BoundingBox;		            // BoundingBox
#else
        public NET_RECT BoundingBox;                    // BoundingBox
#endif
        public NET_POINT Center;                         // object model center
        public int nPolygonNum;                    // polygon vertex number 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_POINT[] Contour;                        // relatively accurate outline the polygon  
        public uint rgbaMainColor;                  // means plate, vehicle body and etc. object major color by byte means are red, green, blue and transparency , such as:RGB value is (0,255,0), transparency is 0, its value is 0x00ff0000.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szText;                         // same as NET_MSG_OBJECT corresponding field
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szObjectSubType;                // object sub type according to different object  types may use the following sub type
                                                      // same as NET_MSG_OBJECT field
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved1;                    // reserved
        public byte bPicEnble;                      // object corresponding to picture file info or not
        public NET_PIC_INFO stPicInfo;                      // object corresponding to picture info 
        public byte bShotFrame;                     // snapshot recognition result or not 
        public byte bColor;                         // object  color (rgbaMainColor) usable or not
        public byte bLowerBodyColor;                // lower color (rgbaLowerBodyColor) usable or not
        public byte byTimeType;                     // time means type, see EM_TIME_TYPE note 
        public NET_TIME_EX stuCurrentTime;                 // for video compression current time stamp, object snapshot or recognition, attach this recognition frame in one vire frame or jpegpicture,this frame's appearance time in original video
        public NET_TIME_EX stuStartTime;                   // start time stamp,object start appearance
        public NET_TIME_EX stuEndTime;                     // end time stamp,object last aapearance
#if(LINUX_X64)
		public NET_RECT_LONG_TYPE           stuOriginalBoundingBox;	        // original bounding box(absolute coordinates)
        public NET_RECT_LONG_TYPE           stuSignBoundingBox;	            // sign bounding box coordinate
#else
        public NET_RECT stuOriginalBoundingBox;	        // original bounding box(absolute coordinates)
        public NET_RECT stuSignBoundingBox;             // sign bounding box coordinate
#endif
        public uint dwCurrentSequence;              //  current frame no. snapshot this object frame
        public uint dwBeginSequence;                // start frame no. object start appearance frame no.
        public uint dwEndSequence;                  // end frame no. object disappearance frame no.
        public Int64 nBeginFileOffset;               // start file shift, unit: byte object start appearance video in original video file moves toward file origin
        public Int64 nEndFileOffset;                 // End file shift, unit: byte object disappearance video in original video file moves toward file origin
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byColorSimilar;                 // object  color similarity take  value range 0-100 group subscript value represents certain color, see EM_COLOR_TYPE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byUpperBodyColorSimilar;        // upper object  color  similarity (object  type as human is valid )
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byLowerBodyColorSimilar;        // lower object  color  similarity (object  type as human is valid )
        public int nRelativeID;                    // related object ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] szSubText;                      // "ObjectType"is "Vehicle"or "Logo" means LOGO lower brand￡?such as Audi A6L since there are many brands SDK shows this field in real-time,device filled as real.

        public int nPersonStature;                  // Intrusion staff height unit cm
        public EM_MSG_OBJ_PERSON_DIRECTION emPersonDirection;              // Staff intrusion direction
        public uint rgbaLowerBodyColor;             // Use direction same as rgbaMainColor,object  type as human is valid 	
    }

    /// <summary>
    /// intrusion direction
    /// </summary>
    public enum EM_MSG_OBJ_PERSON_DIRECTION
    {
        UNKOWN,                                                             // unknown direction
        LEFT_TO_RIGHT,                                                      // from left to right
        RIGHT_TO_LEFT                                                       // from right ro left
    }

    /// <summary>
    /// driver's illegal info
    /// </summary>
    public struct NET_EVENT_COMM_SEAT
    {
        public bool bEnable;                        // whether seat info detected
        public EM_COMMON_SEAT_TYPE emSeatType;                     // seat type
        public NET_EVENT_COMM_STATUS stStatus;                       // illegal state
        public EM_SAFEBELT_STATE emSafeBeltStatus;               // safe belt state
        public EM_SUNSHADE_STATE emSunShadeStatus;               // sun shade state
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] szReserved;                     // reversed
    }

    /// <summary>
    /// seat type
    /// </summary>
    public enum EM_COMMON_SEAT_TYPE
    {
        UNKNOWN = 0,                                                     // unknown
        MAIN = 1,                                                     // main seat
        SLAVE = 2,                                                     // slave seat
    }

    /// <summary>
    /// illegal state type of driver
    /// </summary>
    public struct NET_EVENT_COMM_STATUS
    {
        public byte bySmoking;                                              // smoking
        public byte byCalling;                                              // calling
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] szReserved;                                           // reversed
    }

    /// <summary>
    /// safebelt state
    /// </summary>
    public enum EM_SAFEBELT_STATE
    {
        NUKNOW,                                                         // Unknow
        WITH_SAFE_BELT,                                                 // WithSafeBelt   
        WITHOUT_SAFE_BELT,			                                        // WithoutSafeBelt 
    }

    /// <summary>
    /// sunshade state
    /// </summary>
    public enum EM_SUNSHADE_STATE
    {
        NUKNOW_SUN_SHADE,                                                   // Unknow
        WITH_SUN_SHADE,                                                 // WithSunShade  
        WITHOUT_SUN_SHADE,			                                        // WithoutSunShade
    }

    /// <summary>
    /// event attachment struct
    /// </summary>
    public struct NET_EVENT_COMM_ATTACHMENT
    {
        public EM_COMM_ATTACHMENT_TYPE emAttachmentType;           // type
        public NET_RECT stuRect;                    // coordinate
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] bReserved;		            // reserved
    }

    /// <summary>
    /// attachment type
    /// </summary>
    public enum EM_COMM_ATTACHMENT_TYPE
    {
        UNKNOWN = 0,                                                     // Unknown type       
        FURNITURE = 1,                                                     // Furniture       
        PENDANT = 2,                                                     // Pendant       
        TISSUEBOX = 3,                                                     // TissueBox       
        DANGER = 4,                                                     // Danger     
        PERFUMEBOX = 5,                                                     // perfumebox
    }

    /// <summary>
    /// Event Type EVENT_IVS_TRAFFICJUNCTION (transportation card traffic junctions old rule event / video port on the old electric alarm event rules) corresponding to the description of the data block
    /// Due to historical reasons, if you want to deal with bayonet event, NET_DEV_EVENT_TRAFFICJUNCTION_INFO and NET_EVENT_IVS_TRAFFICGATE be processed together to prevent police and video electrical coil electric alarm occurred while the case access platform
    /// Also NET_EVENT_IVS_TRAFFIC_TOLLGATE only support the new bayonet events
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFICJUNCTION_INFO
    {
        public int nChannelID;			// ChannelId
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;				// event name
        public byte byMainSeatBelt;     // main driver's seat safety belt,1-fastened,2-unfastened
        public byte bySlaveSeatBelt;    // co-drvier's seat safety belt,1-fastened,2-unfastened
        public byte byVehicleDirection; // Current snapshot is head or rear see  EM_VEHICLE_DIRECTION
        public byte byOpenStrobeState;  // Open status see EM_OPEN_STROBE_STATE 
        public double PTS;				// PTS(ms)
        public NET_TIME_EX UTC;				// the event happen time
        public int nEventID;			// event ID
        public NET_MSG_OBJECT stuObject;			// have being detected object
        public int nLane;				// road number
        public uint dwBreakingRule;     // BreakingRule's mask,first byte: crash red light; 
                                        // secend byte:break the rule of driving road number; 
                                        // the third byte:converse; the forth byte:break rule to turn around;
                                        // the five byte:traffic jam; the six byte:traffic vacancy; 
                                        // the seven byte: Overline; defalt:trafficJunction                                                        
        public NET_TIME_EX RedLightUTC;		// the begin time of red light
        public NET_EVENT_FILE_INFO stuFileInfo;        // event file info
        public int nSequence;          // snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public int nSpeed;             // car's speed (km/h)
        public byte bEventAction;       // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        public byte byDirection;        // Intersection direction 1 - denotes the forward 2 - indicates the opposite
        public byte byLightState;       // LightState means red light status:0 unknown,1 green,2 red,3 yellow
        public byte byReserved;         // reserved
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public uint dwSnapFlagMask;	    // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szRecordFile;       // Alarm corresponding original video file information
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 340)]
        public byte[] bReserved;			// Reserved bytes, leave extended_
        public int nTriggerType;       // Trigger Type:0 vehicle inspection device,1 radar,2 video
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public uint dwRetCardNumber;    // Card Number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_EVENT_CARD_INFO[] stuCardInfo;        // Card information
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// vehicle direction
    /// </summary>
    public enum EM_VEHICLE_DIRECTION
    {
        UNKOWN,                                                             // unknown 
        HEAD,                                                               // head    
        TAIL,                                                               // rear  
    }

    /// <summary>
    /// incidents reported to carry the card information
    /// </summary>
    public struct NET_EVENT_CARD_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public byte[] szCardNumber;       // Card number string
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] bReserved;	        // Reserved bytes, leave extended
    }

    /// <summary>
    /// the describe of EVENT_TRAFFIC_TURNLEFT's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;		        // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;               // Corresponding Lane number
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public NET_EVENT_FILE_INFO stuFileInfo;        // event file info
        public int nSequence;          // snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public int nSpeed;             // speed,km/h
        public byte bEventAction;		// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;         // reserved
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
        public byte[] bReserved;            // Reserved 
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }


    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_TURNRIGHT's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;		        // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;               // Corresponding Lane number
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public NET_EVENT_FILE_INFO stuFileInfo;        // event file info
        public int nSequence;          // snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public int nSpeed;             // speed,km/h
        public byte bEventAction;		// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;         // reserved
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
        public byte[] bReserved;            // Reserved 
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_OVERSPEED's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;				// event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;               // Corresponding Lane number
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public NET_EVENT_FILE_INFO stuFileInfo;		// event file info
        public int nSpeed;             // vehicle speed Unit:Km/h
        public int nSpeedUpperLimit;    // Speed Up limit Unit:km/h
        public int nSpeedLowerLimit;    // Speed Low limit Unit:km/h 
        public int nSequence;          // snap index:such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;		// Event action,0 means pulse event,1 means continuous event's begin,2 means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] szFilePath;         // Faile path
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo; // intelli comm info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 744)]
        public byte[] bReserved;            // Reserved 
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// intelli event comm info
    /// </summary>
    public struct NET_EVENT_INTELLI_COMM_INFO
    {
        public EM_CLASS_TYPE emClassType;		// class type
    }

    /// <summary>
    /// class type
    /// </summary>
    public enum EM_CLASS_TYPE
    {
        UNKNOWN = 0,                                    // unknow
        VIDEO_SYNOPSIS = 1,                                    // video-synopsis
        TRAFFIV_GATE = 2,                                    // traffiv-gate
        ELECTRONIC_POLICE = 3,                                    // electronic-police
        SINGLE_PTZ_PARKING = 4,                                    // single-PTZ-parking
        PTZ_PARKINBG = 5,                                    // PTZ-parking
        TRAFFIC = 6,                                    // Traffic       
        NORMAL = 7,                                    // Normal       
        PRISON = 8,                                    // Prison       
        ATM = 9,                                    // ATM       
        METRO = 10,                                   // metro   
        FACE_DETECTION = 11,                                   // FaceDetection       
        FACE_RECOGNITION = 12,                                   // FaceRecognition       
        NUMBER_STAT = 13,                                   // NumberStat       
        HEAT_MAP = 14,                                   // HeatMap      
        VIDEO_DIAGNOSIS = 15,                                   // VideoDiagnosis       
        VIDEO_ENHANCE = 16,
        SMOKEFIRE_DETECT = 17,
        VEHICLE_ANALYSE = 18,                                   // VehicleAnalyse       
        PERSON_FEATURE = 19,
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_UNDERSPEED's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;				// event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved2;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;               // Corresponding Lane number
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // vehicle info
        public NET_EVENT_FILE_INFO stuFileInfo;		// event file info
        public int nSpeed;             // vehicle speed Unit:Km/h
        public int nSpeedUpperLimit;    // Speed Up limit Unit:km/h
        public int nSpeedLowerLimit;    // Speed Low limit Unit:km/h 
        public int nSequence;          // snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;		// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved1;         // reserved
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public int nUnderSpeedingPercentage; // under speed percentage
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo; // command information.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] bReserved;            // Reserved 
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFICGATE's data
    /// owing to history, if you want to deal with TRAFFICGATE,DEV_EVENT_TRAFFICJUNCTION_INFO?EVENT_IVS_TRAFFICGATE must be handle together;
    /// in addition: EVENT_IVS_TRAFFIC_TOLLGATE only support new tollgate event configuration
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFICGATE_INFO
    {
        public int nChannelID;						    // ChannelId
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;					            // event name
        public byte byOpenStrobeState;                  // Open gateway status see EM_OPEN_STROBE_STATE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved1;                         // byte alignment
        public double PTS;                              // PTS(ms)
        public NET_TIME_EX UTC;                             // the event happen time
        public int nEventID;                            // event ID
        public NET_MSG_OBJECT stuObject;                            // have being detected object
        public int nLane;                               // road number
        public int nSpeed;                              // the car's actual rate(Km/h)
        public int nSpeedUpperLimit;                    // rate upper limit(km/h)
        public int nSpeedLowerLimit;                    // rate lower limit(km/h) 
        public uint dwBreakingRule;                     // BreakingRule's mask,first byte: Retrograde; 
                                                        // second byte:Overline; the third byte:Overspeed; 
                                                        // the forth byte:UnderSpeed;the five byte: crash red light;the six byte:passing(trafficgate)
                                                        // the seven byte: OverYellowLine; the eight byte: WrongRunningRoute; the nine byte: YellowVehicleInRoute; default: trafficgate
        public NET_EVENT_FILE_INFO stuFileInfo;                        // event file info
        public NET_MSG_OBJECT stuVehicle;                         // vehicle info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szManualSnapNo;                     // manual snap sequence string                 
        public int nSequence;                          // snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;                       // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;                         // reserved
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szSnapFlag;                         // snap flag from device
        public byte bySnapMode;                         // snap mode,0-normal 1-globle 2-near 4-snap on the same side 8-snap on the reverse side 16-plant picture
        public byte byOverSpeedPercentage;              // over speed percentage
        public byte byUnderSpeedingPercentage;          // under speed percentage
        public byte byRedLightMargin;                   // red light margin, s
        public byte byDriveDirection;                   // drive direction,0-"Approach",where the car is more near,1-"Leave",means where if mor far to the car
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szRoadwayNo;                        // road way number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szViolationCode;                    // violation code
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szViolationDesc;                    // violation desc
        public NET_RESOLUTION_INFO stuResolution;                      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szVehicleType;                      // car type,"Motor", "Light-duty", "Medium", "Oversize", "Huge", "Other" 
        public byte byVehicleLenth;                     // car length, m
        public byte byLightState;                       // LightState means red light status:0 unknown,1 green,2 red,3 yellow
        public byte byReserved1;                        // reserved
        public byte byImageIndex;                       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public int nOverSpeedMargin;                   // over speed margin, km/h 
        public int nUnderSpeedMargin;                  // under speed margin, km/h 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
        public byte[] szDrivingDirection;                 // szDrivingDirection[3][256]
                                                          // "DrivingDirection" : ["Approach", "Shanghai", "Hangzhou"],
                                                          // "Approach" means driving direction,where the car is more near;"Leave"-means where if mor far to the car
                                                          // the second and third param means the location of the driving direction
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineName;                      // machine name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineAddress;                   // machine address
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineGroup;                     // machine group
        public uint dwSnapFlagMask;                     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_SIG_CARWAY_INFO_EX stuSigInfo;                         // The vehicle detector generates the snap signal redundancy info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] szFilePath;                         // File path
        public NET_TIME_EX RedLightUTC;					    // the begin time of red light
        [MarshalAs(UnmanagedType.LPStr)]
        public string szDeviceAddress;                    // device address,OSD superimposed onto the image,from TrafficSnapshot.DeviceAddress,'\0'means end.
        public float fActualShutter;                     // Current picture exposure time, in milliseconds
        public byte byActualGain;                       // Current picture gain, ranging from 0 to 1000
        public byte byDirection;                        // 0-S to N  1-SW to NE 2-W to E 3-NW to SE 4-N to S 5-NE to SW 6-E to W 7-SE to NW 8-Unknown
        public byte bReserve;                           // Reserved bytes, byte alignment
        public byte bRetCardNumber;                     // Card Number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_EVENT_CARD_INFO[] stuCardInfo;                        // Card information
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szDefendCode;                       // Waterproof
        public int nTrafficBlackListID;                // Link to balcklist main keyID, 0 invalid >0 blacklist data record
        public NET_EVENT_COMM_INFO stCommInfo;                         // public info 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 452)]
        public byte[] bReserved;	                        // Reserved bytes, leave extended
    }

    /// <summary>
    /// strobe state
    /// </summary>
    public enum EM_OPEN_STROBE_STATE
    {
        UNKOWN,                                                             // unknown
        CLOSE,                                                              // close
        AUTO,                                                               // auto open   
        MANUAL,                                                             // manual open
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_MANUALSNAP's data
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;			    // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public int nLane;				// lane number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szManualSnapNo;     // manual snap number 
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_MSG_OBJECT stuVehicle;         // have being detected vehicle
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // TrafficCar info
        public NET_EVENT_FILE_INFO stuFileInfo;        // event file info
        public byte bEventAction;       // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
        public byte[] bReserved;			// reserved
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_PARKINGSPACEPARKING(parking space parking)corresponding data block description info
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;             // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bReserved1;         // byte alignment
        public uint PTS;                // Time stamp(ms)
        public NET_TIME_EX UTC;             // Event occurred time
        public int nEventID;            // Event ID
        public int nLane;               // Corresponding lane No.
        public NET_MSG_OBJECT stuObject;            // Detected object
        public NET_MSG_OBJECT stuVehicle;         // Vehicle body info
        public NET_EVENT_FILE_INFO stuFileInfo;        // The corresponding file info of the event

        public int nSequence;          // snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;       // Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"	
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public int nParkingSpaceStatus;// parking space status 0-free 1-not free 2-on line
        public NET_DEV_TRAFFIC_PARKING_INFO stTrafficParingInfo;// traffic paring information.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 380)]
        public byte[] bReserved;          // reserved 
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    /// <summary>
    /// Parking lot info
    /// </summary>
    public struct NET_DEV_TRAFFIC_PARKING_INFO
    {
        public int nFeaturePicAreaPointNum;    // Feature image point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_POINT[] stFeaturePicArea;         // Feature image info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 572)]
        public byte[] bReserved;                // Reserved string 
    }

    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_PARKINGSPACENOPARKING(parking space no parking)corresponding data block description info
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;             // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bReserved1;         // byte alignment
        public uint PTS;                // Time stamp(ms)
        public NET_TIME_EX UTC;             // Event occurred time
        public int nEventID;            // Event ID
        public int nLane;               // Corresponding lane No.
        public NET_MSG_OBJECT stuObject;            // Detected object
        public NET_MSG_OBJECT stuVehicle;         // Vehicle body info
        public NET_EVENT_FILE_INFO stuFileInfo;        // The corresponding file info of the event

        public int nSequence;          // snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        public byte bEventAction;       // Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"	
        public NET_RESOLUTION_INFO stuResolution;      // picture resolution
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;       // Traffic vehicle info
        public NET_DEV_TRAFFIC_PARKING_INFO stTrafficParingInfo;// traffic paring information
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 384)]
        public byte[] bReserved;          // reserved
        public NET_EVENT_COMM_INFO stCommInfo;         // public info 
    }

    public struct NET_DEV_EVENT_PARKINGDETECTION_INFO
    {
        public int nChannelID;						    // ChannelId
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;					            // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;                         // byte alignment
        public double PTS;                              // PTS(ms)
        public NET_TIME_EX UTC;                             // the event happen time
        public int nEventID;                            // event ID
        public NET_MSG_OBJECT stuObject;                            // have being detected object
        public int nDetectRegionNum;				    // detect region's point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] DetectRegion;                       // detect region info
        public NET_EVENT_FILE_INFO stuFileInfo;                        // event file info
        public byte bEventAction;                       // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;                         // reserved
        public byte byImageIndex;                       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;                     // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        public int nSourceIndex;                       // the source device's index,-1 means data in invalid
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSourceDevice;                     // the source device's sign(exclusive),field said local device does not exist or is empty
        public uint nOccurrenceCount;                   // event trigger accumilated times 
        public NET_EVENT_COMM_INFO stuIntelliCommInfo;                 // intelli comm info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 616)]
        public byte[] bReserved;				            // Reserved 
    }


    /// <summary>
    /// New audio detection alarm information 
    /// </summary>
    public struct NET_NEW_SOUND_ALARM_STATE
    {
        public int channelcount;       // alarm channel count.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_NEW_SOUND_ALARM_STATE1[] SoundAlarmInfo;     // sound alarm information.
    }

    /// <summary>
    /// New audio detection alarm information
    /// </summary>
    public struct NET_NEW_SOUND_ALARM_STATE1
    {
        public int channel;            // alarm channel number
        public int alarmType;          // Alarm type;0:Volume value is too low ,1:Volume value is too high
        public uint volume;             // Volume
        public byte byState;            // volume alarm state, 0: alarm appear, 1: alarm disappear
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[] reserved;           // reserved.
    }

    /// <summary>
    /// struct about audio anomaly alarm information
    /// </summary>
    public struct NET_ALARM_AUDIO_ANOMALY
    {
        public uint dwStructSize;       // struct size
        public uint dwAction;           // Event Action,0:Start, 1:Stop
        public uint dwChannelID;        // Audio Channel ID 
        public int nDecibel;           // Audio sensitivity
        public int nFrequency;         // Audio frequency
    }


    /// <summary>
    /// struct about audio mutation alarm information
    /// </summary>
    public struct NET_ALARM_AUDIO_MUTATION
    {
        public uint dwStructSize;       // StructSize
        public uint dwAction;           // Event Action,0:Start, 1:Stop
        public uint dwChannelID;        // Audio Channel ID
    }

    public enum EM_SYS_ABILITY
    {
        DYNAMIC_CONNECT = 1,                                                // dynamic connect capacity
        WATERMARK_CFG = 17,			                                        // Watermark configuration capacity
        WIRELESS_CFG = 18,			                                        // wireless  configuration capacity
        DEVALL_INFO = 26,			                                        // Device capacity list 
        CARD_QUERY = 0x0100,		                                        // Card number search capacity 
        MULTIPLAY = 0x0101,			                                        // Multiple-window preview capacity 
        QUICK_QUERY_CFG = 0x0102,	                                        // Fast query configuration Capabilities
        INFRARED = 0x0121,			                                        // Wireless alarm capacity 
        TRIGGER_MODE = 0x0131,		                                        // Alarm activation mode function 
        DISK_SUBAREA = 0x0141,		                                        // Network hard disk partition
        DSP_CFG = 0x0151,			                                        // Query DSP Capabilities
        STREAM_MEDIA = 0x0161,		                                        // Query SIP,RTSP Capabilities
        INTELLI_TRACKER = 0x0171,                                           // Search intelligent track capability.
    }

    public struct NET_DEV_ENABLE_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public uint[] IsFucEnable;			                                // Function list capacity set. Corresponding to the above mentioned enumeration. Use bit to represent sub-function.
    }

    public enum EM_LOG_QUERY_TYPE
    {
        ALL = 0,								                            // All logs
        SYSTEM,								                                // System logs 
        CONFIG,								                                // Configuration logs 
        STORAGE,								                            // Storage logs
        ALARM,								                                // Alarm logs 
        RECORD,								                                // Record related
        ACCOUNT,								                            // Account related
        CLEAR,								                                // Clear log 
        PLAYBACK,								                            // Playback related 
        MANAGER                                                             // Concerning the front-end management and running
    }

    public struct NET_QUERY_DEVICE_LOG_PARAM
    {
        public EM_LOG_QUERY_TYPE emLogType;             // Searched log type
        public NET_TIME stuStartTime;           // The searched log start time
        public NET_TIME stuEndTime;             // The searched log end time. 
        public int nStartNum;               // The search begins from which log in one period. It shall begin with 0 if it is the first time search.
        public int nEndNum;             // The ended log serial number in one search,the max returning number is 1024 
        public byte nLogStuType;            // log struct type,0:NET_DEVICE_LOG_ITEM;1:NET_DEVICE_LOG_ITEM_EX
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] reserved;               // Reserved
        public uint nChannelID;             // Channel no. 0:Compatible with previous all channel numbers. The channel No. begins with 1.1: The first channel.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] bReserved;              // Reserved
    }
    public struct NET_DEVICE_LOG_ITEM
    {
        public int nLogType;				// Log type 
        public NETDEVTIME stuOperateTime;			// Date
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szOperator; 		    // Operator
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved;              // Reserved
        public byte bUnionType;				// union structure type,0:szLogContext;1:stuOldLog
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szLogContext;           // 0:Log content,1:Old log structure NET_OLDLOG
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] reserved;               // Detail operation
    }

    public struct NET_DEVICE_LOG_ITEM_EX
    {
        public int nLogType;				// Log type 
        public NETDEVTIME stuOperateTime;			// Date
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szOperator; 		    // Operator
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved;              // Reserved
        public byte bUnionType;				// union structure type,0:szLogContext;1:stuOldLog
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szLogContext;           // 0:Log content,1:Old log structure NET_OLDLOG
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szOperation;            // Detail operation
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 1024)]
        public byte[] szDetailContext;        // DetailContext
    }

    public struct NET_OLDLOG
    {
        public NET_LOG_ITEM stuLog;                 // Old log                              
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] bReserved;              // Reserved
    }

    public struct NET_LOG_ITEM
    {
        public NETDEVTIME time;					// Date 
        public ushort type;					// Type
        public byte reserved;				// Reserved
        public byte data;					// Data 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] context;				// Content
    }

    // The time definition in the log information
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct NETDEVTIME
    {
        [FieldOffset(0)]
        private uint _value;

        /// <summary>
        /// 6bit
        /// </summary>
        public uint Second
        {
            set
            {
                _value = (value & 0x003f) | (_value & 0xffffffc0);
            }
            get
            {
                return _value & 0x003f;
            }
        }

        /// <summary>
        /// 6bit
        /// </summary>
        public uint Minute
        {
            set
            {
                _value = ((value & 0x003f) << 6) | (_value & 0xfffff03f);
            }
            get
            {
                return (_value >> 6) & 0x003f;
            }
        }

        /// <summary>
        /// 5bit
        /// </summary>
        public uint Hour
        {
            set
            {
                _value = ((value & 0x001f) << 12) | (_value & 0xfffe0fff);
            }
            get
            {
                return (_value >> 12) & 0x001f;
            }
        }

        /// <summary>
        /// 5bit
        /// </summary>
        public uint Day
        {
            set
            {
                _value = ((value & 0x001f) << 17) | (_value & 0xffc3ffff);
            }
            get
            {
                return (_value >> 17) & 0x001f;
            }
        }

        /// <summary>
        /// 4bit
        /// </summary>
        public uint Month
        {
            set
            {
                _value = ((value & 0x000f) << 22) | (_value & 0xfc3fffff);
            }
            get
            {
                return (_value >> 22) & 0x000f;
            }
        }

        /// <summary>
        /// 6bit 2000-2063
        /// </summary>
        public uint Year
        {
            set
            {
                _value = (((value - 2000) & 0x003f) << 26) | (_value & 0x3ffffff);
            }
            get
            {
                return ((_value >> 26) & 0x003f) + 2000;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year.ToString("D4"), Month.ToString("D2"), Day.ToString("D2"), Hour.ToString("D2"), Minute.ToString("D2"), Second.ToString("D2"));
        }
    }

    public enum EM_DEV_ENABLE_TYPE
    {
        FTP = 0,                                                            // FTP bitwise, 1: send out record file;  2: Send out snapshot file
        SMTP,                                                               // SMTP bitwise,1: alarm send out text mail 2: Alarm send out image3:support HealthMail
        NTP,                                                                // NTP	 Bitwise:1:Adjust system time 
        AUTO_MAINTAIN,                                                      // Auto maintenance  Bitwise:1:reboot 2:close  3:delete file
        VIDEO_COVER,                                                        // Privacy mask Bitwise  :1:multiple-window privacy mask 
        AUTO_REGISTER,                                                      // Auto registration	Bitwise:1:SDK auto log in after registration 
        DHCP,                                                               // DHCP	Bitwise 1:DHCP
        UPNP,                                                               // UPNP	Bitwise 1:UPNP
        COMM_SNIFFER,                                                       // COM sniffer  Bitwise :1:CommATM
        NET_SNIFFER,                                                        // Network sniffer Bitwise : 1:NetSniffer
        BURN,                                                               // Burn function Bitwise 1:Search burn status 
        VIDEO_MATRIX,                                                       // Video matrix Bitwise  1:Support video matrix or not 2:Support SPOT video matrix or not
        AUDIO_DETECT,                                                       // Video detection Bitwise :1:Support video detection or not 
        STORAGE_STATION,                                                    // Storage position Bitwise:1:Ftp server (Ips) 2:SBM 3:NFS 16:DISK 17:Flash disk 
        IPSSEARCH,                                                          // IPS storage search  Bitwise  1:IPS storage search 	
        SNAP,                                                               // Snapshot Bitwise  1:Resoluiton 2:Frame rate 3:Snapshoot  4:Snapshoot file image; 5:Image quality 
        DEFAULTNIC,                                                         // Search default network card search  Bitwise  1:Support
        SHOWQUALITY,                                                        // Image quality configuration time in CBR mode 1:support 
        CONFIG_IMEXPORT,                                                    // Configuration import& emport function capacity.  Bitwise   1:support 
        LOG,                                                                // Support search log page by page or not. Bitwise 1:support 
        SCHEDULE,                                                           // Record setup capacity. Bitwise  1:Redandunce  2:Pre-record 3:Record period
        NETWORK_TYPE,                                                       // Network type. Bitwise 1:Wire Network 2:Wireless Network 3:CDMA/GPRS,4:CDMA/GPRS multi network card
        MARK_IMPORTANTRECORD,                                               // Important record. Bitwise 1:Important record mark
        ACFCONTROL,                                                         // Frame rate control activities. Bitwise 1:support frame rate control activities;2:support timing alarm type activate frame rate control(it does not support dynamic detection), this ability mutually exclusive with ACF ability.
        MULTIASSIOPTION,                                                    // Multiple-channel extra stream. Bitwise:1:support three channel extra stream
        DAVINCIMODULE,                                                      // Component modules bitwise: 1.Separate processing the schedule 2.Standard I franme Interval setting
        GPS,                                                                // GPS function bitwise:1:Gps locate function	
        MULTIETHERNET,                                                      // Support multi net card query   bitwise: 1: support
        LOGIN_ATTRIBUTE,                                                    // Login properties   bitwise: 1: support query login properties  
        RECORD_GENERAL,                                                     // Recording associated  bitwise: 1:Normal recording; 2:Alarm recording; 
                                                                            // 3:Motion detection recording;  4:Local storage; 5: Network storage ;  
                                                                            // 6:Redundancy storage;  7:Local emergency storage
        JSON_CONFIG,                                                        // Whether support Json configuration, bitwise: 1: support Json
        HIDE_FUNCTION,                                                      // Hide function:bitwise::1,hide PTZ function
        DISK_DAMAGE,                                                        // Harddisk damage information support ability: bitwise:1,harddisk damage information
        PLAYBACK_SPEED_CTRL,                                                // Support playback network transmission speed control, bitwise::1 support playback acceleration 
        HOLIDAYSCHEDULE,                                                    // Support holiday period setup : bitwise:1,Support holiday period setup 
        FETCH_MONEY_TIMEOUT,                                                // ATM fetch money overtime
        BACKUP_VIDEO_FORMAT,                                                // Device backup support format. DAV, ASF
        QUERY_DISK_TYPE,                                                    // backup disk type query
        CONFIG_DISPLAY_OUTPUT,                                              // backup device output of display (such as VGA) configuration, by bit: 1: configuration on tour of frame segmentation 
        SUBBITRATE_RECORD_CTRL,                                             // backup extra stream control configuration, by bit: 1-extra stream control configuration
        IPV6,                                                               // backup IPV6 configuration, by bit:1-IPV6 configuration
        SNMP,                                                               // SNMP
        QUERY_URL,                                                          // back up query device's URL info, by bit: 1-query device's config URL info
        ISCSI,                                                              // ISCSI
        RAID,                                                               // Raid
        HARDDISK_INFO,                                                      // Support disk info query
        PICINPIC,                                                           // support picture in pictu,by bit:1,set; 2,preview , record , query record , download record
        PLAYBACK_SPEED_CTRL_SUPPORT,                                        // same to EN_PLAYBACK_SPEED_CTRL
        LF_XDEV,                                                            // support LF-X series of 24, 32, 64 channels, label their encode ability with sepcial calculation, by bit 1: able;
        DSP_ENCODE_CAP,                                                     // support F5 DSP encode
        MULTICAST,                                                          // support different multicast config for different channel
        NET_LIMIT,                                                          // query the limit ability of net, bitwise,1-limit size of net send code stream  
        COM422,                                                             // serial port 422
        PROTOCAL_FRAMEWORK,                                                 // support three generations of framework agrement or not(need actualize listMethod(),listService()),by F6 to visit
        WRITE_DISK_OSD,                                                     // write disk OSD overlying ,bitwise, 1-write disk OSD overlying configuration
        DYNAMIC_MULTI_CONNECT,                                              // dynamic multi-connect,bitise,1-request reply video data
        CLOUDSERVICE,                                                       // cloud service,bitwise,1- support private cloud service
        RECORD_INFO,                                                        // Video Information Report, by bit. 1-Active video information report, 2-Frame numbers inquiry support
        DYNAMIC_REG,                                                        // Active Register Support, by bit. 1- Dynamic active register support.
        MULTI_PLAYBACK,                                                     // Multi-channel Preview and Playback, by bit. 1-Multi-channel preview and playback support.
        ENCODE_CHN,					                                        // Encoding Channel, by bit. 1- Audio-only channel support
        SEARCH_RECORD,                                                      // Record search, by bit, 1-support sync search record, 2-support 3rd generation protocol search record
        UPDATE_MD5,                                                         // Support MD5 check after update file send finish，1- support MD5
    }

    public enum EM_LOG_TYPE
    {
        REBOOT = 0x0000,						                            // Device reboot 
        SHUT,								                                // Shut down device 
        REPORTSTOP,                                                         // Report stop
        REPORTSTART,                                                        // Rreport start
        UPGRADE = 0x0004,				                                    // Device Upgrade
        SYSTIME_UPDATE = 0x0005,                                            // system time update
        GPS_TIME_UPDATE = 0x0006,			                                // GPS time update
        AUDIO_TALKBACK,	  					                                // Voice intercom, true representative open, false on behalf of the closed
        COMM_ADAPTER,						                                // Transparent transmission, true representative open, false on behalf of the closed
        NET_TIMING,                                                         // Net sync
        TYPE_NR,                                                            // NR
        CONFSAVE = 0x0100,					                                // Save configuration 
        CONFLOAD,							                                // Read configuration 
        FSERROR = 0x0200,					                                // File system error
        HDD_WERR,							                                // HDD write error 
        HDD_RERR,							                                // HDD read error
        HDD_TYPE,							                                // Set HDD type 
        HDD_FORMAT,							                                // Format HDD
        HDD_NOSPACE,							                            // Current working HDD space is not sufficient
        HDD_TYPE_RW,							                            // Set HDD type as read-write 
        HDD_TYPE_RO,							                            // Set HDD type as read-only
        HDD_TYPE_RE,							                            // Set HDD type as redundant 
        HDD_TYPE_SS,							                            // Set HDD type as snapshot
        HDD_NONE,							                                // No HDD
        HDD_NOWORKHDD,						                                // No work HDD
        HDD_TYPE_BK,							                            // Set HDD type to backup HDD
        HDD_TYPE_REVERSE,					                                // Set HDD type to reserve subarea
        HDD_START_INFO = 0x20e,                                             // note the boot-strap's hard disk info
        HDD_WORKING_DISK,                                                   // note the disk number after the disk change
        HDD_OTHER_ERROR,                                                    // note other errors of disk
        HDD_SLIGHT_ERR,						                                // there has some little errors on disk
        HDD_SERIOUS_ERR,                                                    // there has some serious errors on disk
        HDD_NOSPACE_END,                                                    // the end of the alarm that current disk has no space left 
        HDD_TYPE_RAID_CONTROL,                                              // Raid control
        HDD_TEMPERATURE_HIGH,				                                // excess temperature
        HDD_TEMPERATURE_LOW,					                            // lower die temperature
        HDD_ESATA_REMOVE,					                                // remove eSATA
        ALM_IN = 0x0300,						                            // External alarm begin 
        NETALM_IN,							                                // Network alarm input 
        ALM_END = 0x0302,					                                // External input alarm stop 
        LOSS_IN,								                            // Video loss alarm begin 
        LOSS_END,							                                // Video loss alarm stop
        MOTION_IN,							                                // Motion detection alarm begin 
        MOTION_END,							                                // Motion detection alarm stop 
        ALM_BOSHI,							                                // Annunciator alarm input 
        NET_ABORT = 0x0308,					                                // Network disconnected 
        NET_ABORT_RESUME,					                                // Network connection restore 
        CODER_BREAKDOWN,						                            // Encoder error
        CODER_BREAKDOWN_RESUME,				                                // Encoder error restore 
        BLIND_IN,							                                // Camera masking 
        BLIND_END,							                                // Restore camera masking 
        ALM_TEMP_HIGH,						                                // High temperature 
        ALM_VOLTAGE_LOW,						                            // Low voltage
        ALM_BATTERY_LOW,						                            // Battery capacity is not sufficient 
        ALM_ACC_BREAK,						                                // ACC power off 
        ALM_ACC_RES,                                                        // ACC res
        GPS_SIGNAL_LOST,						                            // GPS signal lost
        GPS_SIGNAL_RESUME,					                                // GPS signal resume
        LOG_3G_SIGNAL_LOST,						                            // 3G signal lost
        LOG_3G_SIGNAL_RESUME,					                            // 3G signal resume
        ALM_IPC_IN,							                                // IPC external alarms
        ALM_IPC_END,							                            // IPC external alarms recovery
        ALM_DIS_IN,							                                // Broken network alarm
        ALM_DIS_END,							                            // Broken network alarm recovery
        ALM_UPS_IN, 				                                        // UPS alarm 
        ALM_UPS_END, 				                                        // UPS alarm resume 
        ALM_NAS_IN,				                                            // NAS server abnormal alarm 
        ALM_NAS_END,				                                        // NAS server abnormal alarm resume 
        ALM_REDUNDANT_POWER_IN,                                             // Redundant power alarm 
        ALM_REDUNDANT_POWER_END,                                            // Redundant alarm resume  
        ALM_RECORD_FAILED_IN,				                                // Record failure alarm 
        ALM_RECORD_FAILED_END,			                                    // Record failure alarm resume 
        ALM_VGEXCEPT_IN,				                                    // Storage pool abnormal alarm 
        ALM_VGEXCEPT_END,				                                    // Storage abnormal alarm resume 		
        ALM_FANSPEED_IN,			                                        // Fan alarm starts
        ALM_FANSPEED_END,			                                        // Fan alarm stops 
        ALM_DROP_FRAME_IN,			                                        // Frame loss alarm starts 
        ALM_DROP_FRAME_END,			                                        // Frame loss alarm stops
        ALM_DISK_STATE_CHECK,		                                        // HDD pre-check tour alarm event log type 
        ALARM_COAXIAL_SMOKE,		                                        // HDCVI smoke alarm event
        ALARM_COAXIAL_TEMP_HIGH,	                                        // HDCVI temperature alarm event 
        ALARM_COAXIAL_ALM_IN,		                                        // HDCVI external alarm event 
        INFRAREDALM_IN = 0x03a0,				                            // Wireless alarm begin 
        INFRAREDALM_END,						                            // Wireless alarm end 
        IPCONFLICT,							                                // IP conflict 
        IPCONFLICT_RESUME,					                                // IP restore
        SDPLUG_IN,							                                // SD Card insert
        SDPLUG_OUT,							                                // SD Card Pull-out
        NET_PORT_BIND_FAILED,				                                // Failed to bind port
        HDD_BEEP_RESET,                                                     // Hard disk error beep reset 
        MAC_CONFLICT,                                                       // MAC conflict
        MAC_CONFLICT_RESUME,                                                // MAC conflict resume
        ALARM_OUT,							                                // alarm out
        ALM_RAID_STAT_EVENT,                                                // RAID state event    
        ABLAZE_ON,				                                            // Fire alarm, smoker or high temperature
        ABLAZE_OFF,			                                                // Fire alarm reset 
        INTELLI_ALARM_PLUSE,					                            // Intelligence pulse alarm
        INTELLI_ALARM_IN,					                                // Intelligence alarm start
        INTELLI_ALARM_END,					                                // Intelligence alarm end
        LOG_3G_SIGNAL_SCAN,						                            // 3G signal scan
        GPS_SIGNAL_SCAN,						                            // GPS signal scan
        AUTOMATIC_RECORD = 0x0400,			                                // Auto record 
        MANUAL_RECORD = 0x0401,				                                // Manual record 
        CLOSED_RECORD,						                                // Stop record 
        LOGIN = 0x0500,						                                // Log in 
        LOGOUT,								                                // Log off 
        ADD_USER,							                                // Add user
        DELETE_USER,							                            // Delete user
        MODIFY_USER,							                            // Modify user 
        ADD_GROUP,							                                // Add user group 
        DELETE_GROUP,						                                // Delete user group 
        MODIFY_GROUP,						                                // Modify user group 
        NET_LOGIN = 0x0508,					                                // Network Login
        MODIFY_PASSWORD,						                            // Modify password
        CLEAR = 0x0600,						                                // Clear log 
        SEARCHLOG,							                                // Search log 
        SEARCH = 0x0700,						                            // Search record 
        DOWNLOAD,							                                // Record download
        PLAYBACK,							                                // Record playback
        BACKUP,								                                // Backup recorded file 
        BACKUPERROR,							                            // Failed to backup recorded file
        BACK_UPRT,							                                // Real-time backup, that is, copy CD
        BACKUPCLONE,							                            // CD copy
        DISK_CHANGED,						                                // Manual changed
        IMAGEPLAYBACK,						                                // Image playback
        LOCKFILE,							                                // Lock the video
        UNLOCKFILE,							                                // Unlock the video
        ATMPOS,								                                // Add log superposition of ATM card number
        PLAY_PAUSE,								                            // Pause
        PLAY_START,								                            // Start
        PLAY_STOP,								                            // Stop
        PLAY_BACK,								                            // Back
        PLAY_FAST,								                            // Fast
        PLAY_SLOW,								                            // Slow
        SMART_SEARCH,							                            // Search
        RECORD_SNAP,							                            // Snap
        ADD_TAG,								                            // Add tag
        DEL_TAG,								                            // Delete tag
        USB_IN,									                            // USB connected
        USB_OUT,								                            // USB disconnected
        BACKUP_FILE,							                            // Backup file
        BACKUP_LOG,								                            // Backup log
        BACKUP_CONFIG,							                            // Backup config
        TIME_UPDATE = 0x0800,                                               // Time update
        REMOTE_STATE = 0x0850,                                              // remote diary 
        USER_DEFINE = 0x0900,                                               // User define
    }

    public struct DEV_EVENT_CROSSLINE_INFO
    {
        public int nChannelID;						// ChannelId
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;					        // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;                     // byte alignment
        public double PTS;                          // PTS(ms)
        public NET_TIME_EX UTC;                         // the event happen time
        public int nEventID;                        // event ID
        public NET_MSG_OBJECT stuObject;                        // have being detected object
        public NET_EVENT_FILE_INFO stuFileInfo;                    // event file info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] DetectLine;                     // rule detect line
        public int nDetectLineNum;                 // rule detect line's point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] TrackLine;                      // object moveing track
        public int nTrackLineNum;                  // object moveing track's point number
        public byte bEventAction;                   // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        public byte bDirection;                     // direction, 0-left to right, 1-right to left
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] byReserved;
        public byte byImageIndex;                   // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;                 // flag(by bit),see NET_RESERVED_COMMON
        public int nSourceIndex;                   // the source device's index,-1 means data in invalid
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSourceDevice;                 // the source device's sign(exclusive),field said local device does not exist or is empty
        public uint nOccurrenceCount;               // event trigger accumulated times
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;             // intelli comm info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 476)]
        public byte[] bReserved;                        // reserved

    }


    public struct NET_DEV_EVENT_CROSSREGION_INFO
    {
        public int nChannelID;						// ChannelId
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;					        // event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved2;                     // byte alignment
        public double PTS;                          // PTS(ms)
        public NET_TIME_EX UTC;                         // the event happen time
        public int nEventID;                        // event ID
        public NET_MSG_OBJECT stuObject;                        // have being detected object
        public NET_EVENT_FILE_INFO stuFileInfo;                    // event file info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] DetectRegion;                   // rule detect region
        public int nDetectRegionNum;               // rule detect region's point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] TrackLine;                      // object moving track
        public int nTrackLineNum;                  // object moving track's point number
        public byte bEventAction;                   // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        public byte bDirection;                     // direction, 0-in, 1-out,2-apaer,3-leave
        public byte bActionType;                    // action type,0-appear 1-disappear 2-in area 3-cross area
        public byte byImageIndex;					// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public uint dwSnapFlagMask;                 // flag(by bit),see NET_RESERVED_COMMON
        public int nSourceIndex;                   // the source device's index,-1 means data in invalid
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSourceDevice;                 // the source device's sign(exclusive),field said local device does not exist or is empty
        public uint nOccurrenceCount;               // event trigger times
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 536)]
        public byte[] bReserved;                        // reserved
        public int nObjectNum;                     // Detect object amount
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_MSG_OBJECT[] stuObjectIDs;                   // Detected object
        public int nTrackNum;                      // Locus amount(Corresponding to the detected object amount.)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_POLY_POINTS[] stuTrackInfo;                   // Locus info(Corresponding to the detected object)
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;             // intelli comm info
    }

    public struct NET_POLY_POINTS
    {
        public int nPointNum;                      // point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] stuPoints;                      // point info
    }

    public struct NET_DEV_EVENT_FACEDETECT_INFO
    {
        public int nChannelID;			// channel ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;				// event name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;         // byte alignment
        public double PTS;              // PTS(ms)
        public NET_TIME_EX UTC;             // the event happen time
        public int nEventID;            // event ID
        public NET_MSG_OBJECT stuObject;            // have being detected object
        public NET_EVENT_FILE_INFO stuFileInfo;     // event file info
        public byte bEventAction;       // Event action: 0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserved;           // reserved
        public byte byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        public int nDetectRegionNum;	// detect region point number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[] DetectRegion;       // detect region
        public uint dwSnapFlagMask;	    // flag(by bit),see NET_RESERVED_COMMON
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSnapDevAddress;   // snapshot current face device address
        public uint nOccurrenceCount;   // event trigger accumilated times 
        public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;              // sex type
        public int nAge;               // age, invalid if it is -1
        public uint nFeatureValidNum;   // invalid number in array emFeature
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emFeature;          // human face features
        public int nFacesNum;          // number of stuFaces
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public NET_FACE_INFO[] stuFaces;           // when nFacesNum > 0, stuObject invalid
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo; // public info 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 892)]
        public byte[] bReserved;          // Reserved 
    }

    public enum EM_DEV_EVENT_FACEDETECT_SEX_TYPE
    {
        UNKNOWN,                                                            // unknown
        MAN,                                                                // male
        WOMAN,                                                              // female
    }

    public enum EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE
    {
        UNKNOWN,                                                            // unknown
        WEAR_GLASSES,                                                       // wearing glasses
        SMILE,                                                              // smile
        ANGER,                                                              // anger
        SADNESS,                                                            // sadness
        DISGUST,                                                            // disgust
        FEAR,                                                               // fear
        SURPRISE,                                                           // surprise
        NEUTRAL,                                                            // neutral
        LAUGH,                                                              // laugh
        NOGLASSES,			                                                // not wear glasses
    }

    public struct NET_FACE_INFO
    {
        public int nObjectID;                          // object id
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szObjectType;                       // object type
        public int nRelativeID;                        // same with the source picture id
        public NET_RECT BoundingBox;                        // bounding box
        public NET_POINT Center;                             // object center
    }

    public struct NET_DEV_EVENT_FACERECOGNITION_INFO
    {
        public int nChannelID;						// ChannelId
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;					        // event name
        public int nEventID;                       // event ID
        public NET_TIME_EX UTC;                         // the event happen time
        public NET_MSG_OBJECT stuObject;                        // have being detected object
        public int nCandidateNum;                  // candidate number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public NET_CANDIDATE_INFO[] stuCandidates;                  // candidate info
        public byte bEventAction;                   // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        public byte byImageIndex;                   // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved1;                  // reserved
        public bool bGlobalScenePic;                // The existence panorama
        public NET_PIC_INFO stuGlobalScenePicInfo;          // Panoramic Photos
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSnapDevAddress;               // Snapshot current face aadevice address  
        public uint nOccurrenceCount;               // event trigger accumilated times 
        public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;             // intelligent things info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 592)]
        public byte[] bReserved;                      // Reserved bytes.
    }

    public struct NET_CANDIDATE_INFO
    {
        public NET_FACERECOGNITION_PERSON_INFO stPersonInfo;               // person info
        public byte bySimilarity;               // similarity
        public byte byRange;                    // Range officer's database, see EM_FACE_DB_TYPE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved1;
        public NET_TIME stTime;                     // When byRange historical database effectively, which means that the query time staff appeared
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szAddress;                  // When byRange historical database effectively, which means that people place a query appears
        public bool bIsHit;                     // Is hit, means the result face has compare result in database
        public NET_PIC_INFO_EX3 stuSceneImage;              // Scene Image
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public byte[] byReserved;                 // Reserved bytes
    }

    public struct NET_FACERECOGNITION_PERSON_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szPersonName;             // name                 
        public uint wYear;                      // birth year
        public byte byMonth;                    // birth month
        public byte byDay;						// birth day
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szID;                     // the unicle ID for the person
        public byte bImportantRank;             // importance level,1~10,the higher value the higher level
        public byte bySex;                      // sex, 0-man, 1-female
        public uint wFacePicNum;				// picture number
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public NET_PIC_INFO[] szFacePicInfo;              // picture info
        public byte byType;                     // Personnel types, see EM_PERSON_TYPE
        public byte byIDType;                   // Document types, see EM_CERTIFICATE_TYPE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved1;                 // Byte alignment
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szProvince;                 // province
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szCity;                     // city
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szPersonNameEx;	            // Name, the name is too long due to the presence of 16 bytes can not be Storage problems, the increase in this parameter
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szUID;                      // person unique ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string szCountry;                    // country
        public byte byIsCustomType;             // using person type: 0 using byType, 1 using szPersonName
        public IntPtr pszComment;				    // comment info
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] bReserved;                  // reserved
    }

    public struct NET_PIC_INFO_EX3
    {
        public uint dwOffSet;                   // current picture file's offset in the binary file, byte
        public uint dwFileLenth;                // current picture file's size, byte
        public ushort wWidth;                     // picture width, pixel
        public ushort wHeight;                    // picture high, pixel
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szFilePath;                 // File path
        public byte bIsDetected;			    // When submit to the server, the algorithm has checked the image or not 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] bReserved;					// Reserved
    }

}
