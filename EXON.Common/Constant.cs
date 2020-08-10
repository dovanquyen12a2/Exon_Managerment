using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace EXON.Common
{
    public static class Constant
    {

        public static int WIDTH_SCREEN = Screen.PrimaryScreen.Bounds.Size.Width;
        public static int HEIGHT_SCREEN = Screen.PrimaryScreen.Bounds.Size.Height;
        public static int WIDTH_PANEL_INFORMATION = Convert.ToInt32(WIDTH_SCREEN * 0.3);

        public static int ASSIGN_OBJECT = 1000;
        public static int CONTROL_QUESTION = 1001;
        public static int LAYOUT_QUESTION = 1002;
        public static int CONTROL_BUTTON = 1003;
        public static int LAYOUT_BUTTON = 1004;
        public static int RADIO_PERFORMCLICK = 1005;

        public static int STATUS_OK = 1;

        public static int STATUS_NORMAL = -1;

        public static int ANS_UNCHECK = 2000;
        public static int ANS_CHECKED_A = 2001;
        public static int ANS_CHECKED_B = 2002;
        public static int ANS_CHECKED_C = 2003;
        public static int ANS_CHECKED_D = 2004;

        // Trạng thái thí sinh đã đăng nhập ( là thí sinh mới)
        public static int STATUS_LOGGED = 3000;

        // Trạng thái thí sinh đã đăng nhập (trước đó đã thi nhưng bị gián đoạn)
        public static int STATUS_LOGGED_DO_NOT_FINISH = 3001;
        //public static string STR_STATUS_LOGGED_DO_NOT_FINISH = string.Format("{0}: {1}", STATUS_LOGGED_DO_NOT_FINISH, Properties.Resources.MSG_MESS_0039);
        //// Trạng thái thí sinh sẵn sàng để thi ( đã load xong câu hỏi)
        public static int STATUS_READY = 3002;

        //// Trạng thái thí sinh đang làm bài thi
        public static int STATUS_DOING = 3003;
        //public static string STR_STATUS_DOING = string.Format("{0}: {1}", STATUS_DOING, Properties.Resources.MSG_MESS_0036);
        //// Trạng thái đang làm thì bị gián đoạn (bị crash chương trình)
        public static int STATUS_DOING_BUT_INTERRUPT = 3004;
        //public static string STR_STATUS_DOING_BUT_INTERRUPT = string.Format("{0}: {1}", STATUS_DOING_BUT_INTERRUPT, Properties.Resources.MSG_MESS_0035);
        //// Trạng thái đã thi xong
        public static int STATUS_FINISHED = 3005;
        //public static string STR_STATUS_FINISHED = string.Format("{0}: {1}", STATUS_FINISHED, Properties.Resources.MSG_MESS_0033);

        // Trạng thái thí sinh bị cảnh cáo
        public static int STATUS_REPORT_ERROR = 3006;

        // Trạng thái thí sinh đăng nhập sai số báo danh
        public static int STATUS_LOGIN_FAIL = 3007;

        // Trạng thái thông báo bị cảnh cáo
        public static int STATUS_WARNING = 3008;

        // Trạng thái thông báo bắt đầu làm bài thi
        public static int STATUS_STARTED = 3009;

        // Trạng thái sẵn sàng nhận đề thi và danh sách câu hỏi
        public static int STATUS_READY_TO_GET_TEST = 3010;

        // Trạng thái nhận đề thi và danh sách câu hỏi
        public static int STATUS_GET_TEST = 3011;

        // Đăng nhập sai máy thi
        public static int STATUS_WRONG_COMPUTTER = 3012;

        // Trạng thái thí sinh bị đình chỉ thi
        public static int STATUS_REJECT = 3013;

        // Trạng thái khởi tạo
        public static int STATUS_INITIALIZE = 4001;
        // public static string STR_STATUS_INITIALIZE_CONTESTANT = string.Format("{0}: {1}", Constant.STATUS_INITIALIZE, Properties.Resources.MSG_MESS_0034);

        // Trạng thái đã bị thay đổi
        public static int STATUS_CHANGED = 4002;
        //trạng thái tạm ngừng thi
        public static int STATUS_PAUSE = 5000;
        // Trạng thái thí sinh chuyển sang ca thi dự phòng
        public static int STATUS_CHANGE_SHIFT = 5001;

        // Trạng thái lỗi từ SQL
        public static int STATUS_UNKOWN_EXCEPTION = 1001;
        public static string STR_STATUS_UNKOWN_EXCEPTION = "Unknown exception. [{0}]";

        public static int FORMAT_QUESTION_HTML = 0;
        public static int FORMAT_QUESTION_RTF = 1;
        public static string STRING_QUESTION_HTML = "ucQuestionsHTML";
        public static string STRING_QUESTION_RTF = "ucQuestionsRTF";
        public static string STRING_FLOWLAYOUTPANEL = "FlowLayoutPanel";

        public static string FONT_FAMILY_DEFAULT = "Times New Roman";
        public static int FONT_SIZE_DEFAULT = 14;

        public static Color COLOR_TRANSPARENT = Color.Transparent;
        public static Color COLOR_WHITE = Color.White;
        public static Color COLOR_RED = Color.Red;
        public static Color COLOR_BLACK = Color.Black;
        public static Color BACKCOLOR_PANEL_WELCOME = Color.FromArgb(33, 150, 243);
        public static Color BACKCOLOR_PANEL_INFORMATION = Color.FromArgb(225, 245, 254);
        public static Color BACKCOLOR_PANEL_WRAPPER_CONTENT = Color.FromArgb(30, 136, 229);
        public static Color BACKCOLOR_PANEL_QUESTION = Color.FromArgb(129, 212, 250);

        public static Color BACKCOLOR_BUTTON_CONTROLLER = Color.FromArgb(41, 182, 246);
        public static Color BACKCOLOR_BUTTON_QUESTION = Color.FromArgb(255, 234, 0);

        public static Color FORCECOLOR_BUTTON_CONFIRM = Color.FromArgb(33, 150, 243);
        public static Color FORCECOLOR_BUTTON_SUBMIT = Color.FromArgb(250, 250, 250);
        public static Color FORCECOLOR_BUTTON_REPORTERROR = Color.FromArgb(229, 57, 53);
        public static Color FORCECOLOR_BUTTON_QUESTION = Color.FromArgb(97, 97, 97);
        public static Color FORECECOLOR_LABEL_OK = Color.FromArgb(0, 230, 118);

        public static Color FORCECOLOR_LABEL_CONTEST_NAME = Color.Black;
        public static Color FORCECOLOR_LABEL_TIMER = Color.FromArgb(30, 136, 229);
        public static Color FORCECOLOR_LABEL_HEADER_CONTENT = Color.FromArgb(233, 30, 99);

        public static Size SIZE_BUTTON_DEFAULT = new Size(100, 40);
        public static Size SIZE_BUTTON_QUESTION = new Size(85, 40);

        public static string FORMAT_DATE_DEFAULT = "dd-MM-yyyy";
        public static string FORMAT_TIME_DEFAULT = "H:mm";

        public static int LOGIN_WITH_CONTESTANT_CODE = 5000;
        public static int LOGIN_WITH_STUDENT_CODE = 5001;
        public static int LOGIN_WITH_IDENTITY_CARD_NAME = 5002;

        public static int TYPE_NOTIFICATION_INFO = 6000;
        public static int TYPE_NOTIFICATION_YESNO = 6001;
        public static int TYPE_NOTIFICATION_WARNING = 6002;
        public static int TYPE_NOTIFICATION_RESULT = 6003;
        // Khi thí sinh mới đăng nhập vào và đợi lệnh lấy đề thi
        public static int WAITING_BY_ADMIN_TO_LOAD_TEST = 7000;
        // Khi thí sinh mới đăng nhập vào và đợi lệnh lấy đề thi
        public static int LOAD_TEST_WITH_CONTESTANT_INTERRUPT = 7001;

        public static DateTime DATETIME_ORIGINAL_DATE = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static DateTime DATETIME_START_DATE = DateTime.Now;

        // Mật khẩu mã hóa
        public static string ENCRYPT_PASS_HASH = "580f26b973f3f514459db7feb620e2a8"; //EXON2017

        public static string pathTemp = Application.StartupPath + "\\Template\\WritingAnswer.docx";
        public static string pathTempSpeaking = Application.StartupPath + "\\Template\\QuestionSpeaking.docx";
        public static string pathTempAnswer = Application.StartupPath + "\\Temp\\";
        public static string PATH_EXON = Environment.GetFolderPath(SpecialFolder.CommonApplicationData) + "\\Supervision";
        public static string PATH_CONFIG_CAM = PATH_EXON + "\\ConfigCam.xml";
        public static string PATH_CONFIG_FILE = PATH_EXON + "\\config.ini";

        public static string PATH_CONFIG_FILE_TMP = PATH_EXON + "\\config_tmp.ini";

        // Cấu hình file config
        public static string SECTION_COMMON = "COMMON";

        public static string SECTION_DATABASE = "DATABASE";

        public static string SECTION_SUPERVISOR = "SUPERVISOR";

        public static int BUFFER_SIZE_DEFAULT = 255;

        public enum StatusDivisionShift { Status_Zero, STATUS_INIT, STATUS_GENTEST, STATUS_ATTENDANCE, STATUS_VERITY, STATUS_DECRYPT, STATUS_DIVISIONTEST, STATUS_STARTTEST, STATUS_COMPLETE, STATUS_PAUSE }
    }
}
