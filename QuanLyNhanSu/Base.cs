using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public static class Base
    {
        public static void ShowCompleteMessage(int check, string content="")
        {
            if (check == 1)
                MessageBox.Show("Thêm mới " + content + " thành công!!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (check == 2)
                MessageBox.Show("Sửa " + content + " thành công!!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if(check==3)
                MessageBox.Show("Xóa " + content + " thành công!!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void ShowErrorMessage(int check, string contentError="")
        {       
            if (check == 1)
                MessageBox.Show("Thêm mới thất bại!! "+contentError , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (check == 2)
                MessageBox.Show("Sửa không thành công!!"+contentError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (check == 3)
                MessageBox.Show("Xóa không thành công!!" + contentError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowError(string contentError)
        {
            MessageBox.Show(contentError, "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        public static DialogResult ShowDialogResultMessage(string content = "")
        {
            return MessageBox.Show("Bạn có chắc chắn muốn xóa " + content, "Xóa vĩnh viễn!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}