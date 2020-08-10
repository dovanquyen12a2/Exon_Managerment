using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public static class Common
    {

        public static int STATUS_LOGGED = 3000;

        // Trạng thái thí sinh đã đăng nhập (trước đó đã thi nhưng bị gián đoạn) (Nhận)
        public static int STATUS_LOGGED_DO_NOT_FINISH = 3001;

        // Trạng thái thí sinh sẵn sàng để thi ( đã load xong câu hỏi) (Nhận)
        public static int STATUS_READY = 3002;

        // Trạng thái thí sinh đang làm bài thi(Nhận)
        public static int STATUS_DOING = 3003;

        // Trạng thái đang làm thì bị gián đoạn (bị crash chương trình)(Nhận)
        public static int STATUS_DOING_BUT_INTERRUPT = 3004;

        // Trạng thái đã thi xong(Nhận)
        public static int STATUS_FINISHED = 3005;

        // Trạng thái thí sinh báo lỗi (Nhận)
        public static int STATUS_REPORT_ERROR = 3006;

        // Trạng thái thí sinh đăng nhập sai số báo danh(Nhận)
        public static int STATUS_LOGIN_FAIL = 3007;

        // Trạng thái thông báo bị cảnh cáo(Gửi)
        public static int STATUS_WARNING = 3008;

        // Trạng thái thông báo bắt đầu làm bài thi (Gửi)
        public static int STATUS_STARTED = 3009;

        // Trạng thái sẵn sàng nhận đề thi và danh sách câu hỏi (Nhận)
        public static int STATUS_READY_TO_GET_TEST = 3010;

        // Trạng thái nhận đề thi và danh sách câu hỏi (Gửi)
        public static int STATUS_GET_TEST = 3011;
        // Trạng thái thí sinh chuyển sang ca thi dự phòng
        public static int STATUS_CHANGE_SHIFT = 5001;
        // Trạng thái khởi tạo
        public static int STATUS_INITIALIZE = 4001;

        // Trạng thái đã bị thay đổi
        public static int STATUS_CHANGED = 4002;

        //trạng thái đã xếp chỗ
        public static int STATUS_ARR = 2;

        // trạng thái đã điểm danh
        public static int STATUS_ATTENDANCE = 3;

        //trang thái đã xác thực
        public static int STATUS_VERITY = 4;
        
        // trạng thái đã giải mã đề thi
        public static int STATUS_DECRYPT = 5;

        //trạng thái đã phát đề
        public static int STATUS_DIVISIONTEST = 6;

        //trạng thái đã bắt đầu
        public static int STATUS_STARTTEST = 7;
        // //// Trạng thái thí sinh đã đăng nhập ( là thí sinh mới) // không cẩn thiết
        // //public static int STATUS_VERIFY_SUCCESS = 2000;
        public static bool CloseSocket { get; set; } = false;
        // public static int STATUS_LOGGED = 3000;

        // // Trạng thái thí sinh đã đăng nhập (trước đó đã thi nhưng bị gián đoạn)
        // public static int STATUS_LOGGED_DO_NOT_FINISH = 3001;

        // // Trạng thái thí sinh sẵn sàng để thi ( đã load xong câu hỏi)
        // public static int STATUS_READY = 3002;

        // // Trạng thái thí sinh đang làm bài thi
        // public static int STATUS_DOING = 3003;

        // // Trạng thái đang làm thì bị gián đoạn (bị crash chương trình)
        // public static int STATUS_DOING_BUT_INTERRUPT = 3004;

        // // Trạng thái đã thi xong
        // public static int STATUS_FINISHED = 3005;

        // // Trạng thái thí sinh bị cảnh cáo
        // public static int STATUS_REPORT_ERROR = 3006;

        // // Trạng thái thí sinh đăng nhập sai số báo danh
        // public static int STATUS_LOGIN_FAIL = 3007;

        // // Trạng thái thông báo bị cảnh cáo
        // public static int STATUS_WARNING = 3008;

        // // Trạng thái thông báo bắt đầu làm bài thi
        // public static int STATUS_STARTED = 3009;

        // // Trạng thái tạm dừng
        //// public static int STATUS_PAUSE = 3010;

        //Trạng thái khởi tạo
        //public static int STATUS_INITIALIZE = 4001;

        //Trạng thái đã bị thay đổi
        //public static int STATUS_CHANGED = 4002;
    }
}
