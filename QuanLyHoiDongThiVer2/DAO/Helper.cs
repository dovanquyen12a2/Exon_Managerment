using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiDongThiVer2.DAO
{
    public static class Helper
    {
        /// <summary>
        ///  đổi thời gian sang int
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }

        /// <summary>
        /// đổi int sang thời gian
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }

        public static string TrangThaiPhongThi(int status)
        {
            if (status == 1) return "Chưa bắt đầu thi";
            if (status == 2) return "Đã xếp chỗ";
            if (status == 3) return "Đã điểm danh";
            if (status == 4) return "Đã xác thực";
            if (status == 5) return "Đã giải mã đề thi";
            if (status == 6) return "Đã phát đề";
            if (status == 7) return "Đã bắt đầu thi";
            if (status == 8) return "Đã kết thúc";
            return "";
        }

        public static string TrangThaiKiThi(int status)
        {
            if (status == 0) return "Mới tạo và chưa phê duyệt";
            if (status == 1) return "Đã phê duyệt và chưa đăng ký";
            if (status == 2) return "Đã hủy";
            if (status == 3) return "Đã hoàn thành";
            if (status == 4) return "Đã đăng ký và chưa xếp lịch";
            if (status == 5) return "Đã xếp lịch và chưa làm đề";
            if (status == 6) return "Đã làm đề và chưa chyển CSDL";
            if (status == 7) return "Đã chuyển CSDL và đang thi";
            return "";
        }

        public static string TrangThaiThiSinh(int status)
        {

            if (status == 3000) return "Đã đăng nhập";
            if (status == 3001) return "Đã đăng nhập lại";
            if (status == 3002) return "Sẵn sàng nhận đề thi";
            if (status == 3003) return "Đang làm bài thi";
            if (status == 3004) return "Làm bài thi bị gián đoạn";
            if (status == 3005) return "Đã hoàn thành thi";
            if (status == 3006) return "Thí sinh báo lỗi";
            if (status == 3007) return "Trạng thái đăng nhập sai số báo danh";
            if (status == 3008) return "Bị cảnh cáo";
            if (status == 3009) return "Bắt đầu làm bài thi";
            if (status == 3010) return "Sẵn sàng nhận đề thi và danh sách câu hỏi";
            if (status == 3011) return "Đã nhận đề thi và danh sách câu hỏi";

            if (status == 4001) return "Chưa thi";

            return "";
            // Trạng thái khởi tạo
            //public static int STATUS_INITIALIZE = 4001;

            // Trạng thái đã bị thay đổi
            //public static int STATUS_CHANGED = 4002;
        }


    }
}
